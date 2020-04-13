namespace _3Bank.Negocio
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente()
        {
            string[] teste = new string[2];
            int numero = teste.Length;
        }
    }
}