using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov11
{
    internal class BankTransaction
    {
        private readonly DateTime _date;
        private readonly decimal _withdrawn_money;

        public DateTime DateTime_Transaction
        {
            get { return _date; }
        }

        public decimal Withdrawn_Money
        {
            get { return _withdrawn_money; }
        }

        public BankTransaction(decimal withdrawn_money)
        {
            this._withdrawn_money = withdrawn_money;
            _date = DateTime.Now;
        }
    }
}
