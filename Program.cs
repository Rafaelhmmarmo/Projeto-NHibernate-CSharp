using ProjetoBaseComBanco.Conexao;
using ProjetoBaseComBanco.Data.Repositories;
using System;

namespace ProjetoBaseComBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpresaRepository empresas = new EmpresaRepository();

            DataBase.GeraSchema();
            
            var geralzao = empresas.RetornarTodas();

            foreach(var item in geralzao)
            {
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Pais);
            }

            int id = 20;

            var teste = empresas.RetornarPorId(id);

            Console.ReadLine();
        }
    }
}
