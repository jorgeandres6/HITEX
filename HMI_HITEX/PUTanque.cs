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
    public partial class PUTanque : Form
    {

        bool ve;
        bool ag;
        bool bo;
        private Plc plc = null;
        System.Collections.BitArray salidasPLCbits;

        public PUTanque()
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

            ve = (bool)plc.Read("DB1.DBX16.5");

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

            ag= (bool)plc.Read("DB1.DBX18.1");

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

            bo = (bool)plc.Read("DB1.DBX17.6");

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

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (ve)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ve = false;
                plc.Write("DB1.DBX14.5", false);
                plc.Write("DB1.DBX14.6", false);
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ve = true;
                plc.Write("DB1.DBX14.5", true);
                plc.Write("DB1.DBX14.6", true);
            };
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (ag)
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ag = false;
                plc.Write("DB1.DBX0.5", true);
            }
            else
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ag = true;
                plc.Write("DB1.DBX0.5", false);
            };
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (bo)
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                bo = false;
                plc.Write("DB1.DBX0.2", true);
            }
            else
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                bo = true;
                plc.Write("DB1.DBX0.2", false);
            };
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Tanque_Click(object sender, EventArgs e)
        {
            
        }

        private void TmrGlobal_Tick(object sender, EventArgs e)
        {
            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);
            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            //Tanque 2
            if (salidasPLCbits[5] && !salidasPLCbits[17] && salidasPLCbits[6])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._110;
            }
            else if (salidasPLCbits[5] && salidasPLCbits[17] && salidasPLCbits[6])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._111;
            }
            else if (!salidasPLCbits[5] && !salidasPLCbits[17] && !salidasPLCbits[6])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._000;
            }
            else if (!salidasPLCbits[5] && salidasPLCbits[17] && !salidasPLCbits[6])
            {
                Tanque.Image = HMI_HITEX.Properties.Resources._001;
            }
            //fin tanque 2

            //Agitador P2
            if (salidasPLCbits[14])
            {
                Motor.Image = HMI_HITEX.Properties.Resources._1;
            }
            else
            {
                Motor.Image = HMI_HITEX.Properties.Resources._0;
            }
            //Fin Agitador P2
        }
    }
}
