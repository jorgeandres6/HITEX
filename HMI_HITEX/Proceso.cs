using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_HITEX
{
    public partial class Proceso : Form
    {
        public Proceso()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main v = new Main();
            v.Show();
        }
    }
}
