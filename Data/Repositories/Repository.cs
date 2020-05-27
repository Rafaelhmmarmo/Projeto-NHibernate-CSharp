using NHibernate;
using ProjetoBaseComBanco.Conexao;
using ProjetoBaseComBanco.Data.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBaseComBanco.Data.Repositories
{
    public class Repository<TDataModel> where TDataModel : DataBaseModel
    {
        public IList<TDataModel> RetornarTodos()
        {           
            var session = DataBase.GetSessionLocal();
            var resultado = session.Query<TDataModel>().ToList();
            session.Close();
            return resultado;
        }

        public TDataModel RetornarPorId(int id)
        {
            var session = DataBase.GetSessionLocal();

            var resultado = session
                .Query<TDataModel>()
                .Where(w => w.Id == id)
                .ToList();

            session.Close();
            return resultado.FirstOrDefault();
        }

        private TDataModel RetornarPorId(int id, ISession session)
        {
            var resultado = session
                .Query<TDataModel>()
                .Where(w => w.Id == id)
                .ToList();

            return resultado.FirstOrDefault();
        }

        public bool ExcluirPorId(int id)
        {
            var session = DataBase.GetSessionLocal();
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

        public bool Gravar(TDataModel objeto)
        {
            var session = DataBase.GetSessionLocal();
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

        public bool Update(TDataModel objeto)
        {
            var session = DataBase.GetSessionLocal();
            var trans = session.BeginTransaction();

            try
            {
                session.Update(objeto);
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
