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
        private static void GetDataFromReader(MySqlDataReader rdr, Player p)
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

        public static void Read(Player p)
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



        public static List<Player> ReadAll()
        {
            MySqlConnection con = DBAccess.OpenDB();
            try
            {

                string sql = "SELECT * FROM Player";
                List<Player> list = new List<Player>();
                MySqlDataReader reader = DBAccess.ExecuteReader(sql, con);

                while (reader.Read())
                {
                    Player p = new Player();
                    GetDataFromReader(reader, p);
                    list.Add(p);
                }

                return list;
            }
            catch (Exception)
            {
                return new List<Player>();
            }
            finally
            {
                DBAccess.CloseDB(con);
            }
        }

    }
}
