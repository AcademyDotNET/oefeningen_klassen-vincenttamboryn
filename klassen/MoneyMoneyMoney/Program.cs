using System;

namespace MoneyMoneyMoney
{
    class Program
    {
        static void Main(string[] args)
        {
            BankRekening rekening1 = new BankRekening();
            SpaarRekening rekening2 = new SpaarRekening();
            ProRekening rekening3 = new ProRekening();

            rekening1.VoegGeldToe(500);
            rekening2.VoegGeldToe(1200);
            rekening3.VoegGeldToe(5600);
            Console.WriteLine($"Op rekening1 staat {rekening1.Saldo}, op rekening2 {rekening2.Saldo}, op rekening3 {rekening3.Saldo}");

            Console.WriteLine($"We halen nu 450 euro van rekening 1 af");
            rekening1.HaalGeldAf(450);
            Console.WriteLine($"Op rekening1 staat nu {rekening1.Saldo}");

            Console.WriteLine($"na de rente staat er op rekening1 {rekening1.BerekenRente()} euro, op rekening2 {rekening2.BerekenRente()} euro, op rekening3 {rekening3.BerekenRente()} euro");
        }
    }
}
