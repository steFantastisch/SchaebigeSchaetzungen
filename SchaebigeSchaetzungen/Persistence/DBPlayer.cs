using MySql.Data.MySqlClient;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBPlayer
    {
        private static void GetDataFromReader(MySqlDataReader rdr, User p)
        {
            p.PlayerID = rdr.GetInt32("PlayerID");
            p.Name = rdr.GetString("Name");
            p.Password = rdr.GetString("Password");
            p.Mail = rdr.GetString("Mail");
            p.Crowns = rdr.GetInt32("Crowns");

            /*
             *  TODO
             *  Load avatar 
             *  var test = rdr.GetOrdinal("Avatar");
             */
        }

        public static void Read(User p)
        {
            MySqlConnection con = DBAccess.OpenDB();

            string sql = $"SELECT * FROM Player WHERE PlayerID = '{p.PlayerID}'";
            MySqlDataReader rd = DBAccess.ExecuteReader(sql, con);

            try
            {
                while (rd.Read())
                {
                    GetDataFromReader(rd, p);
                }
            }
            catch (Exception)
            {
                throw new Exception("Kein Player gefunden!");
            }
            finally
            {
                rd.Close();
                DBAccess.CloseDB(con);
            }
        }



        public static List<User> ReadAll()
        {
            MySqlConnection con = DBAccess.OpenDB();
            try
            {

                string sql = "SELECT * FROM Player";
                List<User> list = new List<User>();
                MySqlDataReader reader = DBAccess.ExecuteReader(sql, con);

                while (reader.Read())
                {
                    User p = new User();
                    GetDataFromReader(reader, p);
                    list.Add(p);
                }

                return list;
            }
            catch (Exception)
            {
                return new List<User>();
            }
            finally
            {
                DBAccess.CloseDB(con);
            }
        }

    }
}
