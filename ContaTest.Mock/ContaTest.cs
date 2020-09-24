using NUnit.Framework;
using Principal;
using Moq;
using System;

namespace ContaTestMock
{
    [TestFixture]
    public class ContaTest
    {

        [Test]
        public void tesstSolicitarEmprestimoFAKE()
        {
            Conta conta = new Conta("0001",100);

            conta.SetValidadorCredito(new ValidadorCreditoFAKE());

            bool resultado = conta.SolicitarEmprestimo(500);

            Assert.IsTrue(resultado);

        }

        [Test]
        public void tesstSolicitarEmprestimo()
        {

            Conta conta = new Conta("0001",100);

            var mock = new Mock<IValidadorCredito>();
            mock.Setup(x => x.ValidarCredito("0001",500)).Returns(true);
            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 600;

            conta.SolicitarEmprestimo(500);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);
        }

        [Test]
        public void tesstSolicitarEmprestimoSomenteValor()
        {

            Conta conta = new Conta("Ignora o valor passado por conta do metodo It.IsAny<string>()",200);

            var mock = new Mock<IValidadorCredito>();
            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(),400)).Returns(true);
            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 600;

            conta.SolicitarEmprestimo(400);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);

        }

        [Test]
        public void tesstSolicitarEmprestimoSomenteValorBaixo()
        {

            Conta conta = new Conta("Ignora o valor passado por conta do metodo It.IsAny<string>()",200);

            var mock = new Mock<IValidadorCredito>();
            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.Is<decimal>(i => i <= 600))).Returns(true);
            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 600;

            conta.SolicitarEmprestimo(400);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);

        }

        [Test]
        public void tesstSolicitarEmprestimoComException()
        {

            Conta conta = new Conta("0001",1000);

            var mock = new Mock<IValidadorCredito>();
            mock.Setup(x => x.ValidarCredito( It.IsAny<string>() , It.IsAny<decimal>() )).Throws<InvalidOperationException>();
            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 5100;

            conta.SolicitarEmprestimo(5000);

            Assert.IsFalse(conta.GetSaldo() == resultadoEsperado);
        }

        [Test]
        public void tesstSolicitarEmprestimoAcimaDoLimite()
        {

            Conta conta = new Conta("0001",100);
            var mock = new Mock<IValidadorCredito>();
            conta.SetValidadorCredito(mock.Object);

            bool resultado = conta.SolicitarEmprestimo(1200);

            mock.Verify(x => x.ValidarCredito(It.IsAny<string>(),It.IsAny<decimal>()),Times.Never());
            //mock.Verify(x => x.ValidarCredito(It.IsAny<string>(),It.IsAny<decimal>()),Times.Once);
            //mock.Verify(x => x.ValidarCredito(It.IsAny<string>(),It.IsAny<decimal>()),Times.Exactly(1));


        }

    }
}
