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
    public partial class test3 : MaterialForm
    {
        public string valve1, valve2, valve3, valve4, valve5, valve6, valve7, valve8, valve9;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            student3 s3 = new student3();
            s3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (valve1 == textBox1.Text && valve2 == textBox2.Text && valve3 == textBox3.Text)
            {
                Result1 = 3;
            }
            else if ((valve2 == textBox2.Text && valve1 == textBox1.Text) || (valve1 == textBox1.Text && valve3 == textBox3.Text) || (valve2 == textBox2.Text && valve3 == textBox3.Text))
            {
                Result1 = 2;
            }
            else if ((valve3 == textBox3.Text) || (valve2 == textBox2.Text) || (valve1 == textBox1.Text))
            {
                Result1 = 1;
            }
            else
                Result1 = 0;


            if (valve4 == textBox7.Text && valve5 == textBox8.Text && valve6 == textBox9.Text)
            {
                Result2 = 3;
            }
            else if ((valve5 == textBox8.Text && valve4 == textBox7.Text) || (valve4 == textBox7.Text && valve6 == textBox9.Text) || (valve5 == textBox8.Text && valve6 == textBox9.Text))
            {
                Result2 = 2;
            }
            else if ((valve6 == textBox9.Text) || (valve5 == textBox8.Text) || (valve4 == textBox7.Text))
            {
                Result2 = 1;
            }
            else
                Result2 = 0;


            if (valve7 == textBox4.Text && valve8 == textBox5.Text && valve9 == textBox6.Text)
            {
                Result3 = 3;
            }
            else if ((valve8 == textBox5.Text && valve7 == textBox4.Text) || (valve7 == textBox4.Text && valve9 == textBox6.Text) || (valve8 == textBox5.Text && valve9 == textBox6.Text))
            {
                Result3 = 2;
            }
            else if ((valve9 == textBox6.Text) || (valve8 == textBox5.Text) || (valve7 == textBox4.Text))
            {
                Result3 = 1;
            }
            else
                Result3 = 0;

            db db1 = new db();
            string insertQuery = "insert into results3 (FIO, login, pass, result1, result2, result3) values ('" + Log.FIO + "', '" + Log.login + "', '" + Log.pass + "','" + Result1 + "', '" + Result2 + "','" + Result3 + "');";
            executeMyQuary(insertQuery);
        }

        int Result1, Result2, Result3;
        public string nameUser, surnameUser;
        public NpgsqlConnection connection = null;
        NpgsqlCommand command;
        public test3()
        {
            InitializeComponent();

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;

            connection = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123");
            connection.Open();
            int p = 0;
            int p1 = 0;
            string asd1 = "Умение";
            string asd2 = "Полнота";
            string asd3 = "Целостность";
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM qa3 WHERE typeq='" + asd1 + "'", connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                p++;
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }
            string[] questions1 = new string[p];
            string[] answers1 = new string[p];

            NpgsqlCommand command1 = new NpgsqlCommand("SELECT * FROM qa3 WHERE typeq='" + asd1 + "'", connection);
            NpgsqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                questions1[p1] = Convert.ToString(reader1["question"]);
                answers1[p1] = Convert.ToString(reader1["answer"]);
                p1++;
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }

            Random rnd = new Random();
            int value1 = 0;
            int value2 = 1;
            int value3 = 2;

            label2.Text = questions1[value1];
            label3.Text = questions1[value2];
            label4.Text = questions1[value3];

            valve1 = answers1[value1];
            valve2 = answers1[value2];
            valve3 = answers1[value3];


            int p2 = 0;
            int p3 = 0;
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT * FROM qa3 WHERE typeq='" + asd2 + "'", connection);
            NpgsqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                p2++;
            }
            if (!reader2.IsClosed && reader2 != null)
            {
                reader2.Close();
            }
            string[] questions2 = new string[p2];
            string[] answers2 = new string[p2];

            NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM qa3 WHERE typeq='" + asd2 + "'", connection);
            NpgsqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                questions2[p3] = Convert.ToString(reader3["question"]);
                answers2[p3] = Convert.ToString(reader3["answer"]);
                p3++;
            }
            if (!reader3.IsClosed && reader3 != null)
            {
                reader3.Close();
            }

            int value4 = 0;
            int value5 = 1;
            int value6 = 2;

            label12.Text = questions2[value4];
            label13.Text = questions2[value5];
            label14.Text = questions2[value6];

            valve4 = answers2[value4];
            valve5 = answers2[value5];
            valve6 = answers2[value6];

            int p4 = 0;
            int p5 = 0;
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM qa3 WHERE typeq='" + asd3 + "'", connection);
            NpgsqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                p4++;
            }
            if (!reader4.IsClosed && reader4 != null)
            {
                reader4.Close();
            }
            string[] questions3 = new string[p4];
            string[] answers3 = new string[p4];

            NpgsqlCommand command5 = new NpgsqlCommand("SELECT * FROM qa3 WHERE typeq='" + asd3 + "'", connection);
            NpgsqlDataReader reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                questions3[p5] = Convert.ToString(reader5["question"]);
                answers3[p5] = Convert.ToString(reader5["answer"]);
                p5++;
            }
            if (!reader5.IsClosed && reader != null)
            {
                reader5.Close();
            }

            int value7 = 0;
            int value8 = 1;
            int value9 = 2;

            label9.Text = questions3[value7];
            label10.Text = questions3[value8];
            label11.Text = questions3[value9];

            valve7 = answers3[value7];
            valve8 = answers3[value8];
            valve9 = answers3[value9];

            connection.Close();
        }

        private void test3_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123");
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM users WHERE login = @uL", connection);
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

            connection.Close();
        }
        public void executeMyQuary(string query)
        {
            try
            {
                connection.Open();
                command = new NpgsqlCommand(query, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Запрос выполнен");
                }
                else
                    MessageBox.Show("Запрос не выполнен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
