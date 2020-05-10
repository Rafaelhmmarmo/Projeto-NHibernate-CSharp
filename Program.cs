using ProjetoBaseComBanco.Data.Repositories;
using System;

namespace ProjetoBaseComBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpresaRepository empresas = new EmpresaRepository();

            var geralzao = empresas.RetornarTodas();

            foreach(var item in geralzao)
            {
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Pais);
            }    

            Console.ReadLine();
        }
    }
}
