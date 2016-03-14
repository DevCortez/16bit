using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16bitCommerce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Util.GlobalConfiguration.database = "Testing";
            Util.GlobalConfiguration.password = "784512";
            Util.GlobalConfiguration.server = "localhost";
            Util.GlobalConfiguration.username = "postgres";

            var connection = Connector.Connector.Get;
            int i;

            /*var reader = new Npgsql.NpgsqlCommand("select * from dump.product", connection).ExecuteReader();

            

            while (reader.Read())
            {
                DateTime.Now.ToBinary                //Console.WriteLine(reader.GetFieldValue<string>(1));
            }*/

            Int64 now = DateTime.Now.ToBinary();

            //Parallel.For(0, 3000000, x => new Npgsql.NpgsqlCommand(string.Format("INSERT INTO dump.product2 (price, stock, lastmodified) VALUES ({0}, {0}, {1})", x, now), Connector.Connector.Get).ExecuteNonQuery());

            for (i=0;i<4000000;i++)
                new Npgsql.NpgsqlCommand(string.Format("INSERT INTO dump.product2 (price, stock, lastmodified) VALUES ({0}, {0}, {1})", i, now), connection).ExecuteNonQuery();

        }
    }
}
