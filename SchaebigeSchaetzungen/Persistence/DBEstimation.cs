using MySql.Data.MySqlClient;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBEstimation
    {
        public static void Insert(Estimation estimation)
        {
            String sql = $"Insert into Estimation (PlayerID, VideoID, Difference) " +
                $"values ({estimation.Player.PlayerID}, {estimation.Video.VideoID}, {estimation.Difference})";

            MySqlConnection con = DBAccess.OpenDB();

            int ret = DBAccess.ExecuteNonQuery(sql, con);


            if (ret != 1)
                throw new Exception("Insert failed!");

            estimation.EstimationID = DBAccess.GetLastInsertId(con);
            DBAccess.CloseDB(con);
        }
        public static void Read(Estimation estimation)
        {
            MySqlConnection con = DBAccess.OpenDB();

            string sql = $"SELECT * FROM Estimation WHERE EstimationID = '{estimation.EstimationID}'";
            MySqlDataReader rd = DBAccess.ExecuteReader(sql, con);

            try
            {
                while (rd.Read())
                {
                    GetDataFromReader(rd, estimation);
                }
            }
            catch (Exception)
            {
                throw new Exception("No estimation found!");
            }
            finally
            {
                rd.Close();
                DBAccess.CloseDB(con);
            }
        }
        public static List<Estimation> ReadAll()
        {
            MySqlConnection con = DBAccess.OpenDB();
            try
            {

                string sql = "SELECT * FROM Estimation";
                List<Estimation> list = new List<Estimation>();
                MySqlDataReader reader = DBAccess.ExecuteReader(sql, con);

                while (reader.Read())
                {
                    Estimation temp = new Estimation();
                    GetDataFromReader(reader, temp);
                    list.Add(temp);
                }

                return list;
            }
            catch (Exception)
            {
                return new List<Estimation>();
            }
            finally
            {
                DBAccess.CloseDB(con);
            }
        }
        private static void GetDataFromReader(MySqlDataReader rdr, Estimation estimation)
        {
            estimation.EstimationID = rdr.GetInt32("EstimationID");
            estimation.Player = DBPlayer.ReadAll().Find(x => x.PlayerID.Equals(rdr.GetInt32("PlayerID")));
            estimation.Video = DBVideo.ReadAll().Find(x => x.VideoID.Equals(rdr.GetInt32("VideoID")));
            estimation.Difference = rdr.GetInt32("Difference");
        }
    }
}
