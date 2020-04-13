using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Bank.Negocio
{
    public abstract class Conta
    {
        #region Propriedades
        public int Numero { get; set; }
        public double Saldo { get; protected set; }
        public Cliente Titular { get; set; }
        public string TipoDeConta { get; set; }
        public static int numeroDeContas = 1;
        #endregion
        public Conta()
        {
            this.Numero = numeroDeContas;
            numeroDeContas++;
        }
        public Conta(Cliente titular, string tipoDeConta)
        {
            this.Numero = numeroDeContas;
            this.Titular = titular;
            this.TipoDeConta = tipoDeConta;
            numeroDeContas++;
        }

        #region Métodos
        public abstract bool Saca(double valor);


        public abstract void Deposita(double valor);

        public abstract bool Transfere(double valorTransferencia, Conta contaDestino);

        public static int NumeroDaProximaConta()
        {
            return numeroDeContas + 1;
        }

        #endregion
    }
}
