using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEAScripts
{
    public class TransactionData
    {
        public TransactionData() //Constructor for when a null instance needs to be created
        {

        }
        public TransactionData(string date, string details, string transactionType, double moneyIn, double  moneyOut, double balance) //Constructor for when details are already known
        {
            DateOfTransaction = date;
            Details = details;
            TransactionType = transactionType;
            MoneyIn = moneyIn;
            MoneyOut = moneyOut;
            Balance = balance;
        }

        //properties of transaction data
        public int TransactionID { get; set; } = 0;
        public string DateOfTransaction { get; set; } = "";
        public string Details { get; set; } = "";
        public string TransactionType { get; set; } = "";
        public double MoneyIn { get; set; } = 0;
        public double MoneyOut { get; set; } = 0;
        public double Balance { get; set; } = 0;

    }

}
