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

            Stack<TransactionData> transactions = reader.GetTransactionDataStack();
            
            SQLCommands<TransactionData> commands = new SQLCommands<TransactionData>(1);

            //List<TransactionData> data = commands.GetListOfTableValues([], null);

            //commands.PrintTransactionData(["TransactionID"], null);

            TransactionCategoriser categoriser = new TransactionCategoriser();
            int categoryCount = 0;
            double moneySpent = 0;
            foreach (TransactionData data in transactions)
            {
                if (categoriser.CheckGeneralCategory(data, "Transport"))
                {
                    moneySpent += data.MoneyOut;
                    categoryCount++;
                }

                //categoriser.CheckIfFoodCategory(data);
            }
            Console.WriteLine(moneySpent);
            Console.WriteLine(categoryCount);

        }
    }
}
