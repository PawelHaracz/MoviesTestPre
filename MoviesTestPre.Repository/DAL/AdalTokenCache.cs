using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace MoviesTestPre.Repository.DAL
{
    public class AdalTokenCache : TokenCache
    {
        private const string AdalCache = "ADALCache";
        private readonly string _userId;
        private readonly ApplicationDbContext _db;
        private UserTokenCache _cache;

        public AdalTokenCache(string signedInUserId)
        {
            _db = new ApplicationDbContext();
            // associate the cache to the current user of the web app
            _userId = signedInUserId;
            AfterAccess = AfterAccessNotification;
            BeforeAccess = BeforeAccessNotification;
            BeforeWrite = BeforeWriteNotification;
            // look up the entry in the database
            _cache = Queryable.FirstOrDefault<UserTokenCache>(_db.UserTokenCaches, c => c.webUserUniqueId == _userId);
            // place the entry in memory
            Deserialize((_cache == null) ? null : MachineKey.Unprotect(_cache.cacheBits, AdalCache));
        }

        // clean up the database
        public override void Clear()
        {
            base.Clear();
            var cacheEntry = Queryable.FirstOrDefault<UserTokenCache>(_db.UserTokenCaches, c => c.webUserUniqueId == _userId);
            _db.UserTokenCaches.Remove(cacheEntry);
            _db.SaveChanges();
        }

        // Notification raised before ADAL accesses the cache.
        // This is your chance to update the in-memory copy from the DB, if the in-memory version is stale
        private void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            if (_cache == null)
            {
                // first time access
                _cache = Queryable.FirstOrDefault<UserTokenCache>(_db.UserTokenCaches, c => c.webUserUniqueId == _userId);
            }
            else
            { 
                // retrieve last write from the DB
                var status = from e in _db.UserTokenCaches
                             where (e.webUserUniqueId == _userId)
                select new
                {
                    LastWrite = e.LastWrite
                };

                // if the in-memory copy is older than the persistent copy
                if (Queryable.First(status).LastWrite > _cache.LastWrite)
                {
                    // read from from storage, update in-memory copy
                    _cache = Queryable.FirstOrDefault<UserTokenCache>(_db.UserTokenCaches, c => c.webUserUniqueId == _userId);
                }
            }
            Deserialize((_cache == null) ? null : MachineKey.Unprotect(_cache.cacheBits, AdalCache));
        }

        // Notification raised after ADAL accessed the cache.
        // If the HasStateChanged flag is set, ADAL changed the content of the cache
        private void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if state changed
            if (HasStateChanged)
            {
                _cache = new UserTokenCache
                {
                    webUserUniqueId = _userId,
                    cacheBits = MachineKey.Protect(this.Serialize(), AdalCache),
                    LastWrite = DateTime.Now
                };
                // update the DB and the lastwrite 
                _db.Entry(_cache).State = _cache.UserTokenCacheId == 0 ? EntityState.Added : EntityState.Modified;
                _db.SaveChanges();
                HasStateChanged = false;
            }
        }

        private void BeforeWriteNotification(TokenCacheNotificationArgs args)
        {
            // if you want to ensure that no concurrent write take place, use this notification to place a lock on the entry
        }

        public override void DeleteItem(TokenCacheItem item)
        {
            base.DeleteItem(item);
        }
    }
}
