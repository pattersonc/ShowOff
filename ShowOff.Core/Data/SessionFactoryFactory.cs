using System.Configuration;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration=NHibernate.Cfg.Configuration;

namespace ShowOff.Core.Data
{
    public static class SessionFactoryFactory
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;

        private static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ShowOffConnectionString"].ConnectionString; }
        }

        private static Configuration Configuration
        {
            get
            {
                if(_configuration == null)
                    _configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString))
                    .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildConfiguration();

                return _configuration;
            }
        }

        public static ISessionFactory GetSessionFactory()
        {
            if(_sessionFactory == null)
                _sessionFactory = Configuration.BuildSessionFactory();

            return _sessionFactory;
        }

        public static void DropSchema()
        {
            
            new SchemaExport(Configuration).Drop(false, true);
        }

        public static void CreateSchema()
        {
            new SchemaExport(Configuration).Create(false, true);
        }

        public static void ExportMapping()
        {
            ////Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString))
            ////    .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()).ExportTo("c:\temp\mappings")).BuildConfiguration();
        }
    }
}