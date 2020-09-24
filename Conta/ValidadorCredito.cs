using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    public class ValidadorCredito : IValidadorCredito
    {
        private readonly string cpf;

        public ValidadorCredito(string cpf)
        {
            this.cpf = cpf;
        }


        public bool ValidarCredito(string cpf,decimal valor)
        {
            bool StatusSearasa = VerificarSituacaoSearsa(cpf);
            bool StatusSPC = VerificarSituacaoSPC(cpf);

            return (StatusSearasa && StatusSPC);
        }

        private bool VerificarSituacaoSearsa(string cpf)
        {
            //Chamada WebService p/ Verificar situação Serada
            return true;
        }

        private bool VerificarSituacaoSPC(string cpf)
        {
            //Chamada WebService p/ Verificar situação Serada
            return true;
        }

    }
}
