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
            ChekingAccount userChekingAccount = new ChekingAccount("1", "Roman", 1000, 0.15);
            SavingsAccount userSavingAccount = new SavingsAccount("1", "Roman", 5000, 0.05);

            userChekingAccount.ShowInfo();
            Console.WriteLine();
            userSavingAccount.ShowInfo();
        }
    }

    class BankAccount
    {
        public string AccountNumber { get; set; }
        public string OwnerNmae { get; set; }
        public double Balance { get; set; }

        public BankAccount(string accountNumber, string ownerNmae, double balance)
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

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }

            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {

            double balanceInitial;
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
            Console.WriteLine($"Информация о вашем счете:\nНомер вашего счета: {AccountNumber}\nВладелец: {OwnerNmae}\nБаланс: {Balance} рублей.");
            Console.WriteLine(new string('-', 40));
        }

    }

    class ChekingAccount : BankAccount
    {
        public double WithdrawalFee { get; set; }
        public ChekingAccount(string accountNumber, string ownerNmae, double balance, double withdrawalFee) : base(accountNumber, ownerNmae, balance)
        {
            AccountNumber = accountNumber;
            OwnerNmae = ownerNmae;
            Balance = balance;
            WithdrawalFee = withdrawalFee;
        }

        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
            if (Balance - (amount * WithdrawalFee) < 0)
            {
                Balance = Balance;
            }
            else
            {
                Balance -= (amount + (amount * WithdrawalFee));
            }

        }
    }

    class SavingsAccount : BankAccount
    {
        public double IterestRate { get; set; }

        public SavingsAccount(string accountNumber, string ownerNmae, double balance, double iterestRate) : base(accountNumber, ownerNmae, balance)
        {
            AccountNumber = accountNumber;
            OwnerNmae = ownerNmae;
            Balance = balance;
            IterestRate = iterestRate;
        }

        public void AplyInterest()
        {
            if (Balance < 0)
            {
                Balance = 0;
            }
            else
            {
                Balance = (Balance * IterestRate);
            }
        }
    }
}
