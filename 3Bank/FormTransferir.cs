using _3Bank.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Bank
{
    public partial class FormTransferir : Form
    {
        public Form1 FormPrincipal { get; set; }
        public double ValorTransferencia { get; set; }
        List<Conta> contas;
        public FormTransferir(Form1 formprincipal, double valorTransferencia)
        {
            this.FormPrincipal = formprincipal;
            InitializeComponent();
            contas = FormPrincipal.GetComboContas();
            this.ValorTransferencia = valorTransferencia;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Conta SelecionarContaDestino()
        {
            int indice = Convert.ToInt32(comboContasTransferir.SelectedIndex);
            return contas[indice];
        }

        private void BtnTransferir_Click(object sender, EventArgs e)
        {
            FormPrincipal.SelecionarConta().Transfere(ValorTransferencia, SelecionarContaDestino());
            this.Close();
            //double valorTransferencia = Convert.ToDouble(txtValor.Text);
            //if (contaSelecionada.Transfere(valorTransferencia, contaDestinoSelecionada))
            //{
            //    txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
            //    MessageBox.Show("Saque efetuado com sucesso.", "Sucesso");
            //}
            //else
            //{
            //    MessageBox.Show("Saldo insuficiente!", "Alerta!!!");
            //}
        }

        private void FormTransferir_Load(object sender, EventArgs e)
        {
            foreach(var item in contas)
            {
                if(!item.Numero.Equals(FormPrincipal.SelecionarConta().Numero))
                comboContasTransferir.Items.Add(item.Titular.Nome);
            }
        }
    }
}

