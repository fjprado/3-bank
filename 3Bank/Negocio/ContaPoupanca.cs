using _3Bank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Bank.Negocio
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(Cliente titular, string tipoDeConta) : base(titular, tipoDeConta) {
        }

        public override bool Saca(double valor)
        {
            if (valor + 0.10 <= this.Saldo)
            {
                this.Saldo -= valor + 0.10;
                return true;
            }
            throw new SaldoInsuficienteException();
        }

        public override void Deposita(double valor)
        {
            if (valor < 0)
                throw new ArgumentException();
            this.Saldo += valor;
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




        //public override bool Saca(double valor)
        //{
        //    return base.Saca(valor + 0.10);
        //}

    }
}
