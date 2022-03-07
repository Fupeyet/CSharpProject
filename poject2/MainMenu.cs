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
    public partial class MainMenu : MaterialForm
    {
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123;";
        public int res1, res2, res3, rres1, rres2, rres3, rrres1, rrres2, rrres3;
        public string nameUser;

        public MainMenu()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            student1 S1 = new student1();
            S1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Theory T = new Theory();
            T.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Primeri T = new Primeri();
            T.Show();
        }

        private void MainMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Red, 20);
            p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLines(p, new Point[] { new Point(chart1.Location.X + chart1.Width / 2, chart1.Location.Y + chart1.Height), new Point(chart1.Location.X + chart1.Width / 2, chart4.Location.Y + chart4.Height / 2), new Point(chart1.Location.X + chart1.Width / 2, chart4.Location.Y + chart4.Height / 2), new Point(chart4.Location.X, chart4.Location.Y + chart4.Height / 2) });
            g.DrawLines(p, new Point[] { new Point(chart2.Location.X + chart2.Width / 2, chart2.Location.Y + chart2.Height), new Point(chart4.Location.X + chart4.Width / 2, chart4.Location.Y) });
            g.DrawLines(p, new Point[] { new Point(chart3.Location.X + chart3.Width / 2, chart3.Location.Y + chart3.Height), new Point(chart3.Location.X + chart3.Width / 2, chart4.Location.Y + chart4.Height / 2), new Point(chart4.Location.X + chart4.Width, chart4.Location.Y + chart4.Height / 2) });
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            certify c = new certify();
            c.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Theory T = new Theory();
            T.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Theory T = new Theory();
            T.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            student3 s3 = new student3();
            s3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Primeri T = new Primeri();
            T.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Primeri T = new Primeri();
            T.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            student2 T = new student2();
            T.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();

            RESULTS R = new RESULTS();
            Student S = new Student();

            NpgsqlCommand command1 = new NpgsqlCommand("SELECT result2 FROM results WHERE login=@uP", con);
            command1.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command2 = new NpgsqlCommand("SELECT result1 FROM results WHERE login=@uP", con);
            command2.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command3 = new NpgsqlCommand("SELECT result3 FROM results WHERE login=@uP", con);
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

            NpgsqlCommand command4 = new NpgsqlCommand("SELECT result2 FROM results2 WHERE login=@uP", con);
            command4.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command5 = new NpgsqlCommand("SELECT result1 FROM results2 WHERE login=@uP", con);
            command5.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command6 = new NpgsqlCommand("SELECT result3 FROM results2 WHERE login=@uP", con);
            command6.Parameters.AddWithValue("@uP", Log.login);

            using (NpgsqlDataReader reader4 = command4.ExecuteReader())
            {
                while (reader4.Read())
                {
                    rres1 = Convert.ToInt32(reader4["result2"]);
                }
            }

            using (NpgsqlDataReader reader5 = command5.ExecuteReader())
            {
                while (reader5.Read())
                {
                    rres2 = Convert.ToInt32(reader5["result1"]);
                }
            }

            using (NpgsqlDataReader reader6 = command6.ExecuteReader())
            {
                while (reader6.Read())
                {
                    rres3 = Convert.ToInt32(reader6["result3"]);
                }
            }

            NpgsqlCommand command7 = new NpgsqlCommand("SELECT result2 FROM results3 WHERE login=@uP", con);
            command7.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command8 = new NpgsqlCommand("SELECT result1 FROM results3 WHERE login=@uP", con);
            command8.Parameters.AddWithValue("@uP", Log.login);

            NpgsqlCommand command9 = new NpgsqlCommand("SELECT result3 FROM results3 WHERE login=@uP", con);
            command9.Parameters.AddWithValue("@uP", Log.login);

            using (NpgsqlDataReader reader7 = command7.ExecuteReader())
            {
                while (reader7.Read())
                {
                    rrres1 = Convert.ToInt32(reader7["result2"]);
                }
            }

            using (NpgsqlDataReader reader8 = command8.ExecuteReader())
            {
                while (reader8.Read())
                {
                    rrres2 = Convert.ToInt32(reader8["result1"]);
                }
            }

            using (NpgsqlDataReader reader9 = command9.ExecuteReader())
            {
                while (reader9.Read())
                {
                    rrres3 = Convert.ToInt32(reader9["result3"]);
                }
            }

            double res11 = (((double)res1 / 3) * 100);
            double res22 = (((double)res2 / 3) * 100);
            double res33 = (((double)res3 / 3) * 100);

            double rres11 = (((double)rres1 / 3) * 100);
            double rres22 = (((double)rres2 / 3) * 100);
            double rres33 = (((double)rres3 / 3) * 100);

            double rrres11 = (((double)rrres1 / 3) * 100);
            double rrres22 = (((double)rrres2 / 3) * 100);
            double rrres33 = (((double)rrres3 / 3) * 100);


            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM users WHERE login = @uL", con);
            command.Parameters.AddWithValue("@uL", Log.login);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nameUser = Convert.ToString(reader["FIO"]);
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }
            label5.Text = nameUser;

            chart1.Series["ss1"].Points.AddXY(0, res11);
            chart1.Series["ss1"].Points.AddXY(1, res22);
            chart1.Series["ss1"].Points.AddXY(2, res33);

            chart2.Series["sss1"].Points.AddXY(0, rres11);
            chart2.Series["sss1"].Points.AddXY(1, rres22);
            chart2.Series["sss1"].Points.AddXY(2, rres33);

            chart3.Series["ssss1"].Points.AddXY(0, rrres11);
            chart3.Series["ssss1"].Points.AddXY(1, rrres22);
            chart3.Series["ssss1"].Points.AddXY(2, rrres33);

            double geom1 = Math.Pow(res11 * res22 * res33, 1.0 / 3.0);
            double geom2 = Math.Pow(rres11 * rres22 * rres33, 1.0 / 3.0);
            double geom3 = Math.Pow(rrres11 * rrres22 * rrres33, 1.0 / 3.0);
            label15.Text = Convert.ToString(geom1);
            label19.Text = Convert.ToString(geom2);
            label21.Text = Convert.ToString(geom3);

            double arifm = 0;
            arifm = (geom1 + geom2 + geom3) / 3;        
            label22.Text = Convert.ToString(arifm);

            chart4.Series["obs1"].Points.AddXY(0, geom1);
            chart4.Series["obs1"].Points.AddXY(1, geom2);
            chart4.Series["obs1"].Points.AddXY(2, geom3);

            if (arifm != 0)
            {
                button11.Visible = true;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log L = new Log();
            L.Show();
        }
    }
}
