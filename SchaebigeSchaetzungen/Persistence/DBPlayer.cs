using MySql.Data.MySqlClient;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBPlayer
    {
        private readonly IDBAccess _dbAccess;

        public DBPlayer(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public void Insert(Player player)
        {

            MySqlConnection con = _dbAccess.OpenDB();
            player.PlayerID = _dbAccess.GetLastInsertId(con)+1;

            String sql = $"Insert into Player (PlayerID, Name, Mail, Password, Crowns) " +
               $"values ('{player.PlayerID}','{player.Name}', '{player.Mail}', '{player.Password}', 0)";

            try
            {
                int ret = _dbAccess.ExecuteNonQuery(sql, con);
                if (ret != 1) throw new Exception("Insert failed!");
            }
            finally
            {
                _dbAccess.CloseDB(con);
            }
        }

        public Player Read(Player p)
        {
            MySqlConnection con = _dbAccess.OpenDB();

            //string sql = $"SELECT * FROM Player WHERE PlayerID = '{p.PlayerID}'";
            string sql = $"SELECT * FROM Player WHERE Mail = '{p.Mail}' AND Password = '{p.Password}'";
            MySqlDataReader rd = _dbAccess.ExecuteReader(sql, con);

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
                _dbAccess.CloseDB(con);
            }
            return p;
        }

        public void UpdateCrowns(Player player)
        {
            String sql =
                $"Update player set Crowns ='{player.GamePoints + player.Crowns}' where PlayerID = {player.PlayerID}";

            int anz = _dbAccess.ExecuteNonQuery(sql);

            if (anz != 1)
                throw new Exception("Speichern fehlgeschlagen!");
        }

        public void Update(Player player)
        {
            String sql =
                $"Update player set Name ='{player.Name}', password ='{player.Password}', Mail='{player.Mail}' where PlayerID = {player.PlayerID}";

            int anz = _dbAccess.ExecuteNonQuery(sql);

            if (anz != 1)
                throw new Exception("Speichern fehlgeschlagen!");
        }

        public void Delete(Player player)
        {
            /*
             * Probably not to implement
            */
        }

        /// <summary>
        /// wird nur für highscore view gebraucht
        /// </summary>
        /// <returns></returns>
        public  List<Player> ReadAll()
        {
            MySqlConnection con = _dbAccess.OpenDB();
            try
            {

                string sql = "SELECT * FROM Player";
                List<Player> list = new List<Player>();
                MySqlDataReader reader = _dbAccess.ExecuteReader(sql, con);

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
                _dbAccess.CloseDB(con);
            }
        }

        private  Player GetDataFromReader(MySqlDataReader rdr, Player p)
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
