using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacaAoBugMVC.Controllers;
using CacaAoBugMVC.Models;

namespace CacaAoBugMVC
{
    internal class Program
    {
        
        static void Main()
        {
            AlunoController controller = new AlunoController();
            var validacao = controller.GetValidacaoService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Notas - Caça ao Bug MVC ===");
                string nome;
                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine("Informe o nome do Aluno: ");
                        nome = Console.ReadLine();
                        if (validacao.ValidaNome(nome, out string msgErro)) break;

                        Console.WriteLine($"Erro:\n{msgErro}\n");
                    }

                    double nota1 = Program.LerNota("1", validacao);
                    double nota2 = Program.LerNota("2", validacao);
                    double nota3 = Program.LerNota("3", validacao);

                    //---------Criar o objeto Aluno---------//
                    var aluno = new Aluno
                    {
                        Nome = nome,
                        Nota1 = nota1,
                        Nota2 = nota2,
                        Nota3 = nota3
                    };

                    if(controller.AdicionarAluno(aluno, out string msgErroAdd))
                    {
                        Console.WriteLine($"\nMédia: {aluno.Media}");
                        Console.WriteLine($"Situação: {aluno.Situacao}");
                    }
                    else
                    {
                        Console.WriteLine($"Erro: {msgErroAdd}");
                    }

                    Console.WriteLine("Deseja Cadastrar outro Aluno? (S/N)");
                    if (Console.ReadLine().ToUpper() != "S") break;
                }

                //----Estatísticas de Aprovação----//
                Console.WriteLine($"Taxa de Aprovação: {controller.ObterTaxaAprovacao():f2}%");

                Console.WriteLine("Deseja reiniciar o sistema? (S/N)");
                if (Console.ReadLine().ToUpper() != "S") break;
            }
        }

        public static double LerNota(string nota, ValidacaoService validacao)
        {
            while (true)
            {
                Console.WriteLine($"Informe a {nota} Nota: ");
                string entrada = Console.ReadLine();
                //return double.Parse(entrada);
                if(validacao.ConverteNota(entrada, out double valorNota)) return valorNota;

                Console.WriteLine("Nota inválida! Digite um valor entre 0 e 10");
            }
        }

    }
}      
