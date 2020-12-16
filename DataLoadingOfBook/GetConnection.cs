using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadingOfBook
{
    public class GetConnection
    {
        public static IDbConnection MadeConnection()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["default"];
            string provider = connectionStringSettings.ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            IDbConnection conn = factory.CreateConnection();
            string confstring = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            conn.ConnectionString = confstring;

            return conn;

        }

    }
}
