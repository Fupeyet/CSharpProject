using MaterialSkin.Controls;
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
    public partial class Admin : MaterialForm
    {
        MySqlConnection connection = null;
        public string nameUser, surnameUser;
        public Admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log L = new Log();
            L.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowUsers SU = new ShowUsers();
            SU.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=papich");
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @login", connection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Log.login;
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
            label2.Text = nameUser;
            label3.Text = surnameUser;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
