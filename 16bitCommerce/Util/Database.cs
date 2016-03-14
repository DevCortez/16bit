using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16bitCommerce.Util
{
    static class Database
    {
        static private string[] tableInitializationScripts = {
            "CREATE TABLE IF NOT EXISTS login(userid serial, username TEXT, password char(32), accessmask bigint, primary key(userid))",
            "CREATE TABLE IF NOT EXISTS product(productid serial, name TEXT, price real, stock int, lastmodified bigint, primary key(productid))"
        };


        public static void InitializeDatabase()
        {
            var connection = Connector.Connector.Get;

            foreach(var script in tableInitializationScripts)
                new Npgsql.NpgsqlCommand(script, connection).ExecuteNonQuery();
        }
    }
}
