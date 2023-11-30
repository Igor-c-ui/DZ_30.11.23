using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Упр 11.1
            uint account1 = BankAccountFactory.CreateAccount(1000, BankAccount.Type_bank_account.Сберегательный);

            Console.WriteLine($"Aккаунт {account1}");

            BankAccountFactory.CloseAccount(account1);

        }
    }
}
