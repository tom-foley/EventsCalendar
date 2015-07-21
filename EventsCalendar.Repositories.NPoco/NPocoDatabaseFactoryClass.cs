using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using NPoco.FluentMappings;
using System.Configuration;

namespace EventsCalendar.Repositories.NPoco
{
    public static class NPocoDatabaseFactory
    {
        public static DatabaseFactory InitializeFactory()
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new NPocoModelMappings());
            string connection = ConfigurationManager.ConnectionStrings["ConnectionStringDEBUG"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["ConnectionStringDEBUG"].ProviderName;
            return DatabaseFactory.Config(x =>
            {
                x.WithFluentConfig(fluentConfig);
                x.UsingDatabase(() => new Database(connection, provider));
            });
        }


        public static DatabaseFactory InitializeFactory(string connectionString)
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new NPocoModelMappings());
            string connection = ConfigurationManager.ConnectionStrings["ConnectionStringDEBUG"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["ConnectionStringDEBUG"].ProviderName;
            return DatabaseFactory.Config(x =>
            {
                x.WithFluentConfig(fluentConfig);
                x.UsingDatabase(() => new Database(connection, provider));
            });
        }
    }
}