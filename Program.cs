using ScBank;

Cliente clienteObjeto = new Cliente();
clienteObjeto.Preencher();
clienteObjeto.Imprimir();

var contaDoArthur = new Conta("Arthur");

contaDoArthur.Depositar(1000);
contaDoArthur.Sacar(500);
contaDoArthur.imprimirExtrato();

var contaDaMaria = new Conta("Maria");
contaDaMaria.Depositar(2000);
contaDaMaria.Sacar(500);
contaDaMaria.imprimirExtrato();

//isso é uma fraude não pode ser feito, pois o saldo é privado e não pode ser acessado diretamente
//contaDoArthur.Saldo = 100000000000; 

// quero obter o saldo da conta do Arthur, mas não posso acessar diretamente, então vou criar um método para isso
var saldoContaDoArthur = contaDoArthur.ObterSaldo();
Console.WriteLine($"Saldo da conta do Arthur: {saldoContaDoArthur:C}");


contaDoArthur.Depositar(5000);
contaDoArthur.imprimirExtrato();


var contaDoJoao = new Conta();
contaDoJoao.Titular = "João";

contaDoJoao.imprimirExtrato();