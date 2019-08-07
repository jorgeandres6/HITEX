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
    public partial class PUTanque : Form
    {

        bool ve = false;
        bool vs = false;
        bool ag = false;
        bool bo = false;

        public PUTanque()
        {
            InitializeComponent();
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
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                ve = true;
            };
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (vs)
            {
                pictureBox2.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                vs = false;
            }
            else
            {
                pictureBox2.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                vs = true;
            };
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
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
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
