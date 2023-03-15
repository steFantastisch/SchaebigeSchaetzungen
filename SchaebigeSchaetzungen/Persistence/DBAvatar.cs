using MySql.Data.MySqlClient;
using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Persistence
{
    public class DBAvatar
    {
        //public static void Insert(Avatar avatar)
        //{
        //    MySqlConnection con = DBAccess.OpenDB();
        //    string sql = $"Insert into Avatar (Name, Type, Path) Values (@name, @type, @path)";

        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@name", avatar.Name);
        //    cmd.Parameters.AddWithValue("@type", avatar.Type);
        //    cmd.Parameters.AddWithValue("@path", avatar.Path);

        //    int anz = cmd.ExecuteNonQuery();

        //    if (anz != 1)
        //        throw new Exception("Speichern fehlgeschlagen!");

        //    avatar.AvatarID = DBAccess.GetLastInsertId(con);
        //    DBAccess.CloseDB(con);
        //}

        //public static void Read(Avatar avatar)
        //{
        //    MySqlConnection con = DBAccess.OpenDB();

        //    string sql = $"SELECT * FROM Avatar WHERE AvatarID = '{avatar.AvatarID}'";
        //    MySqlDataReader rd = DBAccess.ExecuteReader(sql, con);

        //    try
        //    {
        //        while (rd.Read())
        //        {
        //            GetDataFromReader(rd, avatar);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Kein Avatar gefunden!");
        //    }
        //    finally
        //    {
        //        rd.Close();
        //        DBAccess.CloseDB(con);
        //    }
        //}

        //public static void Update(Avatar avatar)
        //{
        //    MySqlConnection con = DBAccess.OpenDB();
        //    string sql = $"UPDATE Avatar SET Name= @name, Type= @type, Path= @path, WHERE AvatarID = @id";

        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@name", avatar.Name);
        //    cmd.Parameters.AddWithValue("@type", avatar.Type);
        //    cmd.Parameters.AddWithValue("@path", avatar.Path);
        //    cmd.Parameters.AddWithValue("@id", avatar.AvatarID);

        //    int anz = cmd.ExecuteNonQuery();
        //    DBAccess.CloseDB(con);

        //    if (anz != 1)
        //        throw new Exception("Änderungen konnten nicht gespeichert werden!");

        //}

        //public static void Delete(Avatar avatar)
        //{
        //    string sql = $"DELETE FROM Avatar WHERE AvatarID={avatar.AvatarID}";
        //    int anz = DBAccess.ExecuteNonQuery(sql);

        //    if (anz == 0)
        //    {
        //        throw new Exception("Avatar konnte nicht gelöscht werden!");
        //    }
        //}

        //private static void GetDataFromReader(MySqlDataReader rdr, Avatar avatar)
        //{
        //    avatar.AvatarID = rdr.GetInt32("AvatarID");
        //    avatar.Name = rdr.GetString("Name");
        //    avatar.Type = rdr.GetString("Type");
        //    avatar.Path = (byte[])rdr["Path"];
        //}
    }
}
