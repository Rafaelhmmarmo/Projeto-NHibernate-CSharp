using FluentNHibernate.Mapping;
using ProjetoBaseComBanco.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseComBanco.Data.Mappings
{
    public class EmpresaMap : ClassMap<EmpresasData>
    {
        public EmpresaMap()
        {
            Table("EMPRESAS");

            Id(m => m.Id, "ID");
            Map(m => m.Nome, "NOME");
            Map(m => m.Pais, "PAIS");
            Map(m => m.Ano, "ANO");
        }
    }
}
