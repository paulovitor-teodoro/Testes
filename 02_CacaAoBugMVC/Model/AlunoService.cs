using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC.Model
{
    class AlunoService
    {
        public double CalcularMedia(double n1, double n2, double n3)
        {
            return (n1 + n2 + n3) / 3;
        }
        public string ObterSituacao(double media)
        {
            if(media >= 7)
                    return "Aprovado";
            else if (media >= 5)
                    return "Em Exame Final";
            else
                    return "Reprovado";


            
        }
        public double CalcularTaxaAprovacao(int totalAlunos, int alunosaAprovados)
        {
            //Transforma a variavel do tipo int para double utilizando casting
            return (alunosaAprovados/(double) totalAlunos) * 100.0;
        }

    }
}
