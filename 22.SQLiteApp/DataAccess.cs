using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace _22.SQLiteApp
{
    class DataAccess
    {
        internal static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=SQliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customer (UID INTEGER PRIMARY KEY, " +
                    "First_name NVARCHAR(35)NULL," +
                    "Last_name NVARCHAR(35)NULL," +
                    "Email NVARCHAR(40)NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string UID, string First_name, string Last_name, string Email)
        {
            using (SqliteConnection db =
            new SqliteConnection("Filename=SQliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customer VALUES (@UID, @First_name, @Last_name,@Email);";
                insertCommand.Parameters.AddWithValue("@UID", UID);
                insertCommand.Parameters.AddWithValue("@First_name", First_name);
                insertCommand.Parameters.AddWithValue("@Last_name", Last_name);
                insertCommand.Parameters.AddWithValue("@Email", Email);


                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
               new SqliteConnection("Filename=SQliteSample.db"))
            {
                db.Open();

               // SqliteCommand selectCommand = new SqliteCommand
                    //("SELECT Text_Entry from MyTable", db);

               // SqliteDataReader query = selectCommand.ExecuteReader();

                SqliteCommand selectCommand = new SqliteCommand("select * from Customer", db);
                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }

                db.Close();
            }

            return entries;
        }
    }
}
        
    

