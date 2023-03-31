using MySql.Data.MySqlClient;

namespace SchaebigeSchaetzungen.Persistence
{
    public interface IDBAccess
    {
        MySqlConnection OpenDB();
        void CloseDB(MySqlConnection con);
        int ExecuteNonQueryWithoutTransaction(string sql);
        int ExecuteNonQuery(string command);
        int ExecuteNonQuery(string command, MySqlConnection con);
        MySqlDataReader ExecuteReader(string sql, MySqlConnection con);
        int GetLastInsertId(MySqlConnection con);
    }
}