using NUnit.Framework;
using Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaTeste.NUnit
{
    [TestFixture]
    public class ContaTeste
    {
        Conta conta;

        [OneTimeSetUp]
        public void Setup()
        {
            conta = new Conta("0001",200);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //Codigo executado apos cada metodo
            conta = null;
        }

        [Test]
        [TestCase(120,true)]
        [TestCase(-120,false)]
        public void testSacar(int valor, bool resultadoEsperado)
        {
            bool resultado = conta.Sacar(valor);

            Assert.IsTrue(resultado == resultadoEsperado);
        }


        [Test]
        [TestCase(250)]
        public void testSacarSemSaldo(int valor)
        {           

            bool resultado = conta.Sacar(valor);

            Assert.IsFalse(resultado);

        }


        [Test]        
        [Category("Valores Inválidos")]
        public void testSacarValorNegativo()
        {

            bool resultado = conta.Sacar(-100);

            Assert.IsFalse(resultado);

            //Assert.Throws<ArgumentOutOfRangeException>(delegate { conta.Sacar(-100); });

            //Assert.Catch<Exception>(delegate { conta.Sacar(-100); });
        }

        [Test]
        [Category("Valores Inválidos")]
        [Ignore("Pular por agora")]
        public void testSacarValorZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { conta.Sacar(0); });
        }

    }
}
