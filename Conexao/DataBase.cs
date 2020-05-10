using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Reflection;
using Configuration = NHibernate.Cfg.Configuration;

namespace ProjetoBaseComBanco.Conexao
{
    public class DataBase
    {
        private static ISessionFactory _sessionFactory;
    
        private static ISessionFactory SessionFactory
        {
            get
            {
                try
                {
                    if (_sessionFactory != null) return _sessionFactory;

                    var cfg = new Configuration()
                        .Configure();

                    //var configuraCfg = ConfiguraCfg.AtualizarConfigurationCfg(cfg);

                    //cfg.Properties = configuraCfg.Properties;

                    if (_sessionFactory == null)
                    {
                        var config = Fluently.Configure(cfg);

                        AddMappings(config, "ProjetoBaseComBanco");

                        _sessionFactory = config
                            /* .ExposeConfiguration(ass =>
                             {
                                 SchemaExport schemaExport = new SchemaExport(ass);
                             })*/
                            .BuildSessionFactory();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Configuração de acesso ao banco inválida. " + ex.Message);
                    throw ex;
                }

                return _sessionFactory;
            }
        }

        private static void AddMappings(FluentConfiguration config, string assembly)
        {
            try
            {
                var map = Assembly.Load(assembly);

                if (map != null)
                    config.Mappings(m => m.FluentMappings.AddFromAssembly(map));

            }
            catch
            {
            }
        }

        public static ISession GetSessionLocal()
        {
            return SessionFactory.OpenSession();
        }
    }
}
