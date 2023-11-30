using System;
using System.Collections;
using static Tumakov11.BankAccount;

namespace Tumakov11
{
    internal class BankAccountFactory
    {
        private static Hashtable accounts = new Hashtable();

        // Перегруженные методы CreateAccount для создания счета и возвращения номера счета
        public static uint CreateAccount(Type_bank_account bank_account)
        {
            BankAccount account = new BankAccount(bank_account);
            accounts.Add(account.Number_Account, account);
            return account.Number_Account;
        }

        public static uint CreateAccount(decimal balance)
        {
            BankAccount account = new BankAccount(balance);
            accounts.Add(account.Number_Account, account);
            return account.Number_Account;
        }

        public static uint CreateAccount(decimal balance, Type_bank_account bank_account)
        {
            BankAccount account = new BankAccount(balance, bank_account);
            accounts.Add(account.Number_Account, account);
            return account.Number_Account;
        }

        // Метод закрытия счета
        public static void CloseAccount(uint accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts.Remove(accountNumber);
                Console.WriteLine($"Аккаунт {accountNumber} закрыт.");
            }
            else
            {
                Console.WriteLine($"Аккаунт {accountNumber} не найден.");
            }
        }
    }
}
