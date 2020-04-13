using _3Bank.Exceptions;
using _3Bank.Negocio;
using _3Bank.Relatorios;
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
    public partial class Form1 : Form
    {
        private List<Conta> contas;
        public List<Conta> GetComboContas()
        {
            return contas;
        }
        public double GetTxtValor()
        {
            return Convert.ToInt32(txtValor);
        }
        public Form1()
        {
            InitializeComponent();
        }

        public void AdicionaContas(Conta conta)
        {
            this.contas.Add(conta);
            comboContas.Items.Add(conta.Titular.Nome);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.contas = new List<Conta>();

            AdicionaContas(new ContaCorrente(new Cliente("João"), "Conta Corrente"));
            AdicionaContas(new ContaCorrente(new Cliente("Mauricio"), "Conta Corrente"));
            AdicionaContas(new ContaPoupanca(new Cliente("Fernando"), "Conta Poupança"));
        }

        private void BtnSacar_Click(object sender, EventArgs e)
        {
            Conta contaSelecionada = SelecionarConta();
            try
            {
                double valorSaque = Convert.ToDouble(txtValor.Text);
                contaSelecionada.Saca(valorSaque);
                MessageBox.Show("Saque efetuado com sucesso.", "Sucesso");
                txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
            }
            catch (SaldoInsuficienteException)
            {
                MessageBox.Show("Saldo insuficiente!", "Alerta!!!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe um valor válido.", "Alerta!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("Informe um valor válido.", "Alerta!!!");
            }
        }

        private void BtnDepositar_Click(object sender, EventArgs e)
        {
            Conta contaSelecionada = SelecionarConta();
            try
            {
                double valorDeposito = Convert.ToDouble(txtValor.Text);
                contaSelecionada.Deposita(valorDeposito);
                txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
                MessageBox.Show("Depósito efetuado com sucesso.","Sucesso");
            }
            catch (FormatException)
            {
                MessageBox.Show("Argumento válido.", "Alerta!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("Informe um valor válido.", "Alerta!!!");
            }
        }

        private void BtnTotalizador_Click(object sender, EventArgs e)
        {
            TotalizadorDeContas totalizador = new TotalizadorDeContas();
            foreach(var item in contas)
            {
                totalizador.Adiciona(item);
            }
            MessageBox.Show($"O saldo das contas é {totalizador.SaldoTotal}");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public Conta SelecionarConta()
        {
            int indice = Convert.ToInt32(comboContas.SelectedIndex);
            return contas[indice];
        }

        private void ComboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conta contaSelecionada = SelecionarConta();
            txtNumero.Text = Convert.ToString(contaSelecionada.Numero);
            txtNome.Text = contaSelecionada.Titular.Nome;
            txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
            txtTipoConta.Text = contaSelecionada.TipoDeConta;
        }

        private void BtnTransferir_Click(object sender, EventArgs e)
        {
            Conta contaSelecionada = SelecionarConta();
            try
            {
                double valorTransferencia = Convert.ToDouble(txtValor.Text);
                FormTransferir formTransferir = new FormTransferir(this, valorTransferencia);
                formTransferir.ShowDialog();
                MessageBox.Show("Transferencia efetuada com sucesso.", "Sucesso");
                txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
            }
            catch (SaldoInsuficienteException)
            {
                MessageBox.Show("Saldo insuficiente!", "Alerta!!!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe um valor válido.", "Alerta!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("Informe um valor válido.", "Alerta!!!");
            }

        }

        private void BtnNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro(this);
            formCadastro.ShowDialog();
        }

        private void BtnImpostos_Click(object sender, EventArgs e)
        {
            TotalizadorDeTributos totalizadorDeTributos = new TotalizadorDeTributos();
            foreach (var item in contas)
            {
                ContaCorrente contaCorrente = (ContaCorrente)item;
                totalizadorDeTributos.Adiciona(contaCorrente);
            }

            MessageBox.Show($"Total de Impostos = {totalizadorDeTributos.Total}");
        }
    }
}
