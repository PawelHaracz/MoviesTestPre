using System.Data.Entity;

namespace MoviesTestPre.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<UserTokenCache> UserTokenCaches { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }

    }
}
