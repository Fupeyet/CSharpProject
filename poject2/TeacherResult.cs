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
    public partial class TeacherResult : MaterialForm
    {
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=test123;";
        NpgsqlConnection con;
        NpgsqlCommand command;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public TeacherResult()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher T = new Teacher();
            T.Show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
        }
        public void FillDGV()
        {
            //NpgsqlConnection con = new NpgsqlConnection(connectionString);
            con.Open();
            string selectQuery = "SELECT id, FIO, result1, result2, result3 FROM results";
            DataTable table = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectQuery, con);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void TeacherResult_Load(object sender, EventArgs e)
        {
            con = new NpgsqlConnection(connectionString);
            FillDGV();
        }
    }
}
