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
    public partial class Teacher : MaterialForm
    {
        NpgsqlConnection connection;
        public string nameUser, surnameUser;
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log L = new Log();
            L.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherCheck TC = new TeacherCheck();
            TC.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherResult TR = new TeacherResult();
            TR.Show();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123");
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM users WHERE login = @login", connection);
            command.Parameters.AddWithValue("@login", Log.login);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nameUser = Convert.ToString(reader["FIO"]);             
            }
            if (!reader.IsClosed && reader != null)
            {
                reader.Close();
            }
            label4.Text = nameUser;
        }
    }
}
