using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Npgsql;

namespace poject2
{
    public partial class results2 : MaterialForm
    {
        public int res1 = 0, res2 = 0, res3 = 0;
        public double res11, res22, res33;

        private void results2_Load(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("SELECT result2 FROM results2 WHERE login=@uP", con);
            command1.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command2 = new NpgsqlCommand("SELECT result1 FROM results2 WHERE login=@uP", con);
            command2.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command3 = new NpgsqlCommand("SELECT result3 FROM results2 WHERE login=@uP", con);
            command3.Parameters.AddWithValue("@uP", Log.login);

            using (NpgsqlDataReader reader1 = command1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    res1 = Convert.ToInt32(reader1["result2"]);
                }
            }

            using (NpgsqlDataReader reader2 = command2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    res2 = Convert.ToInt32(reader2["result1"]);
                }
            }

            using (NpgsqlDataReader reader3 = command3.ExecuteReader())
            {
                while (reader3.Read())
                {
                    res3 = Convert.ToInt32(reader3["result3"]);
                }
            }

            double res11 = (((double)res1 / 3) * 100);
            double res22 = (((double)res2 / 3) * 100);
            double res33 = (((double)res3 / 3) * 100);

            chart1.Series["s1"].Points.AddXY(0, res11);
            chart1.Series["s1"].Points.AddXY(1, res22);
            chart1.Series["s1"].Points.AddXY(2, res33);


        }

        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123";
        public results2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            student2 s2 = new student2();
            s2.Show();
        }
    }
}
