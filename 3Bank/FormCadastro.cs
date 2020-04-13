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
    public partial class FormCadastro : Form
    {
        public Form1 FormPrincipal { get; set; }
        public FormCadastro(Form1 formprincipal)
        {
            this.FormPrincipal = formprincipal;
            InitializeComponent();
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            comboTipoConta.Items.Add("Conta Corrente");
            comboTipoConta.Items.Add("Conta Poupança");

            txtNumero.Text = Convert.ToString(Conta.numeroDeContas);
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            Conta conta;
            var titular = new Cliente(txtNome.Text);
            var tipoConta = comboTipoConta.Text;
            if (tipoConta == "Conta Corrente")
            {
                conta = new ContaCorrente(titular, tipoConta);
                this.FormPrincipal.AdicionaContas(conta);
            }
            else if (tipoConta == "Conta Poupança")
            {
                conta = new ContaPoupanca(titular, tipoConta);
                this.FormPrincipal.AdicionaContas(conta);
            }
            MessageBox.Show("Conta cadastrada com sucesso.");
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
