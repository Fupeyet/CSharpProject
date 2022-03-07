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
    public partial class Log : MaterialForm
    {
        public static string login;
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123;";
        public static string FIO, pass;
        public Log()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);

            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;
            login = textBox1.Text;
            DataTable table = new DataTable();

            //MySqlDataAdapter adapter = new MySqlDataAdapter();

            con.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * FROM users WHERE login=@uP AND pass=@uPa", con);
            command1.Parameters.AddWithValue("@uP", textBox1.Text);
            command1.Parameters.AddWithValue("@uPa", textBox2.Text);

            //NpgsqlDataAdapter nda = new NpgsqlDataAdapter("SELECT * FROM users WHERE FIO= '" + textBox1.Text + "' AND pass='" + textBox2.Text + "'", con);

            NpgsqlDataReader reader = command1.ExecuteReader();
            //nda.Fill(table);
            bool isreaderread = reader.Read();
            if (reader.HasRows)
            {
                if (reader["login"].ToString() == textBox1.Text)
                {
                    if (reader["pass"].ToString() == textBox2.Text)
                    {
                        if (reader["role"].ToString() == "Студент")
                        {
                            login = Convert.ToString(reader["login"]);
                            pass = Convert.ToString(reader["pass"]);
                            FIO = Convert.ToString(reader["FIO"]);
                            this.Hide();
                            MainMenu MM = new MainMenu();
                            MM.Show();
                            MessageBox.Show("Вы успешно авторизовались как Студент");
                        }
                    }

                }
                if (reader["login"].ToString() == textBox1.Text)
                {
                    if (reader["pass"].ToString() == textBox2.Text)
                    {
                        if (reader["role"].ToString() == "Администратор")
                        {
                            login = Convert.ToString(reader["login"]);
                            pass = Convert.ToString(reader["pass"]);
                            FIO = Convert.ToString(reader["FIO"]);
                            this.Hide();
                            Admin A = new Admin();
                            A.Show();
                            MessageBox.Show("Вы успешно авторизовались как Администратор");
                        }
                    }
                }
                if (reader["login"].ToString() == textBox1.Text)
                {
                    if (reader["pass"].ToString() == textBox2.Text)
                    {
                        if (reader["role"].ToString() == "Учитель")
                        {
                            login = Convert.ToString(reader["login"]);
                            pass = Convert.ToString(reader["pass"]);
                            FIO = Convert.ToString(reader["FIO"]);
                            this.Hide();
                            Teacher T = new Teacher();
                            T.Show();
                            MessageBox.Show("Вы успешно авторизовались как Учитель");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введённых вами данных!");
                }
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {

        }

        Point lastPoint;
        private void Log_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Log_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg r = new Reg();
            r.Show();
        }

        private void Log_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
                textBox2.UseSystemPasswordChar = true;
        }
    }
}
