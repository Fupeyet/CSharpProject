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
    public partial class student3 : MaterialForm
    {
        public student3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            test3 t3 = new test3();
            t3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            results3 r3 = new results3();
            r3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}
