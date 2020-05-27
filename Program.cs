using ProjetoBaseComBanco.Conexao;
using ProjetoBaseComBanco.Data.DataModel;
using ProjetoBaseComBanco.Data.Repositories;
using System;
using System.Linq;

namespace ProjetoBaseComBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            // exemplo de funcionamento

            EmpresaRepository empresas = new EmpresaRepository();
            EmpresasData NovaEmpresa = new EmpresasData();

            NovaEmpresa.Nome = "Itau";
            NovaEmpresa.Pais = "Brasil";
            NovaEmpresa.Ano = 1960;
            NovaEmpresa.Balanco = 100;

            DataBase.GeraSchema();

            empresas.Gravar(NovaEmpresa);
          
            var geralzao = empresas.RetornarTodos();

            foreach(var item in geralzao)
            {
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Pais);
                Console.WriteLine("----------");
            }

            empresas.ExcluirPorId(geralzao.FirstOrDefault().Id);

            Console.ReadLine();
        }
    }
}
