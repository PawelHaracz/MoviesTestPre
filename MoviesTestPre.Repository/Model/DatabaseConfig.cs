using System.Configuration;

namespace MoviesTestPre.Repository.Model
{
    public class DatabaseConfig
    {
        public string DataBaseId { get; set; } = ConfigurationManager.AppSettings["APPSETTING_database"];
        public string CollectionId { get; set; } = ConfigurationManager.AppSettings["APPSETTING_collection"];
        //public string EndPoint { get; set; } = ConfigurationManager.AppSettings["APPSETTING_endpoint"];
        //public string AuthTokey { get; set; } = ConfigurationManager.AppSettings["APPSETTING_authKey"];
    }
}
