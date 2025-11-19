using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacaAoBugMVC.Models;

namespace _02_CacaAoBugMVC.Test
{
    [TestClass]
    public class ValidaServiceTests
    {
        [TestMethod]
        public void ValidaNome_DeveRetornarTrue_QuandoNomeValido()
        {
            var service = new ValidacaoService();
            string erro;

            var resultado = service.ValidaNome("Ana Maria", out erro);

            Assert.IsTrue(resultado);
            Assert.AreEqual(string.Empty, erro);
        }

        [TestMethod]
        public void ValidaNome_DeveFalhar_QuandoNomeVazio()
        {
            var service = new ValidacaoService();
            string msgErro;

            var resultado = service.ValidaNome("", out msgErro);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Nome vazio.", msgErro);
        }

        [TestMethod]
        public void ValidaNome_DeveFalhar_QuandoMenosDeTresCaracteres()
        {
            var service = new ValidacaoService();
            string msgErro;

            var resultado = service.ValidaNome("Jo", out msgErro);

            Assert.IsFalse(resultado);
            Assert.IsTrue(msgErro.Contains("Mínimo 3 caracteres"));
        }

        [TestMethod]
        public void ValidaNome_DeveFalhar_QuandoTresLetrasIguaisConsecutivas()
        {
            var service = new ValidacaoService();
            string msgErro;

            var resultado = service.ValidaNome("Paaaulo", out msgErro);

            Assert.IsFalse(resultado);
            Assert.IsTrue(msgErro.Contains("Não pode ter 3 letras iguais seguidas"));
        }

        [TestMethod]
        public void ValidaNome_DeveFalhar_QuandoContemEspacosDuplos()
        {
            var service = new ValidacaoService();
            string msgErro;
            
            var resultado = service.ValidaNome("Paulo  Vitor", out msgErro);

            Assert.IsFalse(resultado);
            Assert.IsTrue(msgErro.Contains("Não pode ter espaços duplos"));
        }

        [TestMethod]
        public void ValidaNome_DeveFalhar_QuandoContemCaracteresInvalidos()
        {
            var service = new ValidacaoService();
            string erro;

            var resultado = service.ValidaNome("Paulo73", out erro);

            Assert.IsFalse(resultado);
            Assert.IsTrue(erro.Length > 0);
        }
    }

    [TestClass]
    public class TentarConverterNotaTests
    {
        [TestMethod]
        public void TentaConverterNota_DeveRetornarTrue_QuandoNotaValidaComVirgula()
        {
            var service = new ValidacaoService();
            double nota;

            var resultado = service.ConverteNota("7,5", out nota);

            Assert.IsTrue(resultado);
            Assert.AreEqual(7.5, nota, 0.01);
        }

        [TestMethod]
        public void TentaConverterNota_DeveRetornarTrue_QuandoNotaValidaComPonto()
        {
            var service = new ValidacaoService();
            double nota;

            var resultado = service.ConverteNota("8.3", out nota);

            Assert.IsTrue(resultado);
            Assert.AreEqual(8.3, nota, 0.01);
        }

        [TestMethod]
        public void TentarConverterNota_DeveFalhar_QuandoForaDoIntervalo()
        {
            var service = new ValidacaoService();
            double nota;

            var resultado = service.ConverteNota("12", out nota);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TentarConverterNota_DeveFalhar_QuandoTextoInvalido()
        {
            var service = new ValidacaoService();
            double nota;

            var resultado = service.ConverteNota("abc", out nota);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TentaConverterNota_DeveFalhar_QuandoOCampoEstiverVazio()
        {
            var service = new ValidacaoService();
            double nota;

            var resultado = service.ConverteNota("", out nota);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TentaConverterNota_DeveFalhar_QuandoFormatoNumericoIncorretoInserido()
        {
            var service = new ValidacaoService();
            double nota;

            var resultado = service.ConverteNota("7,,5", out nota);

            Assert.IsFalse(resultado);
        }
    }
}
