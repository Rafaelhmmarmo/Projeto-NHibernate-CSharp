using NHibernate;
using ProjetoBaseComBanco.Conexao;
using ProjetoBaseComBanco.Data.DataModel;
using System.Collections.Generic;
using System.Linq;

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

        public EmpresasData RetornarPorId(int id)
        {
            var session = GetSessionLocal();

            var resultado = session
                .Query<EmpresasData>()
                .Where(w => w.Id == id)
                .ToList();

            session.Close();
            return resultado.FirstOrDefault();
        }

        private EmpresasData RetornarPorId(int id, ISession session)
        {
            var resultado = session
                .Query<EmpresasData>()
                .Where(w => w.Id == id)
                .ToList();

            return resultado.FirstOrDefault();
        }

        public bool ExcluirPorId(int id)
        {
            var session = GetSessionLocal();
            var objeto = RetornarPorId(id, session);
            var trans = session.BeginTransaction();

            try
            {
                session.Delete(objeto);
                trans.Commit();
                session.Close();
                return true;
            }
            catch
            {
                trans.Rollback();
                session.Close();
                return false;
            }
        }

        public bool Gravar(EmpresasData objeto)
        {
            var session = GetSessionLocal();
            var trans = session.BeginTransaction();

            try
            {            
                session.Save(objeto);
                trans.Commit();
                session.Close();
                return true;
            }
            catch
            {
                trans.Rollback();
                session.Close();
                return false;
            }
        }
    }
}
