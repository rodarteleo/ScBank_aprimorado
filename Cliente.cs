

namespace ScBank
{
    public class Cliente() : Pessoa
    {
        public string End {  get;  set; }
      
        public override void Preencher()
        {
            Console.WriteLine("Cadastro de Cliente");
            PreencherPai();
            Console.WriteLine("Digite o Enderco: ");
            End = Console.ReadLine();
        }

        public override void Imprimir()
        {
            ImprimirPai();
            Console.WriteLine("Endereço: "+ End);
        }
    }
}