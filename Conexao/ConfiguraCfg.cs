using System.Linq;
using Configuration = NHibernate.Cfg.Configuration;

namespace ProjetoBaseComBanco.Conexao
{
    public class ConfiguraCfg
    {
        private static Configuration cfgClasseTest;
        public static string DataSource;
        public static string Login;
        public static string PassWord;
        public static string Server;

        public static Configuration AtualizarConfigurationCfg(Configuration cfg)
        {
            cfgClasseTest = cfg;

            Configuration retorno = new Configuration();

            if (cfg.Properties.Count == 0)
            {
                return retorno;
            }

            AtualizandoDadosConexaoDatase(
                cfgClasseTest != null && cfgClasseTest.Properties.Count != 0
                    ? cfgClasseTest
                    : cfg,
                retorno);

            return retorno;
        }

        private static void AtualizandoDadosConexaoDatase(Configuration cfg, Configuration retorno)
        {
            foreach (var item in cfg.Properties)
            {
                //if (item.Key.Equals("connection.connection_string"))
                //{
                //    Atualizar(item.Value);
                //    //retorno.Properties.Add(item.Key, string.Format("Data Source={0};User ID={1};Password={2};", DataSource, ID, PassWord));
                //    //retorno.Properties.Add(item.Key, string.Format("Server={0};Database={1};User Id={2};Password={3};",Server, DataSource, Login, PassWord));
                //    var teste = retorno;
                //}
                //else
                //{
                //    if (!retorno.Properties.Any(w => w.Key.Equals(item.Key)))
                //        retorno.Properties.Add(item);
                //}
            }
        }

        private static void Atualizar(string texto)
        {
            var valor = texto.Split('=', ';');

            Server = valor[1].ToString();
            DataSource = valor[3].ToString();
            Login = valor[5].ToString();
            PassWord = valor[7].ToString();
        }
    }
}
