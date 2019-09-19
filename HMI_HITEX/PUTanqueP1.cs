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
    public partial class PUTanqueP1 : Form
    {

        bool ve;
        bool ag;
        bool bo;
        private Plc plc = null;
        System.Collections.BitArray salidasPLCbits;

        public PUTanqueP1()
        {
            InitializeComponent();

            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();

            Tanque.Controls.Add(Motor);
            Motor.Location = new Point(100, 0);

            ve = (bool)plc.Read("DB1.DBX16.2");

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

            ag = (bool)plc.Read("DB1.DBX18.0");

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

            bo = (bool)plc.Read("DB1.DBX17.5");

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
                plc.Write("DB1.DBX14.2", false);
                plc.Write("DB1.DBX14.3", false);
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ve = true;
                plc.Write("DB1.DBX14.2", true);
                plc.Write("DB1.DBX14.3", true);
            };
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (ag)
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ag = false;
                plc.Write("DB1.DBX0.4", true);
            }
            else
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ag = true;
                plc.Write("DB1.DBX0.4", false);
            };
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (bo)
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                bo = false;
                plc.Write("DB1.DBX0.1", true);
            }
            else
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                bo = true;
                plc.Write("DB1.DBX0.1", false);
            };
        }

        private void TmrGlobal_Tick(object sender, EventArgs e)
        {
            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);
            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            //Tanque 1
            if (salidasPLCbits[2] && !salidasPLCbits[16] && salidasPLCbits[3])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._110;
            }
            else if (salidasPLCbits[2] && salidasPLCbits[16] && salidasPLCbits[3])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._111;
            }
            else if (!salidasPLCbits[2] && !salidasPLCbits[16] && !salidasPLCbits[3])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._000;
            }
            else if (!salidasPLCbits[2] && salidasPLCbits[16] && !salidasPLCbits[3])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._001;
            }
            //fin tanque 1

            //Agitador P1
            if (salidasPLCbits[13])
            {
                Motor.Image = HMI_HITEX.Properties.Resources._1;
            }
            else
            {
                Motor.Image = HMI_HITEX.Properties.Resources._0;
            }
            //Fin Agitador P1
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
