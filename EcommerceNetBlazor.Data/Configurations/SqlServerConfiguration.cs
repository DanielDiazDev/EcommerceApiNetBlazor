using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNetBlazor.Data.Configurations
{
    public static class SqlServerConfiguration
    {
        public static string BuildConnectionString(IConfiguration configuration)
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            configuration.Bind("SqlServerConnection", databaseConfig);
            StringBuilder sb = new StringBuilder();
            sb.Append($"Server={databaseConfig.Server};");
            sb.Append($"Database={databaseConfig.Database};");
            sb.Append($"User Id={databaseConfig.UserId};");
            sb.Append($"Password={databaseConfig.Password};");
            sb.Append($"Trusted_Connection={databaseConfig.TrustedConnection};");
            sb.Append($"TrustServerCertificate={databaseConfig.TrustServerCertificate};");
            return sb.ToString();
        }
    }
}
