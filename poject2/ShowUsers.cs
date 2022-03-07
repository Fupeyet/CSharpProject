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
    public partial class ShowUsers : MaterialForm
    {
        public ShowUsers()
        {
            InitializeComponent();
        }

        private void dataGridView1_USERS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=papich");
        MySqlCommand command;
        private void ShowUsers_Load(object sender, EventArgs e)
        {
            FillDGV();
        }
        public void FillDGV()
        {
            string selectQuery = "SELECT * FROM `users`";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView1_USERS.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin A = new Admin();
            A.Show();
        }

        private void dataGridView1_USERS_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView1_USERS.CurrentRow.Cells[0].Value.ToString();
            textBoxLogin.Text = dataGridView1_USERS.CurrentRow.Cells[1].Value.ToString();
            textBoxPass.Text = dataGridView1_USERS.CurrentRow.Cells[2].Value.ToString();
            textBoxName.Text = dataGridView1_USERS.CurrentRow.Cells[3].Value.ToString();
            textBoxSurname.Text = dataGridView1_USERS.CurrentRow.Cells[4].Value.ToString();
            textBoxRank.Text = dataGridView1_USERS.CurrentRow.Cells[5].Value.ToString();
            textBoxResult.Text = dataGridView1_USERS.CurrentRow.Cells[6].Value.ToString();
        }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public void executeMyQuary(string query)
        {
            try 
            {
                openConnection();
                command = new MySqlCommand(query, connection);

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
                closeConnection();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE users SET login='"+textBoxLogin.Text+"',password='"+textBoxPass.Text+"',name='"+textBoxName.Text+"',surname='"+textBoxSurname.Text+"',rank='"+textBoxRank.Text+"',result='"+textBoxResult.Text+"' WHERE id ="+int.Parse(textBoxID.Text);
            executeMyQuary(updateQuery);
            FillDGV();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM `users` WHERE id="+int.Parse(textBoxID.Text);
            executeMyQuary(deleteQuery);
            FillDGV();
        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
