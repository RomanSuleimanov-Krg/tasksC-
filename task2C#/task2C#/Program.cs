using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task2C_
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class BankAccount
    {
        public string AccountNumber { get; set; }
        public string OwnerNmae { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, string ownerNmae, decimal balance)
        {
            AccountNumber = accountNumber;
            OwnerNmae = ownerNmae;

            if (balance > 0)
            {
                Balance = balance;
            }
            else
            {
                Balance = 0;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }

            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {

            decimal balanceInitial;
            balanceInitial = Balance;

            if (Balance - amount < 0)
            {
                Balance = balanceInitial;
            }
            else
            {
                Balance -= amount;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Здравствуйте, {OwnerNmae}.");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Информация о вашем счете:\nНомер вашего счета: {AccountNumber}\nВладелец: {OwnerNmae}\nБаланс: {Balance}рублей.");
            Console.WriteLine(new string('-', 40));
        }

    }

    class ChekingAccount : BankAccount
    {
        public double WithdrawalFee { get; set; }
        public ChekingAccount(string accountNumber, string ownerNmae, decimal balance, double withdrawalFee) : base(accountNumber, ownerNmae, balance)
        {
            AccountNumber = accountNumber;
            OwnerNmae = ownerNmae;
            Balance = balance;
            WithdrawalFee = withdrawalFee;
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);

        }
    }
}
