using _3Bank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Bank.Relatorios
{
    public class TotalizadorDeTributos
    {
        public double Total { get; set; }

        public void Adiciona(ITributavel t)
        {
            this.Total += t.CalculaTributos();
        }
    }
}
