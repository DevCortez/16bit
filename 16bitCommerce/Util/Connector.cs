using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16bitCommerce.Util;

namespace _16bitCommerce.Connector
{
    static class Connector
    {
        static private Dictionary<int, Npgsql.NpgsqlConnection> connection;

        static public Npgsql.NpgsqlConnection Get
        {
            get
            {
                int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

                if (connection == null)
                    connection = new Dictionary<int, Npgsql.NpgsqlConnection>();

                if (connection.Where(x => x.Key == threadId).Count() == 0)
                {
                    connection[threadId] =
                        new Npgsql.NpgsqlConnection(
                            string.Format("Host={0};Username={1};Password={2};Database={3}",
                                GlobalConfiguration.server,
                                GlobalConfiguration.username,
                                GlobalConfiguration.password,
                                GlobalConfiguration.database
                                )
                        );

                    //connection[threadId].OpenAsync();
                    connection[threadId].Open();
                }
                
                return connection[threadId];
            }
        }
    }
}
