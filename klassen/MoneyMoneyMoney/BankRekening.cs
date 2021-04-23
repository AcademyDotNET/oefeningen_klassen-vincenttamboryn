using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMoneyMoney
{
    class BankRekening:Rekening
    {
        public override double BerekenRente()
        {
            if (Saldo>100)
            {
                return Saldo * 1.05;
            }
            else
            {
                return Saldo * 1;
            }
        }
    }
}
