using ProjetoBaseComBanco.Conexao;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBaseComBanco.Data.Repositories
{
    public class Repository : DataBase
    {
        public IList<object> RetornarTodas(object obejeto)
        {         
            var session = GetSessionLocal();
            var resultado = session.Query<object>().ToList();
            session.Close();
            return resultado;
        }
    }
}
