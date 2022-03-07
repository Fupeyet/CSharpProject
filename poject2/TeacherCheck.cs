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
    public partial class TeacherCheck : MaterialForm
    {
        NpgsqlConnection connection;
        NpgsqlCommand command;
        public TeacherCheck()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void FillDGV()
        {
            connection = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123");
            connection.Open();
            string selectQuery = "SELECT * FROM qa";
            DataTable table = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView_Answers.DataSource = table;
        }

        private void TeacherCheck_Load(object sender, EventArgs e)
        {
            FillDGV();
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
                closeConnection();
            }
        }

        private void TeacherCheck_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView_Answers_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView_Answers.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView_Answers.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView_Answers.CurrentRow.Cells[2].Value.ToString();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE `questions` SET question='"+textBox2.Text+"',answer='"+textBox3.Text+"' WHERE id ="+int.Parse(textBox1.Text);
            executeMyQuary(updateQuery);
            FillDGV();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM `questions` WHERE id=" + int.Parse(textBox1.Text);
            executeMyQuary(deleteQuery);
            FillDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO `questions`(question, answer) VALUES ('"+textBox2.Text+"','"+textBox3.Text+"')";
            executeMyQuary(insertQuery);
            FillDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher T = new Teacher();
            T.Show();
        }
    }
}
