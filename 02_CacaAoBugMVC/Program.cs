using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC
{
    internal class Program
    {
        //Passagem de Parâmetros por Valor e por Referência, usando REF, OUT e IN;
        // Ref - Passagem por referência, permitindo que o método modifique o valor do parâmetro original.
        // Out - Passagem por referência, usado para retornar múltiplos valores de um método.
        // In - Permite que o método leia o valor do parâmetro, mas não o modifique.
        //Valor - Passagem por valor, onde uma cópia do valor é passada para o método.
        static void Main(string[] args)
        {
            Console.WriteLine("***** Passagem de Parâmetros por Valor  *****");
            //Passa o conteúdo da variável de Origem para a variável de Destino
            // O método de Destino não pode alterar o valor da variável de Origem
            double valor = 10;
            if (PassagemParametroValor(valor))
            Console.WriteLine($"Valor do método Main -> PassagemParametroValor {valor}");

            Console.WriteLine("***** Passagem de Parâmetros por Referência REF  *****");
            //Passa o endereço de memória da variável de Origem para a variável de Destino
            //O variável de origem deve ser inicializada antes de ser passada como parâmetro
            // O método de Destino pode alterar o valor da variável de Origem
            double valor1 = 10;
            if (PassagemParametroReferenciaRef(ref valor1))
            {
                Console.WriteLine($"Valor do método Main -> PassagemParametroReferenciaRef {valor1}");
            }
            
            Console.WriteLine("***** Passagem de Parâmetros por Referência OUT  *****");
            //Passa o endereço de memória da variável de Origem para a variável de Destino
            //A variável de Origem não precisa ser inicializada antes de ser passada como parâmetro
            // O método de Destino deve atribuir um valor à variável de Origem antes de retornar
            // O método de Destino pode alterar o valor da variável de Origem
            double valor2;
            if (PassagemParametroReferenciaOut(out valor2))
            {
                Console.WriteLine($"Valor do método Main -> PassagemParametroReferenciaOut {valor2}");
            }
            
            Console.WriteLine("***** Passagem de Parâmetros por Referência IN  *****");
            double valor3 = 100;
            if (PassagemParametroReferenciaIN(in valor3))
            {
                Console.WriteLine($"Valor do método Main -> PassagemParametroReferenciaIN {valor3}");
            }
        }

        public static bool PassagemParametroValor(double valor)
        {
            valor = valor * 10;
            Console.WriteLine($"Valor do método PassagemParametroValor {valor}");
            return true;
        }

        public static bool PassagemParametroReferenciaRef(ref double valor1)
        {
            valor1 = valor1 * 10;
            Console.WriteLine($"Valor do método PassagemParametroReferenciaRef {valor1}");
            return true;
        } 
        public static bool PassagemParametroReferenciaOut(out double valor2)
        {
            valor2 = 10;
            valor2 = valor2 * 10;
            Console.WriteLine($"Valor do método PassagemParametroReferenciaOut {valor2}");
            return true;
        }
        public static bool PassagemParametroReferenciaIN(in double valor3)
        {
          
            Console.WriteLine($"Valor do método PassagemParametroReferenciaIN {valor3}");
            return true;
        }
    }
}
