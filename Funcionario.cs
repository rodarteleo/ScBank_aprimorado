namespace ScBank
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; private set; } 
        public int NumeroMatricula { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Funcionario()
        {
            NumeroMatricula = new Random().Next();
        }
        public bool ValidarEmail()
        {
            return Email.Contains('@');
        }
        public void SetCpf(string cpf)
        {
            if (ValidarCpf(cpf))
            {
                Cpf = cpf;
            }
            else
            {
                Console.WriteLine("CPF inválido. Não foi possível definir o CPF.");
            }
        }
        private bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
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