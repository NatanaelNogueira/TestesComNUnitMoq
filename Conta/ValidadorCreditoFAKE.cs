﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    public class ValidadorCreditoFAKE : IValidadorCredito
    {
        public bool ValidarCredito(string cpf,decimal valor)
        {
            //Não acessa nenhum webservice
            return true;
        }
    }
}
