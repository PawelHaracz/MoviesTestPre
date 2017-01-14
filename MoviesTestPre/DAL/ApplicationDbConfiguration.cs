using System.Data.Entity.Migrations;

namespace MoviesTestPre.DAL
{
    public class ApplicationDbConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}