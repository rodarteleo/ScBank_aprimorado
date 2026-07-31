namespace ScBank
{
    //Modificador anbstract impede que seja possivel gerar instancias desta classe sendo assim ficara somente como uma classe para referencia de heranca.
    public abstract class Pessoa()
    {
        public string Nome { get; set; }
        //modificador protected funciona similar ao private porem ele garante que o filho consiga realizar o acesso
        public string Cpf { get; protected set; } 
        public string Telefone { get; set; }
        public string Email { get; set; }

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
        protected bool ValidarCpf(string cpf)
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

        public abstract void Preencher();
        public abstract void Imprimir(); 

        protected void PreencherPai()
        {
            Console.Write("Digite o nome: ");
            Nome = Console.ReadLine();
            Console.Write("Digite o telefone: "); 
            Telefone = Console.ReadLine();

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
        protected void ImprimirPai()
        {
            Console.WriteLine("\n\n-----------------------");
            Console.WriteLine("Nome: " +Nome);
            Console.WriteLine("Cpf: "+ Cpf);
            Console.WriteLine("Telefone: "+ Telefone);
            Console.WriteLine("Email: "+ Email);
        }
    }
}