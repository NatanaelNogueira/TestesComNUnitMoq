using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    public class Conta
    {
        public String cpf { get; set; }
        public decimal saldo { get; set; }
        private IValidadorCredito validadorCredito;

        public Conta(string cpf,decimal saldo)
        {
            this.cpf = cpf;
            this.saldo = saldo;
            validadorCredito = new ValidadorCredito(cpf);
        }

        public void SetValidadorCredito(IValidadorCredito iValidadorCredito)
        {
            this.validadorCredito = iValidadorCredito;
        }

        public decimal GetSaldo()
        {
            return saldo;
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;
        }

        public bool Sacar(decimal valor)
        {

            if (valor <= 0)
            {
                //throw new ArgumentOutOfRangeException();
                return false;
            }

            if (saldo < valor)
            {
                return false;
            }

            this.saldo -= valor;
            return true;
        }


        public bool SolicitarEmprestimo(decimal valor)
        {
            bool resultado = false;

            if (valor >= this.saldo * 10)
            {
                return resultado;
            }


            try
            {
               resultado = validadorCredito.ValidarCredito(this.cpf,valor);
            }
            catch (InvalidOperationException)
            {
                return resultado;
            }

            if (resultado)
            {
                this.saldo += valor;
            }

            return resultado;

        }



    }
}
