using ProjetoBaseComBanco.Conexao;
using ProjetoBaseComBanco.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBaseComBanco.Data.Repositories
{
    public class EmpresaRepository : DataBase
    {
        public IList<EmpresasData> RetornarTodas()
        {
            var session = GetSessionLocal();
            var resultado = session.Query<EmpresasData>().ToList();
            session.Close();
            return resultado;
        }
    }
}
