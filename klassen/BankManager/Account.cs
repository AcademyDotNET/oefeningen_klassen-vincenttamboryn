using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public enum AccountState {Valid, Blocked}
    class Account
    {
        private double amount;
        private string name;
        private AccountState state = AccountState.Valid;
        private string accountNumber;
        public Account(string nameOfAccountHolder, int initialBalance, string initalAccountNumber)
        {
            name = nameOfAccountHolder;
            accountNumber = initalAccountNumber;
            amount = initialBalance;
        }
        public void ChangeState(AccountState change)
        {
            state = change;
            Console.WriteLine($"account {name} is {state}.");
        }
        public int WithdrawFunds(int afname)
        {
            if (afname > amount)
            {
                afname = Convert.ToInt32(amount);
                Console.WriteLine("insufficient funds");
            }
            amount -= afname;
            Console.WriteLine($"Currently withdrawing {afname} euro from the account of {name}");
            return afname;
        }
        public void PayInFunds(int deposit)
        {
            Console.WriteLine($"Currently depositing {deposit} euro into the account of {name}");
            amount += deposit;
        }
        public double GetBalance()
        {
            Console.WriteLine($"There is currently {amount} euro in the account of {name}");
            return amount;
        }
    }
}
