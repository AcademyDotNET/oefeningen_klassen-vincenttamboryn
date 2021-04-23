using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMoneyMoney
{
    class ProRekening:SpaarRekening
    {
        public override double BerekenRente()
        {
            double rente = base.BerekenRente()/Saldo;
            if (Saldo>1000)
            {
                rente += Math.Floor(Saldo / 1000)/100;
            }
            return Saldo * rente;
        }
    }
}
