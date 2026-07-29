using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScBank
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get;private set; } // Propriedade privada para armazenar o CPF do cliente
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        
        private bool ValidarCpf(string cpf)
        {
          
            string Cpf = cpf; // Atribui o valor do CPF da instância à variável local
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
            
        
        public bool ValidarEmail(string email)
        {
            // Implementação da validação do email
            // Retorna true se o email for válido, caso contrário, retorna false
            return Email.Contains("@"); // Exemplo de retorno
        }
        public void Preencher()
        {
            // Implementação do preenchimento dos dados do cliente
            // Pode ser feito através de prompts, formulários, etc.
            Console.WriteLine("Digite o nome do cliente:");
            Nome = Console.ReadLine();

            Console.WriteLine("Digite o telefone do cliente:");
            Telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do cliente:");
            Endereco = Console.ReadLine();

            Console.WriteLine("Digite o email do cliente:");
            Email = Console.ReadLine();
            while (!ValidarEmail(Email))
            {
                Console.WriteLine("Email inválido! Digite novamente.");
                Email = Console.ReadLine();
                
            }

            Console.WriteLine("Digite o CPF do cliente:");
            Cpf = Console.ReadLine();
            while (!ValidarCpf(Cpf))
            {
                Console.WriteLine("CPF inválido! Digite novamente.");
                Cpf = Console.ReadLine();
            }   
        }
        public void Imprimir()
        {
            Console.WriteLine("\n\n=============================");
            Console.WriteLine("Dados do Cliente:");
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("CPF: " + Cpf);
            Console.WriteLine("Endereço: " + Endereco);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("=============================\n\n");
        }
}
}

