using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace kylo_renamer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"f:\";
            List<string> arquivos = Directory.GetFiles(path, "*.mp3").ToList();
            arquivos = arquivos.OrderBy(a => Guid.NewGuid()).ToList();
            int qtd = arquivos.Count;
            Console.WriteLine($"Arquivos .mp3 encontrados: {qtd}. Pressione uma tecla para iniciar...");
            Console.ReadKey();
            int parcial = 0;
            foreach(var arquivo in arquivos)
            {
                string nomeNovo = arquivo.Insert(3, Guid.NewGuid().ToString().Substring(0,6) + " ");
                Console.WriteLine($"#{++parcial} De: [{arquivo}] para [{nomeNovo}]");
                File.Move(arquivo, nomeNovo);                
            }
        }
    }
}
