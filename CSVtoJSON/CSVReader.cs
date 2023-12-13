using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace NEAScripts
{
    public class CSVReader
    {

        private string csvFileName;
        public CSVReader(string filename) //Constructor settings the file name when CSVReader is initialised
        {
            csvFileName = filename;
        }
        private Queue<TransactionData> readFileWithQueueWithTypeT() //Returns a queue of strings from CSV file except header string
        {
            Queue<TransactionData> items = new Queue<TransactionData>(); //Creates empty queue 

            int loopCount = 0;

            using (var reader = new StreamReader(csvFileName)) //Opens csv file
            {

                while (!reader.EndOfStream) //Reads till end of CSV file and enqueues the line
                {
                    var line = reader.ReadLine();
                    var TransactionData = ConvertValuesInLine(line,loopCount);
                    items.Enqueue(TransactionData);
                    loopCount++;
 
                }

            }

            items.Dequeue(); //Removes first Tranascation data  of CSV file which containers headers
            return items;
        }

        public Stack<TransactionData> GetTransactionDataStack() //Meethod to reverse a queue so that dates go in ascending order and returns a list 
        {

            Queue<TransactionData> tranasctionQueue = readFileWithQueueWithTypeT(); //reads csv file and assigns queue with the returned queue

            int originalQueueLength = tranasctionQueue.Count(); //assings the original length of the queue so when looping through and dequeuing max I does not decrease

            Stack<TransactionData> transactionStack = new Stack<TransactionData>();

            for (int i = 0; i < originalQueueLength; i++) //loops through 0 to the max of queue length
            {
                transactionStack.Push(tranasctionQueue.Dequeue()); //pushs the most recent queue onto the stack by dequeuing it
            }

            return transactionStack; //returns the stack
        }

        private TransactionData ConvertValuesInLine(string csvLine, int lineCount) // Method which takes in line count from csv file and assings transaction data members its corresponding value
        {

            if(lineCount > 0) //if line isn't empty 
            {
                string[] stringArrayOfLines = csvLine.Split(','); //splits the csv string into an array of strings by ,
                if (stringArrayOfLines[3] == "") { //if valueIn  or valueOut are empty assign a 0
                    stringArrayOfLines[3] = "0";
                }else if (stringArrayOfLines[4] == "")
                {
                    stringArrayOfLines[4] = "0";
                }
                string date = stringArrayOfLines[0]; //assings the corresponding transactiondata memebers with its value from the CSV file
                string details = stringArrayOfLines[1];
                string transactionType = stringArrayOfLines[2];
                double valueIn = Convert.ToDouble(stringArrayOfLines[3]);
                double valueOut = Convert.ToDouble(stringArrayOfLines[4]);
                double balance = Convert.ToDouble(stringArrayOfLines[5]);


                return new TransactionData(date, details, transactionType, valueIn, valueOut, balance); //returns the full transaction data object
            }
            else
            {
                return new TransactionData(null, null, null, 0, 0, 0); //if it is empty return a empty transaction data object
            }
        }

    }    
}
