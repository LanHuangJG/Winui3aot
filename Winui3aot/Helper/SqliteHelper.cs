using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace Winui3aot.Helper
{
    public class SqliteHelper
    {
        public static void insertOrUpdate(string key,string value)
        {
            string insertOrUpdateQuery = $@"
            INSERT OR REPLACE INTO settings (Key, Value)
            VALUES (@key, @value)
            ON CONFLICT(Key) DO UPDATE SET
                Value=excluded.Value";
            var cmd = new SqliteCommand(insertOrUpdateQuery, App.con);
            cmd.Parameters.AddWithValue("@key", key);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.ExecuteNonQuery();
        }

        public static string getValue(string key)
        {
            string selectQuery = $@"
            SELECT Value FROM settings WHERE Key = @key";
            var cmd = new SqliteCommand(selectQuery, App.con);
            cmd.Parameters.AddWithValue("@key", key);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return null;
        }
    }
}
