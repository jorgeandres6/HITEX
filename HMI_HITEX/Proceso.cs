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
    public partial class F1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        public F1()
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

            TP1.Controls.Add(MotorP1);
            MotorP1.Location = new Point(65,0);

            TP2.Controls.Add(MotorP2);
            MotorP2.Location = new Point(65, 0);

            TTDI.Controls.Add(MotorTDI);
            MotorTDI.Location = new Point(65, 0);
            //COLOCACION IZQUIERDA
            Mezclador.Controls.Add(SP1I);
            SP1I.Location = new Point(330, 105);
            SP1I.Controls.Add(SP2I);
            SP2I.Location = new Point(0, 15);

            Mezclador.Controls.Add(TubTDII);
            TubTDII.Location = new Point(315, 10);

            Mezclador.Controls.Add(MotorMMI);
            MotorMMI.Location = new Point(275, 100);

            Mezclador.Controls.Add(FSTDII);
            FSTDII.Location = new Point(255, 10);

            Mezclador.Controls.Add(FSP1I);
            FSP1I.Location = new Point(550, 85);

            Mezclador.Controls.Add(FSP2I);
            FSP2I.Location = new Point(550, 135);

            //FIN IZQUIERDA

            //COLOCACION CENTRO
            Mezclador.Controls.Add(SP1C);
            SP1C.Location = new Point(375, 95);
            SP1C.Controls.Add(SP2C);
            SP2C.Location = new Point(15, 0);

            Mezclador.Controls.Add(TubTDIC);
            TubTDIC.Location = new Point(420, 10);

            Mezclador.Controls.Add(MotorMM);
            MotorMM.Location = new Point(370, 30);

            Mezclador.Controls.Add(FSP1C);
            FSP1C.Location = new Point(330, 120);

            Mezclador.Controls.Add(FleSP2C);
            FleSP2C.Location = new Point(420, 120);

            Mezclador.Controls.Add(FSTDIC);
            FSTDIC.Location = new Point(570, 10);
            //FIN COLOCACION CENTRO

            //COLOCACION DERECHA

            Mezclador.Controls.Add(SP1D);
            SP1D.Location = new Point(260, 100);
            SP1D.Controls.Add(SP2D);
            SP2D.Location = new Point(0, 15);

            Mezclador.Controls.Add(STDID);
            STDID.Location = new Point(475, 100);

            Mezclador.Controls.Add(MotorMMD);
            MotorMMD.Location = new Point(505, 95);

            Mezclador.Controls.Add(FSP1D);
            FSP1D.Location = new Point(200, 80);

            Mezclador.Controls.Add(FlechaSP2D);
            FlechaSP2D.Location = new Point(200, 135);

            Mezclador.Controls.Add(FSTDID);
            FSTDID.Location = new Point(510, 160);

            //FIN COLOCACION DERECHA

            //CENTRO
            SP1C.Visible = false;
            SP2C.Visible = false;
            TubTDIC.Visible = false;
            MotorMM.Visible = false;
            FSP1C.Visible = false;
            FleSP2C.Visible = false;
            FSTDIC.Visible = false;
            //FIN CENTRO

            //IZQUIERDA
            SP1I.Visible = false;
            SP2I.Visible = false;
            TubTDII.Visible = false;
            MotorMMI.Visible = false;
            FSP1I.Visible = false;
            FSP2I.Visible = false;
            FSTDII.Visible = false;
            //FIN IZQUIERDA

            //DERECHA
            SP1D.Visible = false;
            SP2D.Visible = false;
            STDID.Visible = false;
            MotorMMD.Visible = false;
            FSP1D.Visible = false;
            FlechaSP2D.Visible = false;
            FSTDID.Visible = false;
            //FIN DERECHA
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
            TP1.Image = HMI_HITEX.Properties.Resources._111;
            TTDI.Image = HMI_HITEX.Properties.Resources._111;
            //Glob.Mpos = 4;

            //TUBERIAS
            SP1D.Image = HMI_HITEX.Properties.Resources.D111;
            STDID.Image = HMI_HITEX.Properties.Resources.D11;

            TubTDIC.Image = HMI_HITEX.Properties.Resources.I112;
            SP1C.Image = HMI_HITEX.Properties.Resources.C11;

            SP1I.Image = HMI_HITEX.Properties.Resources.I11;
            TubTDII.Image = HMI_HITEX.Properties.Resources.C111;
            //FIN TUBERIAS

            //MOTOR MEZCLADOR
            MotorMM.Image = HMI_HITEX.Properties.Resources._1;

            MotorMMD.Image = HMI_HITEX.Properties.Resources._1;

            MotorMMI.Image = HMI_HITEX.Properties.Resources._1;
            //FIN MOTOR MEZCLADOR

            button3.Enabled = false;

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
            TP1.Image = HMI_HITEX.Properties.Resources._110;

            //TUBERIAS
            SP1D.Image = HMI_HITEX.Properties.Resources.D003;

            SP1C.Image = HMI_HITEX.Properties.Resources.C00;

            SP1I.Image = HMI_HITEX.Properties.Resources.I001;
            //FIN TUBERIAS

            //Glob.Mpos = 1;
            //pictureBox3.Image = HMI_HITEX.Properties.Resources.ProcesoMezcla2;
            timer5.Enabled = true;
            timer1.Stop();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            TTDI.Image = HMI_HITEX.Properties.Resources._110;
            timer2.Stop();
            TP2.Image = HMI_HITEX.Properties.Resources._111;

            //TUBERIAS
            SP2D.Image = HMI_HITEX.Properties.Resources.D111;
            STDID.Image = HMI_HITEX.Properties.Resources.D002;

            TubTDIC.Image = HMI_HITEX.Properties.Resources.I002;
            SP2C.Image = HMI_HITEX.Properties.Resources.C11;

            SP2I.Image = HMI_HITEX.Properties.Resources.I11;
            TubTDII.Image = HMI_HITEX.Properties.Resources.C003;
            //FIN TUBERIAS

        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            TP2.Image = HMI_HITEX.Properties.Resources._110;
            timer3.Stop();

            //TUBERIAS
            SP2D.Image = HMI_HITEX.Properties.Resources.D003;

            SP2C.Image = HMI_HITEX.Properties.Resources.C00;

            SP2I.Image = HMI_HITEX.Properties.Resources.I001;
            //FIN TUBERIAS

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            TP1.Image = HMI_HITEX.Properties.Resources._001;
            TTDI.Image = HMI_HITEX.Properties.Resources._001;
            TP2.Image = HMI_HITEX.Properties.Resources._001;
            timer4.Enabled = true;

        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            TP2.Image = HMI_HITEX.Properties.Resources._000;
            TTDI.Image = HMI_HITEX.Properties.Resources._000;
            TP1.Image = HMI_HITEX.Properties.Resources._000;
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
                    Mezclador.Image = HMI_HITEX.Properties.Resources.I;

                    //IZQUIERDA
                    SP1I.Visible = true;
                    SP2I.Visible = true;
                    TubTDII.Visible = true;
                    MotorMMI.Visible = true;
                    FSP1I.Visible = true;
                    FSP2I.Visible = true;
                    FSTDII.Visible = true;
                    //FIN IZQUIERDA

                    //CENTRO
                    SP1C.Visible = false;
                    SP2C.Visible = false;
                    TubTDIC.Visible = false;
                    MotorMM.Visible = false;
                    FSP1C.Visible = false;
                    FleSP2C.Visible = false;
                    FSTDIC.Visible = false;
                    //FIN CENTRO

                    //DERECHA
                    SP1D.Visible = false;
                    SP2D.Visible = false;
                    STDID.Visible = false;
                    MotorMMD.Visible = false;
                    FSP1D.Visible = false;
                    FlechaSP2D.Visible = false;
                    FSTDID.Visible = false;
                    //FIN DERECHA

                    break;
                case 3:
                    Mezclador.Image = HMI_HITEX.Properties.Resources.D;

                    //DERECHA
                    SP1D.Visible = true;
                    SP2D.Visible = true;
                    STDID.Visible = true;
                    MotorMMD.Visible = true;
                    FSP1D.Visible = true;
                    FlechaSP2D.Visible = true;
                    FSTDID.Visible = true;
                    //FIN DERECHA

                    //CENTRO
                    SP1C.Visible = false;
                    SP2C.Visible = false;
                    TubTDIC.Visible = false;
                    MotorMM.Visible = false;
                    FSP1C.Visible = false;
                    FleSP2C.Visible = false;
                    FSTDIC.Visible = false;
                    //FIN CENTRO

                    //IZQUIERDA
                    SP1I.Visible = false;
                    SP2I.Visible = false;
                    TubTDII.Visible = false;
                    MotorMMI.Visible = false;
                    FSP1I.Visible = false;
                    FSP2I.Visible = false;
                    FSTDII.Visible = false;
                    //FIN IZQUIERDA

                    break;
                case 4:
                    Mezclador.Image = HMI_HITEX.Properties.Resources.MezcladorBombeando;

                    //CENTRO
                    SP1C.Visible = false;
                    SP2C.Visible = false;
                    TubTDIC.Visible = false;
                    MotorMM.Visible = false;
                    FSP1C.Visible = false;
                    FleSP2C.Visible = false;
                    FSTDIC.Visible = false;
                    //FIN CENTRO

                    //IZQUIERDA
                    SP1I.Visible = false;
                    SP2I.Visible = false;
                    TubTDII.Visible = false;
                    MotorMMI.Visible = false;
                    FSP1I.Visible = false;
                    FSP2I.Visible = false;
                    FSTDII.Visible = false;
                    //FIN IZQUIERDA

                    //DERECHA
                    SP1D.Visible = false;
                    SP2D.Visible = false;
                    STDID.Visible = false;
                    MotorMMD.Visible = false;
                    FSP1D.Visible = false;
                    FlechaSP2D.Visible = false;
                    FSTDID.Visible = false;
                    //FIN DERECHA

                    break;
                default:
                    Mezclador.Image = HMI_HITEX.Properties.Resources.C;

                    //CENTRO
                    SP1C.Visible = true;
                    SP2C.Visible = true;
                    TubTDIC.Visible = true;
                    MotorMM.Visible = true;
                    FSP1C.Visible = true;
                    FleSP2C.Visible = true;
                    FSTDIC.Visible = true;
                    //FIN CENTRO

                    //IZQUIERDA
                    SP1I.Visible = false;
                    SP2I.Visible = false;
                    TubTDII.Visible = false;
                    MotorMMI.Visible = false;
                    FSP1I.Visible = false;
                    FSP2I.Visible = false;
                    FSTDII.Visible = false;
                    //FIN IZQUIERDA

                    //DERECHA
                    SP1D.Visible = false;
                    SP2D.Visible = false;
                    STDID.Visible = false;
                    MotorMMD.Visible = false;
                    FSP1D.Visible = false;
                    FlechaSP2D.Visible = false;
                    FSTDID.Visible = false;
                    //FIN DERECHA

                    break;
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //MOTOR MEZCLADOR
            MotorMM.Image = HMI_HITEX.Properties.Resources._2;

            MotorMMD.Image = HMI_HITEX.Properties.Resources._2;

            MotorMMI.Image = HMI_HITEX.Properties.Resources._2;
            //FIN MOTOR MEZCLADOR

            tMR.Enabled = true;
        }

        private void TMR_Tick(object sender, EventArgs e)
        {
            //MOTOR MEZCLADOR
            MotorMM.Image = HMI_HITEX.Properties.Resources._0;

            MotorMMD.Image = HMI_HITEX.Properties.Resources._0;

            MotorMMI.Image = HMI_HITEX.Properties.Resources._0;
            //FIN MOTOR MEZCLADOR

            button3.Enabled = true;

            MessageBox.Show("Proceso culminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tMR.Stop();
        }
    }
}
