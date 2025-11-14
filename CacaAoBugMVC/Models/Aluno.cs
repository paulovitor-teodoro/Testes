using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacaAoBugMVC.Models
{
        public class Aluno
        {
            public string Nome { get; set; } = string.Empty;
            public double Nota1 { get; set; }
            public double Nota2 { get; set; }
            public double Nota3 { get; set; }
            public double Media { get; set; }
            public string Situacao { get; set; } = string.Empty;
        }    
}
