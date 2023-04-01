using MySql.Data.MySqlClient;
using System;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBAccess: IDBAccess
    {
        public  MySqlTransaction Transaction { get; private set; } = null;
        const string CONSTRING = "Server=sql7.freemysqlhosting.net;Database=sql7610327;Uid=sql7610327;Pwd=T37v65MwB6";
        //const string CONSTRING = "Server=127.0.0.1;Database=schaebigeschaetzungen;Uid=root;Pwd=";

        public MySqlConnection OpenDB()
        {
            MySqlConnection con = new MySqlConnection(CONSTRING);
            con.Open();
            return con;
        }

        public  void CloseDB(MySqlConnection con)
        {
            con.Close();
        }

        public  void BeginTransaktion()
        {
            MySqlConnection con = OpenDB();
            this.Transaction = con.BeginTransaction();
        }

        public  void Commit()
        {
            this.Transaction.Commit();
            this.Transaction.Connection.Close();
            this.Transaction = null; // important for the case distinction in ExecuteNonQuery
        }

        public void Rollback()
        {
            this.Transaction.Rollback();
            this.Transaction.Connection.Close();
            this.Transaction = null; // // important for the case distinction in ExecuteNonQuery
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">SQL-Command</param>
        /// <returns>Amount of effected datasets</returns>
        public int ExecuteNonQueryWithoutTransaction(string sql)
        {
            MySqlConnection con = OpenDB();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int anz = cmd.ExecuteNonQuery();

            CloseDB(con);

            return anz;
        }

        public int ExecuteNonQuery(String command)
        {
            int ret;
            if (this.Transaction == null)
            {
                MySqlConnection con = OpenDB();
                MySqlCommand obj = new MySqlCommand(command, con);

                ret = obj.ExecuteNonQuery();

                CloseDB(con);
            }
            else
            {
                //there is a transaction
                MySqlCommand obj = new MySqlCommand(command, this.Transaction.Connection, this.Transaction);

                ret = obj.ExecuteNonQuery();

            }

            return ret;
        }

        public int ExecuteNonQuery(String command, MySqlConnection con)
        {
            MySqlCommand obj = new MySqlCommand(command, con);
            return obj.ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteReader(string sql, MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public int GetLastInsertId(MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM player ORDER BY PlayerID DESC LIMIT 1;", con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
