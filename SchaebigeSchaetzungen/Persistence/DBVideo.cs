using MySql.Data.MySqlClient;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBVideo
    {
        public static void Insert(Video v)
        {
            String sql = $"Insert into Video (Title, URL, Views, Available, German, Timecode, Creator) " +
                $"values ('{v.Title}', '{v.Url}', {v.Views} , {v.Available}, {v.German}, {v.Timecode}, {v.Creator})";

            MySqlConnection con = DBAccess.OpenDB();

            int ret = DBAccess.ExecuteNonQuery(sql, con);


            if (ret != 1)
                throw new Exception("Insert failed!");

            v.VideoID = DBAccess.GetLastInsertId(con);
            DBAccess.CloseDB(con);
        }

        public static void Update(Video v)
        {
            //Video bak = new Video(v.VideoID);
            //try
            //{
            //    DBAccess.BeginTransaktion();

            //    // wurde der Status geändert?
            //    if (v.Status != bak.Status)
            //    {
            //        Protokoll p = new Protokoll(v);
            //        p.Speichern();
            //    }

            //    string sql = $"UPDATE Video SET Status='{(int)v.Status}', benutzer='{v.Benutzer}', meldungstext='{v.Meldungstext}',Datum='{v.Datum.ToString("yyyy-MM-dd")}' WHERE Id={v.Id} AND zeitstempel='{v.Zeitstempel.ToString("yyyy-MM-dd HH:mm:ss")}'";
            //    int anz = DBAccess.ExecuteNonQuery(sql);



            //    if (anz != 1)
            //        throw new MultiAccessException("Änderungen konnten nicht gespeichert werden! \nMöglicherweise gibt es dieses Video nicht mehr oder die Daten des Videos wurden in der Zwischenzeit geändert und stimmen nicht mehr mit Ihrem letzten \nKentnissstand überein!");

            //    DBAccess.Commit();
            //}
            //catch (Exception)
            //{
            //    DBAccess.Rollback();

            //    // gefangene Exeception weiterwerfen
            //    throw;
            //}

        }

        public static void Loeschen(Video v)
        {
            // Variante mit "logischem" Löschen:
            //v.Status = VideoStatus.Gelöscht;
            //DBVideo.Update(v);

            // Variante mit "echtem" Löschen:
            /*
            string sql = $"DELETE FROM Video WHERE Id={t.Id}";
            int anz = DBAccess.ExecuteNonQuery(sql);

            if (anz == 0)
            {
              throw new Exception("Video konnte nicht gelöscht werden! \nMöglicherweise gibt es dieses Video nicht mehr!");
            }
            */
        }

        private static void GetDataFromReader(MySqlDataReader rdr, Video v)
        {
            v.VideoID = rdr.GetInt32("id");
            v.Title = rdr.GetString("title");
            v.Url = rdr.GetString("url");
            v.Views = rdr.GetInt32("views");
            v.Available = rdr.GetBoolean("Available");
            v.German = rdr.GetBoolean("Available");
            v.Timecode = rdr.GetBoolean("Available");


            int temp = rdr.GetInt32("creator");
            /*
             * TODO
             * Something like 
             * v.Creator = Player.ListAllPlayer.Find(temp);
            */


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



        public static List<Video> AlleLesen()
        {
            MySqlConnection con = DBAccess.OpenDB();
            try
            {

                string sql = "SELECT * FROM Video";
                List<Video> list = new List<Video>();
                MySqlDataReader reader = DBAccess.ExecuteReader(sql, con);

                while (reader.Read())
                {
                    Video v = new Video();
                    GetDataFromReader(reader, v);
                    list.Add(v);
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
