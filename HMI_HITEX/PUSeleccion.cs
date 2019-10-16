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
        System.Collections.BitArray salidasPLCbits;

        public PUSeleccion()
        {
            InitializeComponent();
            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();
            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 15, 1);
            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            if (salidasPLCbits[5] || salidasPLCbits[6])
            {
                button1.Visible = true;
                button1.Enabled = true;
                button2.Visible = false;
                button2.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Visible = false;
                button1.Enabled = false;
                button2.Visible = true;
                button2.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX16.0", true);
            //Glob.Mpos = 1;
            this.Close();
            PUMov v = new PUMov();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX26.2", true);
            //Glob.Mpos = 2;
            this.Close();
            PUMov v = new PUMov();
            v.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX26.1", true);
            //Glob.Mpos = 3;
            this.Close();
            PUMov v = new PUMov();
            v.Show();
        }
    }
}
