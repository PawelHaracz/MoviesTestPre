using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using MoviesTestPre.Repository.FuterDAL.Model;

namespace MoviesTestPre.Repository.FuterDAL
{
    public class DocuemntPermissionRepository : DocumentRepositoryBase
    {
        public DocuemntPermissionRepository(IDocumentClient client, DatabaseConfig config) : base(client, config)
        {
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await Client.CreateUserAsync(UriFactory.CreateDatabaseUri(DatabaseId), user);
        }

        public async Task<Permission> CreatePermissionAsync(Permission permission)
        {
           return await Client.CreatePermissionAsync(UriFactory.CreateUserUri(DatabaseId, CollectionId), permission);
        }

    }
}
