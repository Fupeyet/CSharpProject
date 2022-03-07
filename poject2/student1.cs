using MaterialSkin.Controls;
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
    public partial class student1 : MaterialForm
    {
        public student1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RESULTS R = new RESULTS();
            R.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student S = new Student();
            S.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu MM = new MainMenu();
            MM.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {        

        }

        private void student1_Load(object sender, EventArgs e)
        {

        }
    }
}
