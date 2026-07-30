namespace ScBank
{
    public class Conta
    {
        //atributos
        public int Numero { get;  set; }
        public Cliente Titular { get; set; }
        private decimal saldo;

        private List<Transacao> transacoes = new List<Transacao>();
        
        //construtor
        public Conta()
        {
            Numero = new Random().Next();
        }
        public Conta(Cliente titular)
        {
            Titular = titular;
            Numero = new Random().Next();
        }

        //métodos
        public void Depositar(decimal valor)
        {
            transacoes.Add(new Transacao(valor, "Depósito"));
            saldo += valor;
        }
        public void Sacar(decimal valor)
        {
            if (valor > saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque.");
            }
            Transacao saque = new Transacao(valor, "Saque");
            transacoes.Add(saque);
            saldo -= valor;
        }
        public decimal ObterSaldo()
        {
            return saldo;
        }
        public void ImprimirTransacoes()
        {
            Console.WriteLine("Transações:");
            foreach (var transacaoObj in transacoes)
            {
                transacaoObj.ImprimirTransacao();
            }
        }

        public void imprimirExtrato()
        {
            Titular.Imprimir();
            Console.WriteLine("================================");
            Console.WriteLine($"Número da conta: {Numero}");
            Console.WriteLine($"Titular: {Titular.Nome}");
            Console.WriteLine($"CPF: {Titular.Cpf}");
            Console.WriteLine($"Saldo: {saldo:C}");
            ImprimirTransacoes();
            Console.WriteLine("================================");

        }
    }
}