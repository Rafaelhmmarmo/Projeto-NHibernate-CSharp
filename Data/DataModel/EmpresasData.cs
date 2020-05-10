using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseComBanco.Data.DataModel
{
    public class EmpresasData
    {
        public EmpresasData() { }

        public EmpresasData(int id, string nome, string pais)
        {
            Id = id;
            Nome = nome;
            Pais = pais;
        }

        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Pais { get; set; }
    }
}
