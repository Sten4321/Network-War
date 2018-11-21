using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace HighScore
{
    public class Database
    {
        private static Database DB_instance;

        private Database()
        {
        }

        //Singleton
        static public Database _Instance
        {
            get
            {
                if (DB_instance == null)
                {
                    DB_instance = new Database();
                }
                return DB_instance;
            }
        }

        public Dictionary<string, int> DatabaseData { get => databaseData; set => databaseData = value; }

        SQLiteConnection sqlite2 = new SQLiteConnection("Data Source=C:\\Database\\Highscore.db");

        Dictionary<string, int> databaseData;

        public void CreateDatabase()
        {
            if (!System.IO.File.Exists("C:\\Database\\Highscore.db"))
            {
                System.IO.Directory.CreateDirectory("C:\\Database");
                SQLiteConnection.CreateFile("C:\\Database\\Highscore.db");
            }
            CreateTables();
        }

        public Dictionary<string,int> ReadHighScoreList(string select)
        {
            //Read highscoreList from database
            sqlite2.Open();
            string sql = select;
            //"select * from users" +
            //"order by score desc"
            DatabaseData = new Dictionary<string, int>();

            SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string a = reader.GetString(1);
                int b = reader.GetInt32(2);
                DatabaseData.Add(a, b);
            }

            sqlite2.Close();
            return DatabaseData;
        }
        

        void CreateTables()
        {
            //Highscore table created

            sqlite2.Open();
            string CreateTableHighscore = "CREATE TABLE IF NOT EXISTS HighScore" +
                "(ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                "" + "user" + " varchar(50)," +
                "" + "score" + " INTEGER," +
                "DateTime DATETIME NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP, 'localtime')))";

            SQLiteCommand commandHighscore = new SQLiteCommand(CreateTableHighscore, sqlite2);
            commandHighscore.ExecuteNonQuery();
            
            sqlite2.Close();
        }

        #region dropTable
        public void DropTable(string tableName)
        {
            //Drops table
            sqlite2.Open();

            string txtSqlQuery = "Drop table " + tableName;

            SQLiteCommand command = new SQLiteCommand(txtSqlQuery, sqlite2);
            command.ExecuteNonQuery();
            sqlite2.Close();
        }
        #endregion

        public void UpdateTable(string tableName)
        {
                //Update Table
                sqlite2.Open();

                string txtSqlQuery = tableName;

                SQLiteCommand command = new SQLiteCommand(txtSqlQuery, sqlite2);
                command.ExecuteNonQuery();
                sqlite2.Close();
        }

        public void AddHighScore(string user, int score)
        {
            //Adds HighScore to database
            sqlite2.Open();

            string txtSqlQuery = "INSERT INTO HighScore Values (null,'" + user + "'," + score + ", date('now'))";

            SQLiteCommand command = new SQLiteCommand(txtSqlQuery, sqlite2);
            command.ExecuteNonQuery();
            sqlite2.Close();
        }
    }
}