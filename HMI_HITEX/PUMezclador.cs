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
    public partial class PUMezclador : Form
    {

        bool vba;
        bool val;
        bool ag;
        bool dos;
        bool evp1;
        bool evp2;
        bool evtdi;
        bool evtan;
        bool velocidad;
        bool Vtdi2;

        private Plc plc = null;
        System.Collections.BitArray salidasPLCbits;
        public PUMezclador()
        {
            InitializeComponent();

            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();

            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);
            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            vba = salidasPLCbits[19];
            val = salidasPLCbits[20];
            ag = (bool)plc.Read("DB1.DBX17.6"); //MODIFICAR!!!!!
            //ag = false;
            dos = salidasPLCbits[12];
            evp1 = salidasPLCbits[4];
            evp2 = salidasPLCbits[7];
            evtdi = salidasPLCbits[10];
            evtan = salidasPLCbits[11];
            velocidad = false;
            Vtdi2 = (bool)plc.Read("DB1.DBX40.0");

            if (val)
            {
                velocidad = true;
            }
            else
            {
                velocidad = false;
            };

            if (ag)
            {
                pictureBox2.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ag = false;
            }
            else
            {
                pictureBox2.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ag = true;
            };

            if (velocidad)
            {
                pictureBox5.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                velocidad = false;
            }
            else if (val)
            {
                pictureBox5.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                velocidad = true;
            };

            if (evtan)
            {
                pictureBox6.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evtan = false;
            }
            else
            {
                pictureBox6.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evtan = true;
            };

            if (dos)
            {
                pictureBox7.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                dos = false;
            }
            else
            {
                pictureBox7.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                dos = true;
            };

            if (evp1)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evp1 = false;
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evp1 = true;
            };

            if (evp2)
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evp2 = false;
            }
            else
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evp2 = true;
            };

            if (evtdi)
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evtdi = false;
            }
            else
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evtdi = true;
            };

            if (Vtdi2)
            {
                pictureBox8.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                Vtdi2 = false;
            }
            else
            {
                pictureBox8.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                Vtdi2 = true;
            };

            //COLOCACION CENTRO
            Mezclador.Controls.Add(SP1C);
            SP1C.Location = new Point(140, 115);
            SP1C.Controls.Add(SP2C);
            SP2C.Location = new Point(30, 0);

            Mezclador.Controls.Add(TubTDIC);
            TubTDIC.Location = new Point(225, 10);

            Mezclador.Controls.Add(MotorMM);
            MotorMM.Location = new Point(135, 40);

            Mezclador.Controls.Add(FSP1C);
            FSP1C.Location = new Point(80, 155);

            Mezclador.Controls.Add(FleSP2C);
            FleSP2C.Location = new Point(220, 155);

            Mezclador.Controls.Add(FSTDIC);
            FSTDIC.Location = new Point(280, 70);
            //FIN COLOCACION CENTRO
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (ag)
            {
                pictureBox2.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                ag = false;
                plc.Write("DB1.DBX1.1", true);
            }
            else
            {
                pictureBox2.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ag = true;
                plc.Write("DB1.DBX1.1", false);
            };
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            if (velocidad)
            {
                pictureBox5.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                velocidad = false;
                //vba = false;
                //val = true;
                plc.Write("DB1.DBX0.7", false);
                plc.Write("DB1.DBX1.0", true);

            }
            else
            {
                pictureBox5.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                velocidad = true;
                //vba = true;
                //val = false;
                plc.Write("DB1.DBX0.7", true);
                plc.Write("DB1.DBX1.0", false);
            };
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            if (evtan)
            {
                pictureBox6.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evtan = false;
                plc.Write("DB1.DBX15.2", true);
            }
            else
            {
                pictureBox6.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evtan = true;
                plc.Write("DB1.DBX15.2", false);
            };
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            if (dos)
            {
                pictureBox7.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                dos = false;
                plc.Write("DB1.DBX15.4", true);
            }
            else
            {
                pictureBox7.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                dos = true;
                plc.Write("DB1.DBX15.4", false);
            };
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (evp1)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evp1 = false;
                plc.Write("DB1.DBX14.4", true);
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evp1 = true;
                plc.Write("DB1.DBX14.4", false);
            };
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (evp2)
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evp2 = false;
                plc.Write("DB1.DBX14.7", true);
            }
            else
            {
                pictureBox3.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evp2 = true;
                plc.Write("DB1.DBX14.7", false);
            };
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (evtdi)
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                evtdi = false;
                plc.Write("DB1.DBX15.3", true);
            }
            else
            {
                pictureBox4.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                evtdi = true;
                plc.Write("DB1.DBX15.3", false);
            };
        }

        private void TmrGlobal_Tick(object sender, EventArgs e)
        {
            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);
            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            bool Avba = salidasPLCbits[19];
            bool Aval = salidasPLCbits[20];
            bool Aag = (bool)plc.Read("DB1.DBX1.1");
            bool Ados = salidasPLCbits[12];
            bool Aevp1 = salidasPLCbits[4];
            bool Aevp2 = salidasPLCbits[7];
            bool Aevtdi = salidasPLCbits[10];
            bool Aevtan = salidasPLCbits[11];

            //Agitador

            if (Avba)
            {
                MotorMM.Image = HMI_HITEX.Properties.Resources._1;
            }
            else if (Aval)
            {
                MotorMM.Image = HMI_HITEX.Properties.Resources._2;
            }
            else
            {
                MotorMM.Image = HMI_HITEX.Properties.Resources._0;
            };

            //P1

            if (Aevp1)
            {
                SP1C.Image = HMI_HITEX.Properties.Resources.C10;
                FSP1C.Visible = true;
            }
            else
            {
                SP1C.Image = HMI_HITEX.Properties.Resources.C00;
                FSP1C.Visible = false;
            };

            //P2

            if (Aevp2)
            {
                SP2C.Image = HMI_HITEX.Properties.Resources.C10;
                FleSP2C.Visible = true;
            }
            else
            {
                SP2C.Image = HMI_HITEX.Properties.Resources.C00;
                FleSP2C.Visible = false;
            };

            //TDI

            if (Aevtdi)
            {
                TubTDIC.Image = HMI_HITEX.Properties.Resources.I101;
                FSTDIC.Visible = true;
            }
            else
            {
                TubTDIC.Image = HMI_HITEX.Properties.Resources.I00;
                FSTDIC.Visible = false;
            };

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            if (Vtdi2)
            {
                pictureBox8.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                Vtdi2 = false;
                plc.Write("DB1.DBX40.1", true);
            }
            else
            {
                pictureBox8.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                Vtdi2 = true;
                plc.Write("DB1.DBX40.1", false);
            };
        }
    }
}
