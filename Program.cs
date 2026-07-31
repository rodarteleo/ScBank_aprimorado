﻿﻿using ScBank;


Funcionario funcionarioObj  = new Funcionario();
funcionarioObj.Preencher();
funcionarioObj.Imprimir();


Cliente clienteObj = new Cliente();
clienteObj.Preencher();

clienteObj.Imprimir();
// clienteObj.SetCpf("15678900");
// clienteObj.Imprimir();
// clienteObj.SetCpf("03903277002");
// clienteObj.Imprimir();


Cliente clienteObj2 = new Cliente();
clienteObj2.Preencher();
clienteObj2.Imprimir();


// Oq Funcionario.cs e Cliente.cs  Tem em comum? 
// São filhos de Pessoa.cs 

//quero criar uma lista de Clientes e de Funcionarios, como fazer ? 

//exemplo do uso de polimorfismo (a ideia central é usar o pai como referencia)
List<Pessoa> pessoas = new List<Pessoa>();
pessoas.Add(clienteObj);
pessoas.Add(clienteObj2);
pessoas.Add(funcionarioObj);

Pessoa pessoaCliente = clienteObj;
Pessoa pessoaFuncionario = funcionarioObj;

Cliente cliente2 = (Cliente)pessoaCliente;

Console.WriteLine("Endereco de cliente recuperado é " + cliente2.End);

Console.WriteLine("Matricula do funcionario é : "+ ((Funcionario)pessoaFuncionario).NumeroMatricula);

foreach (var pessoa in pessoas)
{
    pessoa.Imprimir();

    if ( pessoa.GetType() == typeof(Cliente))
    {
        Console.WriteLine($"{pessoa.Nome} é um cliente e tem o endereço: " + ((Cliente)pessoa).End);
    }
    else
    {
        Console.WriteLine($"{pessoa.Nome} Não é um cliente, é um funcionario e tem a matricula: " + ((Funcionario)pessoa).NumeroMatricula);
    }
}

//retornamos ao sistema bancario 

var contaDoClienteObj = new Conta(clienteObj, funcionarioObj);

contaDoClienteObj.Depositar(1000);
contaDoClienteObj.Sacar(500);
contaDoClienteObj.imprimirExtrato();

var contaDoClienteObj2 = new Conta(clienteObj2, funcionarioObj);
contaDoClienteObj2.Depositar(2000);
contaDoClienteObj2.Sacar(500);
contaDoClienteObj2.imprimirExtrato();

//isso é uma fraude não pode ser feito, pois o saldo é privado e não pode ser acessado diretamente
//contaDoArthur.Saldo = 100000000000; 

// quero obter o saldo da conta do Arthur, mas não posso acessar diretamente, então vou criar um método para isso
var saldoContaDoClienteObj = contaDoClienteObj.ObterSaldo();
Console.WriteLine($"Saldo da conta do {contaDoClienteObj.Titular.Nome}: {saldoContaDoClienteObj:C}");


contaDoClienteObj.Depositar(5000);
contaDoClienteObj.imprimirExtrato();