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
    public partial class Theory : MaterialForm
    {
        public Theory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu s1 = new MainMenu();
            s1.Show();
        }

        private void Theory_Load(object sender, EventArgs e)
        {

        }
    }
}
