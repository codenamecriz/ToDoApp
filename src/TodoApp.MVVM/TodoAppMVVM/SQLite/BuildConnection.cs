using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMVVM.SQLite
{
    public class BuildConnection : IBuildConnection
    {
        public SQLiteConnection DbConnection() // Set SQLITE Connection
        {
            string dbConnection = @"Data Source=TodoDatabase.db";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnection);
            return sqliteCon;

        }

    }
}
