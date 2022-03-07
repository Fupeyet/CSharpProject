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

namespace poject2
{
    public partial class Student : Form
    {
        public string valve1, valve2, valve3;
        int Result;
        public string nameUser, surnameUser;
        public MySqlConnection connection = null;
        MySqlCommand command;
        public Student()
        {
            InitializeComponent();

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;

            connection = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=papich");
            connection.Open();
            int p = 0;
            int p1 = 0;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `questions`", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                p++;
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }
            string[] questions = new string[p];
            string[] answers = new string[p];

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `questions`", connection);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                questions[p1] = Convert.ToString(reader1["question"]);
                answers[p1] = Convert.ToString(reader1["answer"]);
                p1++;
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }

            Random rnd = new Random();
            int value1 = rnd.Next(0, 10);
            int value2 = rnd.Next(11, 20);
            int value3 = rnd.Next(21, 30);

            label2.Text = questions[value1];
            label3.Text = questions[value2];
            label4.Text = questions[value3];

            valve1 = answers[value1];
            valve2 = answers[value2];
            valve3 = answers[value3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log L = new Log();
            L.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=papich");
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @uL", connection);
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Log.login;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nameUser = Convert.ToString(reader["name"]);
                surnameUser = Convert.ToString(reader["surname"]);
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }
            label7.Text = nameUser;
            label8.Text = surnameUser;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (valve1 == textBox1.Text && valve2 == textBox2.Text && valve3 == textBox3.Text)
            {
                Result = 3;
            }
            else if ((valve2 == textBox2.Text && valve1 == textBox1.Text) || (valve1 == textBox1.Text && valve3 == textBox3.Text) || (valve2 == textBox2.Text && valve3 == textBox3.Text))
            {
                Result = 2;
            }
            else if ((valve3 == textBox3.Text) || (valve2 == textBox2.Text) || (valve1 == textBox1.Text))
            {
                Result = 1;
            }
            else
                Result = 0;


            if (Result == 1)
            {
                MessageBox.Show("Ваш результат 1");
            }
            else if (Result == 2)
            {
                MessageBox.Show("Ваш результат 2");
            }
            else if (Result == 3)
            {
                MessageBox.Show("Ваш результат 3");
            }
            else if (Result == 0)
            {
                MessageBox.Show("Ваш результат 0");
            }
            string res = Convert.ToString(Result);

            db db1 = new db();
            MySqlCommand command1 = new MySqlCommand("UPDATE `users` SET `result`=@uR1 WHERE `login`=@uL1", connection);
            command1.Parameters.AddWithValue("uR1", Result);
            command1.Parameters.AddWithValue("uL1", Log.login);
            command1.ExecuteNonQuery();
        }
    }
}
