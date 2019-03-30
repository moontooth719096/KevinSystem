using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KevinSystem.DB.CommonClass
{
    public class DBConnection:DBbase
    {
        protected static IConfiguration Configuration { get; set; }

        protected void Connection(string dbName)
        {
#if (DEBUG)
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("TestDBList.json", optional: true, reloadOnChange: true);
#else
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("DBList.json", optional: true, reloadOnChange: true);
#endif

            Configuration = builder.Build();
            String ip = Configuration[dbName + ":ip"];
            String user = Configuration[dbName + ":user"];
            String pwd = Configuration[dbName + ":pwd"];
#if (DEBUG)
            Connection_ForWindows(ip, user, pwd);
#else
            Connection_ForPassword(ip, user, pwd);
#endif

        }
    }
}
