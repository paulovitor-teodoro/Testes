using CacaAoBugMVC.Models;


namespace _02_CacaAoBugMVC.Test
{
    [TestClass]
    public class AlunoServiceTests
    {
        [TestMethod]
        public void CalcularMedia_DeveRetornarValorCorreto()
        {
            // Arrange
           var service = new AlunoService();


            // Act 
            var resultado = service.CalcularMedia(8.0, 7.5, 6.5);


            // Assert
            Assert.AreEqual(7.33,resultado);
        }
        [TestMethod]
        public void CalcularMedia_DeveRetornarErro()
        {
            // Arrange
           var service = new AlunoService();


            // Act 
            var resultado = service.CalcularMedia(6.0, 5.5, 3.5);


            // Assert
            Assert.AreEqual(7.33,resultado);
        }

    }

    [TestClass]
    public class ObterSituacaoTests
    {
        [TestMethod]
        public void ObterSituacao_DeveRetornarCorreto()
        {
            //Arrange
            var service = new AlunoService();

            //Act
            var resultadoAprovado = service.ObterSituacao(7.5);
            var resultadoExameFinal = service.ObterSituacao(6.0);
            var resultadoReprovado = service.ObterSituacao(4.0);

            //Assert
            Assert.AreEqual("Aprovado", resultadoAprovado);
            Assert.AreEqual("Em Exame Final", resultadoExameFinal);
            Assert.AreEqual("Reprovado", resultadoReprovado);
        }
    }

    [TestClass]
    public class CalcularTaxaAprovacaoTests
    {
        [TestMethod]
        public void CalcularTaxaAprovacao_DeveRetornarValorCorreto()
        {
            //Arrange
            var service = new AlunoService();

            //Act
            var resultado = service.CalcularTaxaAprovacao(20, 15);

            //Assert
            Assert.AreEqual(75.0, resultado);
        }
    }

}
