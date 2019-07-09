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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Usuario v = new Usuario();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Proceso v = new Proceso();
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formula v = new Formula();
            v.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reporte v = new Reporte();
            v.Show();
        }
    }
}
