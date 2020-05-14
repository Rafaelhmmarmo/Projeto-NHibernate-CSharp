using ProjetoBaseComBanco.Conexao;
using ProjetoBaseComBanco.Data.DataModel;
using System;
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

        public bool ExcluirPorId(int id)
        {
            var retorno = false;
            var session = GetSessionLocal();
            var xxx = RetornarPorId(id);
            var trans = session.BeginTransaction();

            try
            {
                session.Delete(xxx);
                trans.Commit();
                retorno = true;
            }
            catch
            {
                trans.Rollback();
            }
            session.Close();
            return retorno;
        }

        public EmpresasData Gravar(EmpresasData produto)
        {
            var session = GetSessionLocal();
            var trans = session.BeginTransaction();

            try
            {
                var existe = RetornarPorId(produto.Id) != null;

                if (existe)
                {
                    session.Update(produto);
                }
                else
                {
                    session.Save(produto, produto.Id);
                }
                trans.Commit();

            }
            catch (Exception)
            {
                trans.Rollback();
            }
            return RetornarPorId(produto.Id);
        }

    }
}
