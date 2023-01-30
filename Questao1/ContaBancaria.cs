using System;
using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public int numero { get; set; }
        public string titular { get; set; }
        public double saldo { get; set; }

        public ContaBancaria(int numero, string titular, double saldo)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = saldo;
        }

        public void Deposito(double quantia)
        {
            this.saldo += quantia;
        }

        public void Saque(double quantia)
        {
            this.saldo -= (quantia + 3.5);
        }

        public void ImprimirExtrato()
        {
            Console.WriteLine($"Conta {this.numero}, Titular: {this.titular}, Saldo: $ {String.Format("{0:C}", this.saldo)}");
        }
    }
}
