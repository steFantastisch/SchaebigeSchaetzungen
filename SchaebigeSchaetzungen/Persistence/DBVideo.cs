using MySql.Data.MySqlClient;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBVideo
    {
        public static void Insert(Video v)
        {
            String sql = $"Insert into Video (Title, URL, Views, Available, German, Timecode) " +
                $"values ('{v.Title}', '{v.Url}', {v.Views} , {v.Available}, {v.German}, {v.Timecode})";

            MySqlConnection con = DBAccess.OpenDB();

            int ret = DBAccess.ExecuteNonQuery(sql, con);


            if (ret != 1)
                throw new Exception("Insert failed!");

            v.VideoID = DBAccess.GetLastInsertId(con);
            DBAccess.CloseDB(con);
        }
        public static void Read(Video v)
        {
            MySqlConnection con = DBAccess.OpenDB();

            string sql = $"SELECT * FROM Video WHERE Id = '{v.VideoID}'";
            MySqlDataReader rd = DBAccess.ExecuteReader(sql, con);

            try
            {
                while (rd.Read())
                {
                    GetDataFromReader(rd, v);
                }
            }
            catch (Exception)
            {
                throw new Exception("Kein Video gefunden!");
            }
            finally
            {
                rd.Close();
                DBAccess.CloseDB(con);
            }
        }
        public static void Update(Video video)
        {
            String sql =
                $"Update video " +
                $"set Title ='{video.Title}', " +
                $"URL ='{video.Url}', " +
                $"Views={video.Views}, " +
                $"Available={video.Available}, " +
                $"German={video.German}, " +
                $"Timecode={video.Timecode} " +
                $"where VideoID = {video.VideoID}";

            int anz = DBAccess.ExecuteNonQuery(sql);

            if (anz != 1)
                throw new Exception("Update failed!");
        }
        public static void Delete(Video video)
        {
            /*
             * probably not to implement
            */
        }

        private static void GetDataFromReader(MySqlDataReader rdr, Video v)
        {
            v.VideoID = rdr.GetInt32("id");
            v.Title = rdr.GetString("title");
            v.Url = rdr.GetString("url");
            v.Views = rdr.GetInt32("views");
            v.Available = rdr.GetBoolean("Available");
            v.German = rdr.GetBoolean("German");
            v.Timecode = rdr.GetBoolean("Timecode");
        }
        public static List<Video> ReadAll()
        {
            MySqlConnection con = DBAccess.OpenDB();
            try
            {

                string sql = "SELECT * FROM Video";
                List<Video> list = new List<Video>();
                MySqlDataReader reader = DBAccess.ExecuteReader(sql, con);

                while (reader.Read())
                {
                    Video temp = new Video();
                    GetDataFromReader(reader, temp);
                    list.Add(temp);
                }

                return list;
            }
            catch (Exception)
            {
                return new List<Video>();
            }
            finally
            {
                DBAccess.CloseDB(con);
            }
        }

    }
}
