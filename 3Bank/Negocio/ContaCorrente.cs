using _3Bank.Contratos;
using _3Bank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Bank.Negocio
{
    public class ContaCorrente : Conta, ITributavel
    {
        public ContaCorrente()
        {
        }

        public ContaCorrente(Cliente titular, string tipoDeConta) : base(titular, tipoDeConta) { }

        public double CalculaTributos()
        {
            return this.Saldo * 0.05;
        }

        public override void Deposita(double valor)
        {
            if (valor < 0)
                throw new ArgumentException();
            this.Saldo += valor - 0.10;
        }

        public override bool Saca(double valor)
        {
            if (valor < 0)
                throw new ArgumentException();
            if (valor + 0.05 <= this.Saldo)
            {
                this.Saldo -= valor + 0.05;
                return true;
            }
            throw new SaldoInsuficienteException();
        }

        public override bool Transfere(double valorTransferencia, Conta contaDestino)
        {

            if (this.Saca(valorTransferencia))
            {
                contaDestino.Deposita(valorTransferencia);
                return true;
            }
            return false;
        }
    }
}
