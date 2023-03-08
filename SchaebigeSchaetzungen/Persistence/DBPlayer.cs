using Google.Apis.YouTube.v3.Data;
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
        public static void Insert(Player player)
        {

            MySqlConnection con = DBAccess.OpenDB();
            player.PlayerID = DBAccess.GetLastInsertId(con)+1;

            String sql = $"Insert into Player (PlayerID, Name, Mail, Password, Crowns) " +
               $"values ('{player.PlayerID}','{player.Name}', '{player.Mail}', '{player.Password}', 0)";

            try
            {
                int ret = DBAccess.ExecuteNonQuery(sql, con);
                if (ret != 1) throw new Exception("Insert failed!");
            }
            finally
            {
                DBAccess.CloseDB(con);
            }
        }

        public static Player Read(Player p)
        {
            MySqlConnection con = DBAccess.OpenDB();

            //string sql = $"SELECT * FROM Player WHERE PlayerID = '{p.PlayerID}'";
            string sql = $"SELECT * FROM Player WHERE Mail = '{p.Mail}' AND Password = '{p.Password}'";
            MySqlDataReader rd = DBAccess.ExecuteReader(sql, con);

            try
            {

                if (rd.Read())
                {
                    p = GetDataFromReader(rd, p);
                }
                else
                {
                    throw new Exception("Kein Spieler gefunden.");
                }

            }
            catch (Exception)
            {
                throw new Exception("Eintragen in die Datenbank hat nicht funktioniert");
            }
            finally
            {
                rd.Close();
                DBAccess.CloseDB(con);
            }
            return p;
        }

        public static void UpdateCrowns(Player player)
        {
            String sql =
                $"Update player set Crowns ='{player.GamePoints + player.Crowns}' where PlayerID = {player.PlayerID}";

            int anz = DBAccess.ExecuteNonQuery(sql);

            if (anz != 1)
                throw new Exception("Speichern fehlgeschlagen!");
        }

        public static void Update(Player player)
        {
            String sql =
                $"Update player set Name ='{player.Name}', password ='{player.Password}', Mail='{player.Mail}' where PlayerID = {player.PlayerID}";

            int anz = DBAccess.ExecuteNonQuery(sql);

            if (anz != 1)
                throw new Exception("Speichern fehlgeschlagen!");
        }

        public static void Delete(Player player)
        {
            /*
             * Probably not to implement
            */
        }

        /// <summary>
        /// wird nur für highscore view gebraucht
        /// </summary>
        /// <returns></returns>
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
                list.Sort((p1, p2) => p2.Crowns.CompareTo(p1.Crowns));
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

        private static Player GetDataFromReader(MySqlDataReader rdr, Player p)
        {
            p.PlayerID = rdr.GetInt32("PlayerID");
            p.Name = rdr.GetString("Name");
            p.Password = rdr.GetString("Password");
            p.Mail = rdr.GetString("Mail");
            p.Crowns = rdr.GetInt32("Crowns");
            // p.Avatar = new Avatar(rdr.GetInt32("Avatar"));
            return p;
        }
    }
}
