using static System.Console;
namespace DioBank
{
    public class Contas
    {
        private ETipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Contas(ETipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar (double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Saldo *-1))
            {
                WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            WriteLine($"O saldo atual da conta {this.Nome} é de {this.Saldo}.");
            return true;
        }
        public void Deposito (double valorDeposito)
        {
            this.Saldo += valorDeposito;
            WriteLine($"Saldoatual da conta {this.Nome} é de R${this.Saldo}.");
        }

        public void Transferir(double valorTransferencia, Contas contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }
        //subrescrevend o método tostring
        public override string ToString()
        {
            string retorno = "";
        retorno += "Tipo Conta " + this.TipoConta + " | ";
        retorno += "Nome " + this.Nome + " | ";
        retorno += "Saldo "+ this.Saldo + " | ";
        retorno += "Crédito " + this.Credito + " | ";
        return retorno;
        }
        
    }
}