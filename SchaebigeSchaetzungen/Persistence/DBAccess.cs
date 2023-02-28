using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Persistence
{
    public static class DBAccess
    {
        public static MySqlTransaction Transaction { get; private set; } = null;
        //const string CONSTRING = "Server=sql7.freemysqlhosting.net;Database=sql7530568;Uid=sql7530568;Pwd=GGddhfmusS";
        const string CONSTRING = "Server=127.0.0.1;Database=schaebigeschaetzungen;Uid=root;Pwd=";

        public static MySqlConnection OpenDB()
        {
            MySqlConnection con = new MySqlConnection(CONSTRING);
            con.Open();
            return con;
        }

        public static void CloseDB(MySqlConnection con)
        {
            con.Close();
        }

        public static void BeginTransaktion()
        {
            MySqlConnection con = OpenDB();
            DBAccess.Transaction = con.BeginTransaction();
        }

        public static void Commit()
        {
            DBAccess.Transaction.Commit();
            DBAccess.Transaction.Connection.Close();
            DBAccess.Transaction = null; // important for the case distinction in ExecuteNonQuery
        }

        public static void Rollback()
        {
            DBAccess.Transaction.Rollback();
            DBAccess.Transaction.Connection.Close();
            DBAccess.Transaction = null; // // important for the case distinction in ExecuteNonQuery
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">SQL-Command</param>
        /// <returns>Amount of effected datasets</returns>
        public static int ExecuteNonQueryWithoutTransaction(string sql)
        {
            MySqlConnection con = OpenDB();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int anz = cmd.ExecuteNonQuery();

            CloseDB(con);

            return anz;
        }

        public static int ExecuteNonQuery(String command)
        {
            int ret;
            if (DBAccess.Transaction == null)
            {
                MySqlConnection con = OpenDB();
                MySqlCommand obj = new MySqlCommand(command, con);

                ret = obj.ExecuteNonQuery();

                CloseDB(con);
            }
            else
            {
                //there is a transaction
                MySqlCommand obj = new MySqlCommand(command, DBAccess.Transaction.Connection, DBAccess.Transaction);

                ret = obj.ExecuteNonQuery();

            }

            return ret;
        }

        public static int ExecuteNonQuery(String command, MySqlConnection con)
        {
            MySqlCommand obj = new MySqlCommand(command, con);
            return obj.ExecuteNonQuery();
        }

        public static MySqlDataReader ExecuteReader(string sql, MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public static int GetLastInsertId(MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM player ORDER BY PlayerID DESC LIMIT 1;", con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
