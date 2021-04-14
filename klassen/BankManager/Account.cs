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
            if (state == AccountState.Valid)
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
            else
            {
                Console.WriteLine("Error, this account is blocked");
                return 0;
            }
        }
        public void PayInFunds(double deposit)
        {
            if (state == AccountState.Valid)
            {
                Console.WriteLine($"Currently depositing {deposit} euro into the account of {name}");
                amount += deposit;
            }
            else
            {
                Console.WriteLine("Error, this account is blocked");
            }
        }
        public double GetBalance()
        {
            Console.WriteLine($"There is currently {amount} euro in the account of {name}");
            return amount;
        }
    }
}
