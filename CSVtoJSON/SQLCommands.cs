using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NEAScripts
{
    public class SQLCommands<T>
    {
        SQLCommandBuilder<T> commandBuilder;

        public SQLCommands(int tableCase)
        {
            SQLConnection conn = new SQLConnection();
            commandBuilder = new SQLCommandBuilder<T>(conn, tableCase);
        }

        public void PopulateTable(Stack<T> tableStack) //Methood to insert a stack of values from t into a specific table in MySQL database
        {
            int originalStack = tableStack.Count;
            for (int i = 0; i < originalStack; i++)
            {
                commandBuilder.BuildInsertCommand(tableStack.Pop());
            }
        }

        public void PrintTransactionData(string[] values, string whereClause) //method to print out transaction data    
        {
            List<T> listData = commandBuilder.BuildSelectCommand(values, whereClause); // fills in list of data from database with Type T
            List<PropertyInfo> requestedPropertyInfo = new List<PropertyInfo>();
            List<string> result = new List<string>();

            foreach (T data in listData)
            {
                var properties = data.GetType().GetProperties(); //assings proporties the object datas property info

                //create it so only prints out corresponding values of names
                if (values.Length > 0)
                {
                    string[] propertyName = properties.Select(p => p.Name).ToArray(); //proporty names are added to a string

                    for (int i = 0; i < values.Length; i++) //loop through values
                    {
                        for (int j = 0; j < properties.Length; j++) //loop through properties
                        {
                            if (values[i] == propertyName[j]) //if the matched values are in the propertynames it adds the property info to a list of property info
                            {
                                requestedPropertyInfo.Add((PropertyInfo)properties.GetValue(j));
                            }
                        }
                    }

                    result.Add(string.Join("|", requestedPropertyInfo.Select(p => p.GetValue(data)))); //dynimacally retrieves values from data object using reflection then joins the values as a string
                }
                else
                {
                    string allValues = string.Join("|", properties.Select(p => p.GetValue(data))); //If no values are selected all values from data object will be retrieved
                    result.Add(allValues); //string of values added to list
                }
            }
            foreach (string str in result)
            {
                Console.WriteLine(str); //prints out to the console each line of values
            }
        }

        public List<T> GetListOfTableValues(string[] values, string  whereClause) //method to return a list of T from a specific table MySQL database
        {
            List<T> listData = commandBuilder.BuildSelectCommand(values, whereClause); //assings the values retrieved from MySQL into a list of type T
            return listData; //returns the list of T
        }
    }
}


    
