using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMoneyMoney
{
    abstract class Rekening
    {
        private double saldo;

        public double Saldo
        {
            get { return saldo; }
        }

        public void VoegGeldToe(double deposit)
        {
            saldo += deposit;
        }
        public void HaalGeldAf(double withdrawal)
        {
            saldo -= withdrawal;
        }
        public abstract double BerekenRente();
    }
}
