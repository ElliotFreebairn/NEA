using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NEAScripts
{
    public class Program
    {
        static void Main(string[] args)
        {

            TransactionStack reader = new TransactionStack("Transactions.csv");
            //SQLConnection connection = new SQLConnection();

            Stack<TransactionData> transactions = reader.GetTransactionDataStack();
            //TransactionData transaction = transactions.Pop();

            SQLCommands<TransactionData> commands = new SQLCommands<TransactionData>(1);
            //commands.PopulateTable(transactions);
            //commands.PrintTransactionData([], null);
            List<TransactionData> data = commands.GetListOfTableValues([], null);
            commands.PrintTransactionData(["TransactionID"], null);

            //TransactionData transaction = commands.SelectTableProperties(["Details", "Balance"], "TransactionID = 1");
            //Console.WriteLine(transaction.Details);

            //SQLCommandBuilder builder = new SQLCommandBuilder(connection,1);
            //builder.BuildInsertCommand(transaction);
            //Console.WriteLine(builder.BuildSelectCommand(["Details","Balance"], "TransactionID = 1")[0].Balance); 
        }
    }
}
