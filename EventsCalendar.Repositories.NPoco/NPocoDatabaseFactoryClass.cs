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

            return DatabaseFactory.Config(x =>
            {
                x.WithFluentConfig(fluentConfig);
                x.UsingDatabase(() => new Database(ConfigurationManager.ConnectionStrings[0].ConnectionString, ConfigurationManager.ConnectionStrings[0].ProviderName));
            });
        }


        public static DatabaseFactory InitializeFactory(string connectionString)
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new NPocoModelMappings());

            return DatabaseFactory.Config(x =>
            {
                x.WithFluentConfig(fluentConfig);
                x.UsingDatabase(() => new Database(ConfigurationManager.ConnectionStrings[0].ConnectionString, ConfigurationManager.ConnectionStrings[0].ProviderName));
            });
        }
    }
}