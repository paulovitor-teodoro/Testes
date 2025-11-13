using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC.Controller
{
    class AlunoController
    {
        private readonly ValidaService validaService;
        private readonly AlunoService alunoService;
        private readonly List<Aluno> alunos;

        //Construtor
        public AlunoController()
        {
            validaService = new ValidaService();
            alunoService = new AlunoService();
            alunos = new List<Aluno>();
        }

        public bool AdicionaAluno(Aluno aluno, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            if (!validaService.ValidaNome(aluno.Nome, out string erroNome))
            {
                mensagemErro = $"Nome inválido {erroNome}";
                return false;
            }

            aluno.Media = alunoService.CalcularMedia(aluno.Nota1, aluno.Nota2, aluno.Nota3);

            aluno.Situacao = alunoService.ObterSituacao(aluno.Media);

            alunos.Add(aluno);
            return true;
        }
        //Expressão Lambda;
        public IReadOnlyList<Aluno> ObterAlunos() => alunos.AsReadOnly();

        public double ObterTaxaAprovacao()
        {
            int totalAlunos = alunos.Count;
            int totalAprovados = alunos.FindAll(a => a.Situacao == "Aprovado").Count;
            return alunoService.CalcularTaxaAprovacao(totalAlunos, totalAprovados);
        }

        public ValidaService GetValidaService() => validaService;
    }
}
