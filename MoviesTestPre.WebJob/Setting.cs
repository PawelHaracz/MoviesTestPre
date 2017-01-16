using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTestPre.WebJob
{
    public class Setting
    {
        public string EndPoint { get; }
        public string ApiKey { get; }
        public Setting()
        {
            EndPoint = Environment.GetEnvironmentVariable("APPSETTING_EndPoint");
            ApiKey = Environment.GetEnvironmentVariable("APPSETTING_ApiKey");
        }
    }
}
