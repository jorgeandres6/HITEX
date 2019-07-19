using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMI_HITEX
{
    public partial class Proceso : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        public Proceso()
        {
            InitializeComponent();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM recetas", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "id";

            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main v = new Main();
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = HMI_HITEX.Properties.Resources.TanqueP1Bombeando;
            pictureBox4.Image = HMI_HITEX.Properties.Resources.TanqueTDIBombeando;
            Glob.Mpos = 4;
            //pictureBox3.Image = HMI_HITEX.Properties.Resources.MezcladorBombeando;
            timer1.Enabled = true;
            timer2.Enabled = true;

            DateTime today = DateTime.Today;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into reporte(Tipo_receta,Fecha_produccion) values(@rec,@fecha)", con);
                cmd.Parameters.AddWithValue("rec", comboBox1.Text);
                cmd.Parameters.AddWithValue("fecha", today.ToString("yyyy/MM/dd"));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            /*PUMov v = new PUMov();
            v.Show();*/
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = HMI_HITEX.Properties.Resources.Tanque2;
            Glob.Mpos = 1;
            //pictureBox3.Image = HMI_HITEX.Properties.Resources.ProcesoMezcla2;
            timer5.Enabled = true;
            timer1.Stop();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            pictureBox4.Image = HMI_HITEX.Properties.Resources.TanqueTDI;
            timer2.Stop();
            pictureBox2.Image = HMI_HITEX.Properties.Resources.TanqueP2Bombeando;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = HMI_HITEX.Properties.Resources.TanqueP2;
            timer3.Stop();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = HMI_HITEX.Properties.Resources.TanqueP1Cargando;
            pictureBox4.Image = HMI_HITEX.Properties.Resources.TanqueTDICargando;
            pictureBox2.Image = HMI_HITEX.Properties.Resources.TanqueP2Cargando;
            timer4.Enabled = true;

        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = HMI_HITEX.Properties.Resources.TanqueP2;
            pictureBox4.Image = HMI_HITEX.Properties.Resources.TanqueTDI;
            pictureBox1.Image = HMI_HITEX.Properties.Resources.Tanque2;
            timer4.Stop();
        }

        private void Timer5_Tick(object sender, EventArgs e)
        {
            PUSeleccion v = new PUSeleccion();
            v.Show();
            timer5.Stop();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            PUSeleccion v = new PUSeleccion();
            v.Show();
        }

        private void Timer6_Tick(object sender, EventArgs e)
        {
            //Ciclo global
            switch (Glob.Mpos)
            {
                case 2:
                    pictureBox3.Image = HMI_HITEX.Properties.Resources.ProcesoMezcla2_2;
                    break;
                case 3:
                    pictureBox3.Image = HMI_HITEX.Properties.Resources.ProcesoMezcla2_3;
                    break;
                case 4:
                    pictureBox3.Image = HMI_HITEX.Properties.Resources.MezcladorBombeando;
                    break;
                default:
                    pictureBox3.Image = HMI_HITEX.Properties.Resources.ProcesoMezcla2;
                    break;
            }
        }
    }
}
