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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ADMIN" && textBox2.Text == "ADMIN")
            {
                this.Hide();
                Main v = new Main();
                v.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña errados","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
