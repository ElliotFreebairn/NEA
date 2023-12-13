using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NEAScripts
{
    public class TransactionStack : CSVReader 
    {
        //private Queue<string> csvData = new Queue<string>();
        private Stack<TransactionData> csvDataObjectStack = new Stack<TransactionData>();
        public TransactionStack(string filename) : base(filename) // CSVtoQueue inherits csv readers methods and fields
        {
            csvDataObjectStack = GetTransactionDataStack(); //fill in queue with transactiondata objects read from CSV file 

        }

        public Stack<TransactionData> GetQueueOfTransactions() //returns the queue so it can be accessed from outside of the class
        {
            return csvDataObjectStack; 

        }

    }
}
