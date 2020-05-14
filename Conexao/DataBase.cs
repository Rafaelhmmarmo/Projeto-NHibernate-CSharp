using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;
using Configuration = NHibernate.Cfg.Configuration;

namespace ProjetoBaseComBanco.Conexao
{
    public class DataBase
    {
        private static ISessionFactory _sessionFactory;

        public static ISession GetSessionLocal()
        {
            return SessionFactory.OpenSession();
        }

        public static void GeraSchema()
        {
            Configuration cfg = 
                RecuperaConfiguracao();

            var config = 
                RecuperaFluent(cfg);

            config
                .ExposeConfiguration(ass => new SchemaExport(ass)
                .Create(true, true))
                .BuildConfiguration();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                try
                {
                    if (_sessionFactory != null) return _sessionFactory;

                    var cfg = RecuperaConfiguracao();

                    _sessionFactory = RecuperaFluent(cfg).BuildSessionFactory();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Configuração de acesso ao banco inválida. " + ex.Message);
                    throw ex;
                }

                return _sessionFactory;
            }
        }

        private static FluentConfiguration RecuperaFluent(Configuration cfg)
        {
            var config = Fluently.Configure(cfg);

            try
            {
                var map = Assembly.Load("ProjetoBaseComBanco");

                if (map != null)
                    config.Mappings(m => m.FluentMappings.AddFromAssembly(map));

                return config;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }      

        private static Configuration RecuperaConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg;
        }          
    }
}
