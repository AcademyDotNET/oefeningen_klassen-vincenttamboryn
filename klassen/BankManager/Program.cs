using System;

namespace BankManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Account rekening1 = new Account("Vincent", 100, "BE54 4561 3474 6148");
            Account rekening2 = new Account("Bert", 100, "BE54 4451 6678 9421");

            rekening1.PayInFunds(rekening2.WithdrawFunds(20));

            rekening1.GetBalance();
            rekening2.GetBalance();

            rekening2.WithdrawFunds(200);
            rekening2.GetBalance();

            rekening1.ChangeState(AccountState.Blocked);
            rekening1.WithdrawFunds(100);

        }
    }
}
