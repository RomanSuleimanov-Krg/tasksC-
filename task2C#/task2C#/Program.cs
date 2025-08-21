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
            ChekingAccount userChekingAccount = new ChekingAccount("1", "Roman", 1000, 0.015);
            SavingsAccount userSavingAccount = new SavingsAccount("1", "Roman", 5000, 0.05);

            userChekingAccount.ShowInfo();
            Console.WriteLine();
            userSavingAccount.ShowInfo();

            userChekingAccount.Deposit(150);
            userChekingAccount.Withdraw(1000);

            userChekingAccount.ShowInfo();
            Console.WriteLine();
            userSavingAccount.ShowInfo();

            userSavingAccount.translationMainAccount(2500, userChekingAccount);

            userChekingAccount.ShowInfo();
            Console.WriteLine();
            userSavingAccount.ShowInfo();

            userChekingAccount.translationSavingAccount(userSavingAccount, 2000);
            userSavingAccount.AplyInterest();

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

        public bool mayWithdraw { get; set; }

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
            if (Balance - amount < 0)
            {
                mayWithdraw = false;
                Balance = Balance;
                Console.WriteLine($"Вы пытаетесь снять {amount} рублей. А у вас {Balance} на счету");
                Console.WriteLine("Низя снять больше деняк чем имеется на балансе");
            }
            else
            {
                Balance -= amount;
                mayWithdraw = true;
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
            
            if (balance < 0)
            {
                Balance = 0;
                Console.WriteLine("Деняк на балансе не может быть меньше 0. Поэтому ваш баланс = 0");
            }
            else
            {
                {
                    Balance = balance;
                }
            }
            WithdrawalFee = withdrawalFee;
        }

        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
            if (Balance - (amount * WithdrawalFee) > 0 && mayWithdraw)
            {
                Balance -= (amount * WithdrawalFee);
            }
            else
            {
                Balance = Balance;
            }

        }

        public void translationSavingAccount(SavingsAccount savingsAccount, double amount)
        {
            if (Balance - amount < 0)
            {
                Balance = Balance;
                Console.WriteLine("Низя сделать перевод. Не хватит деняк (");
            }
            else if (savingsAccount.Balance + amount < 0)
            {
                Console.WriteLine("Так низя, сберегательный счет будет иметь минусовой баланс");
            }
            else
            {
                Balance -= amount;
                savingsAccount.Balance += amount;
            }
        }
    }

    class SavingsAccount : BankAccount
    {
        public double IterestRate { get; set; }
        public ChekingAccount ChekingAccount { get; set; }

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
                Balance = (Balance+(Balance * IterestRate));
            }
        }

        public void translationMainAccount (double amount, ChekingAccount chekingAccount)
        {
            if (Balance < 0)
            {
                Console.WriteLine("Низя снимать, деняк нет (");
            }
            else if (Balance - amount < 0)
            {
                Balance = Balance;
                Console.WriteLine($"Низя сделать перевод, у вас на балансе {Balance} рублей, а вы пытаетесь перевести {amount} рублей.");
            }
            else
            {
                chekingAccount.Deposit(amount);
                Balance -= amount;
            }
        }

    }
}
