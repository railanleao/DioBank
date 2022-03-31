using DioBank;
using static System.Console;

List<Contas> ListarContas = new List<Contas>();

string opcaoDoUsuario = ObterOpcaoUsuario();
while(opcaoDoUsuario.ToUpper() != "X")
{
    switch(opcaoDoUsuario)
    {
        case "1" : 
        ListaConta();
        break;
        case "2" : 
        InserirConta();
        break;
        case "3" : 
        Transferir();
        break;
        case "4":
        Sacar();
        break;
        case "5":
        Depositar();
        break;
        case "C":
        Clear();
        break;
        default:
        throw new ArgumentOutOfRangeException();
    }
    ReadKey();
    opcaoDoUsuario = ObterOpcaoUsuario();
}
WriteLine("Obrigado por utilizar nossos serviços.");
ReadLine();

void Sacar()
{
    Write("Digite o número da conta (índice): ");
    int indiceDaConta = int.Parse(ReadLine());
    Write("Entre com o valor: ");
    double valorSaque = double.Parse(ReadLine());

    ListarContas[indiceDaConta].Sacar(valorSaque);
}

void Depositar()
{
    Write("Digite o número da conta (índice): ");
    int indiceDaConta = int.Parse(ReadLine());

    Write("Entre com o valor: ");
    double valorDeposito = double.Parse(ReadLine());

    ListarContas[indiceDaConta].Deposito(valorDeposito);
}

void Transferir()
{
    Write("Digite o número da conta origem(índice): ");
    int indiceOrigem = int.Parse(ReadLine());

    Write("Digite o número da conta Destino(índice): ");
    int indiceDestino = int.Parse(ReadLine());

    Write("Entre com o valor a ser transferido: ");
    double valorTransferencia = double.Parse(ReadLine());

    ListarContas[indiceOrigem].Transferir(valorTransferencia, ListarContas[indiceDestino]);
}

void InserirConta()
{
    WriteLine("Insira nova conta: ");
    WriteLine("Digite 1 para PF e 2 para PJ: ");
    double entradaTipoConta = double.Parse(ReadLine());

    WriteLine("Digite seu nome: ");
    string entradaNome = ReadLine();
    
    WriteLine("Seu saldo: ");
    double entradaSaldo = double.Parse(ReadLine());

    WriteLine("Entre com seu crédito: ");
    double entradaCredito = double.Parse(ReadLine());

    Contas novaConta = new Contas(tipoConta: (ETipoConta)entradaTipoConta, 
                                    saldo: entradaSaldo, credito: entradaCredito,
                                    nome: entradaNome);
    ListarContas.Add(novaConta);
}

async void ListaConta()
{
    WriteLine("Listar Contas Cadastradas: ");
    if (ListarContas.Count == 00)
    {
        WriteLine("Sem contas cadastradas!");
        return;
    }
    //operação contar contas
    for(int i = 0; i < ListarContas.Count; i++)
    {
        Contas conta = ListarContas[i];
        Write($"#{i} - ");
        WriteLine(conta);
    }
}

static string ObterOpcaoUsuario()
{
        WriteLine();
        WriteLine("DioBank seu banco teste!");
        WriteLine("Informe sua opção:");

        WriteLine("1- Listar Contas"); 
        WriteLine("2- Inserir Nova Conta");
        WriteLine("3- Transferir");
        WriteLine("4- Sacar");
        WriteLine("5- Depositar");
        WriteLine("C- Limpar Tela");
        WriteLine("X- Sair");
        WriteLine();

            string opcaoDoUsuario = ReadLine().ToUpper();
                
        WriteLine();
            return opcaoDoUsuario;
}