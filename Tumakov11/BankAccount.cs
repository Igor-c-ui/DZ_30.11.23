using System.Collections.Generic;
using System;
using System.IO;

namespace Tumakov11
{
    class BankAccount
    {
        public enum Type_bank_account
        {
            Текущий,
            Сберегательный
        }
        private static uint next_number_account = 1;
        private uint number_account;
        private decimal balance;
        private Type_bank_account bank_account;
        private Queue<BankTransaction> transactions = new Queue<BankTransaction>();

        public uint Number_Account
        {
            get { return number_account; }
        }

        public decimal Balance_Account
        {
            get { return balance; }
        }

        public Type_bank_account Type_Bank_Account
        {
            get { return bank_account; }
        }

        public Queue<BankTransaction> Transactions
        {
            get { return transactions; }
        }

        private void Generate_next_number_account()
        {
            next_number_account++;
        }

        public bool Withdraw(uint withdrawn_money)
        {
            if (balance - withdrawn_money > 0)
            {
                balance -= withdrawn_money;
                BankTransaction transaction = new BankTransaction(-withdrawn_money);
                transactions.Enqueue(transaction);
                return true;
            }
            return false;
        }

        public void Put_Money(uint money)
        {
            balance += money;
            BankTransaction transaction = new BankTransaction(money);
            transactions.Enqueue(transaction);
        }

        public bool Transfer_money(BankAccount account, decimal money)
        {
            if ((money > 0) && (balance - money > 0))
            {
                account.balance += money;
                balance -= money;
                BankTransaction transaction = new BankTransaction(-money);
                transactions.Enqueue(transaction);
                return true;
            }
            return false;
        }

        public void Dispose(BankAccount bankAccount)
        {
            string file = "dispose.txt";
            int count = transactions.Count;

            for (int i = 0; i < count; i++)
            {
                BankTransaction transaction = transactions.Dequeue();
                File.AppendAllText(file, $"\n{transaction.Withdrawn_Money}, {transaction.DateTime_Transaction}");
            }

            GC.SuppressFinalize(bankAccount);
        }

        internal BankAccount(decimal balance, Type_bank_account bank_account)
        {
            number_account = next_number_account;
            this.balance = balance;
            this.bank_account = bank_account;
            Generate_next_number_account();
        }

        internal BankAccount(decimal balance)
        {
            number_account = next_number_account;
            this.balance = balance;
            Generate_next_number_account();
        }

        internal BankAccount(Type_bank_account bank_account)
        {
            number_account = next_number_account;
            this.bank_account = bank_account;
            Generate_next_number_account();
        }
    }
}
