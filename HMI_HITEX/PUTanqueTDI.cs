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
    public partial class PUTanqueTDI : Form
    {
        bool ve;
        bool ag;
        bool bo;
        private Plc plc = null;
        System.Collections.BitArray salidasPLCbits;

        public PUTanqueTDI()
        {
            InitializeComponent();

            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();

            if (plc.IsConnected)
            {
                Console.WriteLine("conectado");
            }

            Tanque.Controls.Add(Motor);
            Motor.Location = new Point(100, 0);

            ve = (bool)plc.Read("DB1.DBX17.0");

            if (ve)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ve = false;
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ve = true;
            };

            ag = (bool)plc.Read("DB1.DBX18.2");

            if (ag)
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ag = false;
            }
            else
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ag = true;
            };

            bo = (bool)plc.Read("DB1.DBX17.7");

            if (bo)
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                bo = false;
            }
            else
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                bo = true;
            };
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (ve)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ve = false;
                plc.Write("DB1.DBX15.0", false);
                plc.Write("DB1.DBX15.1", false);
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ve = true;
                plc.Write("DB1.DBX15.0", true);
                plc.Write("DB1.DBX15.1", true);
            };
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (ag)
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ag = false;
                plc.Write("DB1.DBX0.6", true);
            }
            else
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ag = true;
                plc.Write("DB1.DBX0.6", false);
            };
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (bo)
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                bo = false;
                plc.Write("DB1.DBX0.3", true);
            }
            else
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                bo = true;
                plc.Write("DB1.DBX0.3", false);
            };
        }

        private void TmrGlobal_Tick(object sender, EventArgs e)
        {
            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);
            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            //Tanque TDI
            if (salidasPLCbits[8] && !salidasPLCbits[18] && salidasPLCbits[9])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._110;
            }
            else if (salidasPLCbits[8] && salidasPLCbits[18] && salidasPLCbits[9])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._111;
            }
            else if (!salidasPLCbits[8] && !salidasPLCbits[18] && !salidasPLCbits[9])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._000;
            }
            else if (!salidasPLCbits[8] && salidasPLCbits[18] && !salidasPLCbits[9])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._001;
            }
            //fin tanque TDI

            //Agitador TDI
            if (salidasPLCbits[15])
            {
                Motor.Image = HMI_HITEX.Properties.Resources._1;
            }
            else
            {
                Motor.Image = HMI_HITEX.Properties.Resources._0;
            }
            //Fin Agitador TDI
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
