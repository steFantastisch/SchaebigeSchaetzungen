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


    }
}
