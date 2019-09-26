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
            plc.Write("DB1.DBX40.4", true);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX40.4", false);
            this.Close();
            Main v = new Main();
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX40.4", false);
            this.Close();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX40.2", true);
            //button4.Enabled = false;
            //button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int p1 =  Int32.Parse(textBox1.Text);
            int p2 = Int32.Parse(textBox2.Text);
            int tdi = Int32.Parse(textBox3.Text);
            //ushort m1 = Convert.ToUInt16(p1 /10000);
            //ushort m2 = Convert.ToUInt16(p2 / 10000);
            //ushort m3 = Convert.ToUInt16(tdi / 10000);
            ushort m1 = Convert.ToUInt16(p1 / 1);
            ushort m2 = Convert.ToUInt16(p2 / 1);
            ushort m3 = Convert.ToUInt16(tdi / 1);
            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);
            plc.Write("DB1.DBW34", m1);
            plc.Write("DB1.DBW36", m2);
            plc.Write("DB1.DBW38", m3);
            plc.Write("DB1.DBX40.2", false);
            //button1.Enabled = false;
            //button4.Enabled = true;
            plc.Write("DB1.DBX40.2", false);
        }

        private void TmrGlobal_Tick(object sender, EventArgs e)
        {
            var cal = plc.ReadBytes(DataType.DataBlock, 1, 18, 1);

            System.Collections.BitArray Calibracion = new System.Collections.BitArray(cal);

            if (Calibracion[0] || Calibracion[1] || Calibracion[2])
            {
                button1.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;

            }
            else
            {
                button1.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX40.5", true);
            //button4.Enabled = false;
            //button1.Enabled = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX40.6", true);
            //button4.Enabled = false;
            //button1.Enabled = true;
        }
    }
}
