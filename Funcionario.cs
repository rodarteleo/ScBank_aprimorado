namespace ScBank
{
    public class Funcionario : Pessoa
    {
        
        public int NumeroMatricula { get; set; }
        public string Funcao { get; set; }
      

        public Funcionario()
        {
            NumeroMatricula = new Random().Next();
        }
        public void Preencher()
        {
            Console.Write("Digite o nome do Funcionario: ");
            Nome = Console.ReadLine();
            Console.Write("Digite o telefone: "); 
            Telefone = Console.ReadLine();
            Console.WriteLine("Digite a Função: ");
            Funcao = Console.ReadLine();

            Console.WriteLine("Digite o email: ");
            Email = Console.ReadLine();

            while (!ValidarEmail())
            {
                Console.WriteLine("Email invalido Digite novamente: ");
                Email = Console.ReadLine();
            }


            Console.WriteLine("Digite Cpf");
            Cpf = Console.ReadLine();
            while (!ValidarCpf(Cpf))
            {
                Console.WriteLine("Cpf Inválido digite novamente:");
                Cpf = Console.ReadLine();
            }
        }

        public void Imprimir()
        {
            Console.WriteLine("\n\n-----------------------");
            Console.WriteLine("Nome: " +Nome);
            Console.WriteLine("Cpf: "+ Cpf);
            Console.WriteLine("Funcao: "+ Funcao);
            Console.WriteLine("Telefone: "+ Telefone);
            Console.WriteLine("Email: "+ Email);
            Console.WriteLine("----------------------\n\n");
            
        }
    }
}