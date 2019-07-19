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
    public partial class PUSeleccion : Form
    {
        public PUSeleccion()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Glob.Mpos = 1;
            this.Hide();
            PUMov v = new PUMov();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Glob.Mpos = 2;
            this.Hide();
            PUMov v = new PUMov();
            v.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Glob.Mpos = 3;
            this.Hide();
            PUMov v = new PUMov();
            v.Show();
        }
    }
}
