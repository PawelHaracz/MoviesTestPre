using System.Data.Entity.Migrations;

namespace MoviesTestPre.Repository.DAL
{
    public class ApplicationDbConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}