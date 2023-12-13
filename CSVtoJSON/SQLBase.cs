using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NEAScripts
{
    public abstract class SQLBase<T> 
    {
        protected string tableName { get; set; }

        public SQLBase(string tablename) //constructor to set table name when inherited
        {
            tableName = tablename;
        }

        public abstract void BuildInsertCommand(T data); //Abstract method to build an execute an SQL insert command
        public abstract List<T> BuildSelectCommand(string[] values, string condition); //Abstract method to build an execute an SQL select command

    }

}