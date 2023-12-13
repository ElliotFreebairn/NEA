using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace NEAScripts
{
    public class SQLConnection
    {
         
        public static SQLConnection connection = new SQLConnection(); //Create an instance of SQL connection

      
        private static string server = "server=127.0.0.1;uid=root;" + "pwd=Stud3nt!#;database=studentfinancedatabase"; //Connection string with server details


        public MySqlConnection dataSource() //Method to get a MySQL Connection object
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(); //Create a new MySQLConnection instance

                conn.ConnectionString = server; //Set the connection string to my server details

                conn.Open(); //Open the database connection

                return conn; //Return the MySQLConnection Object

            }
            catch (MySqlException ex) //Handle any exception that occurs during the connection
            {
                Console.WriteLine(ex.Message);
            }

            return null; //Return null if connection attempt fails
        }
    }
}
