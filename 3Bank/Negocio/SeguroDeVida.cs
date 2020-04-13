using _3Bank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Bank.Negocio
{
    public class SeguroDeVida : ITributavel
    {
        public double CalculaTributos()
        {
            return 42;
        }
    }
}
