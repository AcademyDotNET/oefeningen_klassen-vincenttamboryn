using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMoneyMoney
{
    class SpaarRekening:Rekening
    {
        public override double BerekenRente()
        {
            return Saldo * 1.02;
        }
    }
}
