using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace HMI_HITEX
{
    public partial class PUSeleccion : Form
    {
        private Plc plc = null;

        public PUSeleccion()
        {
            InitializeComponent();
            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX26.0", true);
            Glob.Mpos = 1;
            this.Hide();
            PUMov v = new PUMov();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX26.1", true);
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
            plc.Write("DB1.DBX26.2", true);
            Glob.Mpos = 3;
            this.Hide();
            PUMov v = new PUMov();
            v.Show();
        }
    }
}
