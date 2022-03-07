using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using MaterialSkin.Controls;

namespace poject2
{
    public partial class Reg : MaterialForm
    {
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123";
        public Reg()
        {
            InitializeComponent();

            textBox3.Text = "Введите имя";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Reg R = new Reg();
            //R.Close();
            this.Close();
        }

        Point lastPoint;
        private void Reg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Reg_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Введите имя")
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Введите имя";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Введите имя")
            {
                MessageBox.Show("Необходимо ввести имя");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Необходимо ввести логин");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Необходимо ввести пароль");
                return;
            }
            if (isUserExist())
                return;

            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO users (FIO, login, pass) VALUES (@FIO, @login, @pass);", con);

            command.Parameters.Add("@FIO", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox1.Text;
            command.Parameters.Add("@login", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox2.Text;
            command.Parameters.Add("@pass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox3.Text;

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Вы успешно зарегистрировались");
            else
                MessageBox.Show("Регистрация не завершена");

        }
        public Boolean isUserExist()
        {
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            db db1 = new db();
            DataTable table = new DataTable();

            NpgsqlDataAdapter adapter1 = new NpgsqlDataAdapter();

            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * FROM users WHERE login = @uL;", con);
            command1.Parameters.Add("@uL", NpgsqlTypes.NpgsqlDbType.Varchar).Value = textBox1.Text;

            adapter1.SelectCommand = command1;
            adapter1.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует, введите новый");
                return true;
            }
            else
                return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log L = new Log();
            L.Show();
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
                textBox3.UseSystemPasswordChar = true;
        }
    }
}
