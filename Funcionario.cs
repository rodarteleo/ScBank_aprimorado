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
        public override void Preencher()
        {
            Console.WriteLine("Cadastro de Funcionario");
            PreencherPai();
            Console.WriteLine("Digite a Função: ");
            Funcao = Console.ReadLine();
        }

        public override void Imprimir()
        {
            ImprimirPai();
            Console.WriteLine("Matricula: "+ NumeroMatricula);
            Console.WriteLine("Funcao: "+ Funcao);            
        }
    }
}