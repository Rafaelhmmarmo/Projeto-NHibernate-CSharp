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
            EmpresaRepository empresas = new EmpresaRepository();
            EmpresasData NovaEmpresa = new EmpresasData();

            NovaEmpresa.Nome = "Mojang";
            NovaEmpresa.Pais = "EUA";
            NovaEmpresa.Ano = 2012;

            empresas.Gravar(NovaEmpresa);

            //DataBase.GeraSchema();


            
            var geralzao = empresas.RetornarTodas();

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
