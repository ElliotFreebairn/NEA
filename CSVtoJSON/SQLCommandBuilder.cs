using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEAScripts
{
    public class SQLCommandBuilder<T> : SQLBase<T>
    {
        SQLConnection connection;

        public SQLCommandBuilder(SQLConnection conn, int tablecase) : base("")
        {
            connection = conn; //Create an instance of SQL connection
            tableName = GetTableNameFromCase(tablecase); //Assign corresponding tableName from tableCase inputted
        }

        public override void BuildInsertCommand(T data)
        {
            var properties = data.GetType()
                .GetProperties(); //Gets all properties from class T
            var propertyNames = properties.Select(p => p.Name); //Transforms properties object into proporties collection and returns list of corresponding strings of names
            var propertyValues = properties.Select(p => p.GetValue(data)); //Returns the corresponding value of properties from T object

            try
            {
                string command = $"INSERT INTO {tableName} ({string.Join(", ", propertyNames)}) VALUES" + //Creates command line for SQL insert based on object property columns and values
                  $"('{string.Join("', '", propertyValues)}')";

                MySqlCommand sqlCommand = new MySqlCommand(command, connection.dataSource());
                sqlCommand.ExecuteNonQuery(); //Executes SQL Statement
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message); //Catches null exception
            }
        }
        public override List<T> BuildSelectCommand(string[] values, string condition) //Method to Executed a SQL Select statement from values and condition parameters and return a List of type T
        {
            try
            {
                string columnNames = values.Length > 0 ? string.Join(", ", values) : "*"; //If value length is larger than 0 that becomes the string else it is *(represents all)
                string command = $"SELECT {columnNames} FROM {tableName} {GenericWhereClause(condition)}";

                MySqlCommand sqlCommand = new MySqlCommand(command, connection.dataSource());
                MySqlDataReader reader = sqlCommand.ExecuteReader(); //Builds a Data Reader object

                List<T> resultList = new List<T>(); //Creates a list of type T

                while (reader.Read())
                {
                    T data = Activator.CreateInstance<T>(); //Activator.Create instance creates an instance of type T

                    foreach (var property in typeof(T).GetProperties()) // loops through each property name in type T
                    {
                        if (values.Contains(property.Name) || columnNames == "*") //If values being searched is in database or all columns are selected go ahead
                        {
                            var value = reader[property.Name];
                            if (value != DBNull.Value) //DBNULL Represnets a non existen value in DataBase, so if value corresponds to a column name in database
                            {
                                property.SetValue(data, value);
                            }
                            else
                            {
                                property.SetValue(data, value); //Default value if value does not correspond to column
                            }
                        }
                    }
                    resultList.Add(data); //Adds data object to list
                }

                return resultList; //Returns list of type T
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message); //Handles null exception and prints out message
            }
        }


        private string GenericWhereClause(string tableCondition) //Method to return the where clause for the SQL statement
        {
            string whereClause = string.Empty;

            if (tableCondition == null) // returns a empty string if no codition is inputted
            {
                whereClause = string.Empty;
            }
            else //returns a WHERE clause if string inputted is not empty
            {
                whereClause = $"WHERE {tableCondition}";
            }

            return whereClause; //returns whereClause
        }

        private string GetTableNameFromCase(int tableCase) //Method to retrun table name based on tableCase inputted
        {
            string tableName = string.Empty;

            switch (tableCase)
            {
                case 1: //returns transaction_entry if table case = 1
                    tableName = "transaction_entry";
                    break;
                case 2: //returns user_detials if table case = 2;
                    tableName = "user_details";
                    break;
            }
            return tableName; //returns tableName 
        }


    }
}
