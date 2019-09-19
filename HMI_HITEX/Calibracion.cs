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
    public partial class Calibracion : Form
    {

        private Plc plc = null;

        public Calibracion()
        {
            InitializeComponent();

            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main v = new Main();
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX40.2", true);
            button4.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int p1 =  Int32.Parse(textBox1.Text);
            int p2 = Int32.Parse(textBox2.Text);
            int tdi = Int32.Parse(textBox3.Text);
            float m1 = p1/5000;
            float m2 = p2 / 5000;
            float m3 = tdi / 5000;
            plc.Write("DB1.DBW34", m1);
            plc.Write("DB1.DBW36", m2);
            plc.Write("DB1.DBW38", m3);
            plc.Write("DB1.DBX40.2", false);
            button1.Enabled = false;
            button4.Enabled = true;
            plc.Write("DB1.DBX40.2", false);
        }

        private void TmrGlobal_Tick(object sender, EventArgs e)
        {
            if ((bool)plc.Read("DB1.DBX40.3"))
            {
                button1.Enabled = true;

            }
        }
    }
}
