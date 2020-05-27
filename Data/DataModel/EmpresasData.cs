﻿namespace ProjetoBaseComBanco.Data.DataModel
{
    public class EmpresasData : DataModel
    {      
        public virtual string Nome { get; set; }

        public virtual string Pais { get; set; }

        public virtual int Ano { get; set; }

        public virtual decimal Balanco { get; set; }
    }
}
