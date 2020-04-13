using _3Bank.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Bank.Relatorios
{
    public class TotalizadorDeContas
    {
        public double SaldoTotal { get; set; }

        public void Adiciona(Conta c)
        {
            this.SaldoTotal += c.Saldo;
        }
    }
}
