using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    public interface IValidadorCredito
    {
        bool ValidarCredito(string cpf,decimal valor);
    }
}
