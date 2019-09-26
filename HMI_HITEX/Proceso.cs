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
using S7.Net;
//using Sharp7;

namespace HMI_HITEX
{
    public partial class F1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        DataTable dt = new DataTable();

        private Plc plc = null;

        System.Collections.BitArray salidasPLCbits;

        System.Collections.BitArray Brazo;

        ushort Vp1;
        ushort Vp2;
        ushort Vtdi;

        bool automan;

        public F1()
        {
            InitializeComponent();

            //CpuType cpu = (CpuType)Enum.Parse(typeof(CpuType), "S71200");
            plc = new Plc(CpuType.S71200, "192.168.0.100", 0, 1);
            plc.Open();

            if (plc.IsConnected)
            {
                Console.WriteLine ("conectado");
            }

            /*plc.Write("DB1.DBD2", 10000); //Temporizador P1
            plc.Write("DB1.DBD6", 5000); //Temporizador P2
            plc.Write("DB1.DBD10", 8000); //Temporizador TDI*/
            //plc.Write("DB1.DBX14.0", false);

            automan = (bool)plc.Read("DB1.DBX14.0");

            if (automan)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                automan = false;
                button3.Enabled = false;
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                automan = true;
                button3.Enabled = true;
            };


            //plc.Write("DB1.DBX14.6", false);
            //Inicio en automatico

            /*var entradasPLC = plc.ReadBytes(DataType.Input, 0, 0, 8);
            var salidasPLC = plc.ReadBytes(DataType.Output, 0, 0, 8);
            var salidasPLC2 = plc.ReadBytes(DataType.Output, 1, 0, 8);
            var salidasModulo = plc.ReadBytes(DataType.Output, 8, 0, 8);
            var salidasModulo2 = plc.ReadBytes(DataType.Output, 9, 0, 8);*/

            /*var client = new S7Client();
            int conex = client.ConnectTo("192.168.0.100", 0, 0);

            if (conex == 0)
            {
                Console.WriteLine("ok");
            }

            var bufferAux = new byte[1];
            
            int DBN;
            int size;

            DBN = System.Convert.ToInt32(1);
            size = System.Convert.ToInt32(bufferAux.Length);

            int readRes = client.DBRead(DBN, 0, size, bufferAux);

            if (readRes == 0)
            {
                Console.WriteLine("Lectura correcta");
            }
            else
            {
                Console.WriteLine(readRes);
            }*/

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM recetas", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Close();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Nombre";
                

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
            timer6.Stop();
            plc.Close();
            this.Hide();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer6.Stop();
            plc.Close();
            this.Hide();
            Main v = new Main();
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e) //Boton inicio proceso
        {
        
            plc.Write("DB1.DBX0.0", true);

            PUSeleccion v = new PUSeleccion();
            v.Show();
            timer5.Stop();

            /*
            TP1.Image = HMI_HITEX.Properties.Resources._111;
            TTDI.Image = HMI_HITEX.Properties.Resources._111;*/
            //Glob.Mpos = 4;

            //TUBERIAS
            /*SP1D.Image = HMI_HITEX.Properties.Resources.D111;
            STDID.Image = HMI_HITEX.Properties.Resources.D11;

            TubTDIC.Image = HMI_HITEX.Properties.Resources.I112;
            SP1C.Image = HMI_HITEX.Properties.Resources.C11;

            SP1I.Image = HMI_HITEX.Properties.Resources.I11;
            TubTDII.Image = HMI_HITEX.Properties.Resources.C111;*/
            //FIN TUBERIAS

            //MOTOR MEZCLADOR
            /*MotorMM.Image = HMI_HITEX.Properties.Resources._1;

            MotorMMD.Image = HMI_HITEX.Properties.Resources._1;

            MotorMMI.Image = HMI_HITEX.Properties.Resources._1;*/
            //FIN MOTOR MEZCLADOR

            button3.Enabled = false;

            //pictureBox3.Image = HMI_HITEX.Properties.Resources.MezcladorBombeando;
            timer1.Enabled = true;
            timer2.Enabled = true;

            DateTime today = DateTime.Today;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into reporte(Tipo_receta,Fecha_produccion,Poliol1_usado_Kg,Poliol2_usado_Kg,TDI_usado_Kg,Usuario) values(@rec,@fecha,@p1,@p2,@tdi,@usuario)", con);
                cmd.Parameters.AddWithValue("rec", comboBox1.Text);
                cmd.Parameters.AddWithValue("fecha", today.ToString("yyyy/MM/dd"));
                int i = int.Parse(comboBox1.Text)-1;
                cmd.Parameters.AddWithValue("p1", dt.Rows[i][1].ToString());
                cmd.Parameters.AddWithValue("p2", dt.Rows[i][2].ToString());
                cmd.Parameters.AddWithValue("tdi", dt.Rows[i][3].ToString());
                cmd.Parameters.AddWithValue("usuario", Glob.User);
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
            //TP1.Image = HMI_HITEX.Properties.Resources._110;

            //TUBERIAS
            /*SP1D.Image = HMI_HITEX.Properties.Resources.D003;

            SP1C.Image = HMI_HITEX.Properties.Resources.C00;

            SP1I.Image = HMI_HITEX.Properties.Resources.I001;*/
            //FIN TUBERIAS

            //Glob.Mpos = 1;
            //pictureBox3.Image = HMI_HITEX.Properties.Resources.ProcesoMezcla2;
            timer5.Enabled = true;
            timer1.Stop();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            //TTDI.Image = HMI_HITEX.Properties.Resources._110;
            timer2.Stop();
            //TP2.Image = HMI_HITEX.Properties.Resources._111;

            //TUBERIAS
            /*SP2D.Image = HMI_HITEX.Properties.Resources.D111;
            STDID.Image = HMI_HITEX.Properties.Resources.D002;

            TubTDIC.Image = HMI_HITEX.Properties.Resources.I002;
            SP2C.Image = HMI_HITEX.Properties.Resources.C11;

            SP2I.Image = HMI_HITEX.Properties.Resources.I11;
            TubTDII.Image = HMI_HITEX.Properties.Resources.C003;*/
            //FIN TUBERIAS

        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            //TP2.Image = HMI_HITEX.Properties.Resources._110;
            timer3.Stop();

            //TUBERIAS
            /*SP2D.Image = HMI_HITEX.Properties.Resources.D003;

            SP2C.Image = HMI_HITEX.Properties.Resources.C00;

            SP2I.Image = HMI_HITEX.Properties.Resources.I001;*/
            //FIN TUBERIAS

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //TP1.Image = HMI_HITEX.Properties.Resources._001;
            //TTDI.Image = HMI_HITEX.Properties.Resources._001;
            //TP2.Image = HMI_HITEX.Properties.Resources._001;
            timer4.Enabled = true;

        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            //TP2.Image = HMI_HITEX.Properties.Resources._000;
            //TTDI.Image = HMI_HITEX.Properties.Resources._000;
            //TP1.Image = HMI_HITEX.Properties.Resources._000;
            timer4.Stop();
        }

        private void Timer5_Tick(object sender, EventArgs e)
        {
            
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            PUSeleccion v = new PUSeleccion();
            v.Show();
        }

        private void Timer6_Tick(object sender, EventArgs e)
        {

            var salidasPLC = plc.ReadBytes(DataType.DataBlock, 1, 16, 3);

            salidasPLCbits = new System.Collections.BitArray(salidasPLC);

            var posBrazo = plc.ReadBytes(DataType.DataBlock, 1, 15, 1);

            Brazo = new System.Collections.BitArray(posBrazo);

            //Tanque 1
            if (salidasPLCbits[2] && !salidasPLCbits[16] && !salidasPLCbits[3]) 
            {
                TP1.Image = HMI_HITEX.Properties.Resources._110;
            }
            else if(salidasPLCbits[2] && salidasPLCbits[16] && !salidasPLCbits[3])
            {
                TP1.Image = HMI_HITEX.Properties.Resources._111;
            }
            else if (!salidasPLCbits[2] && !salidasPLCbits[16] && salidasPLCbits[3])
            {
                TP1.Image = HMI_HITEX.Properties.Resources._000;
            }
            else if(!salidasPLCbits[2] && salidasPLCbits[16] && salidasPLCbits[3])
            {
                TP1.Image = HMI_HITEX.Properties.Resources._001;
            }
            //fin tanque 1

            //Tanque 2
            if (salidasPLCbits[5] && !salidasPLCbits[17] && !salidasPLCbits[6])
            {
                TP2.Image = HMI_HITEX.Properties.Resources._110;
            }
            else if (salidasPLCbits[5] && salidasPLCbits[17] && !salidasPLCbits[6])
            {
                TP2.Image = HMI_HITEX.Properties.Resources._111;
            }
            else if (!salidasPLCbits[5] && !salidasPLCbits[17] && salidasPLCbits[6])
            {
                TP2.Image = HMI_HITEX.Properties.Resources._000;
            }
            else if (!salidasPLCbits[5] && salidasPLCbits[17] && salidasPLCbits[6])
            {
                TP2.Image = HMI_HITEX.Properties.Resources._001;
            }
            //fin tanque 2

            //Tanque TDI
            if (salidasPLCbits[8] && !salidasPLCbits[18] && !salidasPLCbits[9])
            {
                TTDI.Image = HMI_HITEX.Properties.Resources._110;
            }
            else if (salidasPLCbits[8] && salidasPLCbits[18] && !salidasPLCbits[9])
            {
                TTDI.Image = HMI_HITEX.Properties.Resources._111;
            }
            else if (!salidasPLCbits[8] && !salidasPLCbits[18] && salidasPLCbits[9])
            {
                TTDI.Image = HMI_HITEX.Properties.Resources._000;
            }
            else if (!salidasPLCbits[8] && salidasPLCbits[18] && salidasPLCbits[9])
            {
                TTDI.Image = HMI_HITEX.Properties.Resources._001;
            }
            //fin tanque TDI

            //Agitador P1
            if (salidasPLCbits[13])
            {
                MotorP1.Image = HMI_HITEX.Properties.Resources._1;
            }
            else
            {
                MotorP1.Image = HMI_HITEX.Properties.Resources._0;
            }
            //Fin Agitador P1

            //Agitador P2
            if (salidasPLCbits[14])
            {
                MotorP2.Image = HMI_HITEX.Properties.Resources._1;
            }
            else
            {
                MotorP2.Image = HMI_HITEX.Properties.Resources._0;
            }
            //Fin Agitador P2

            //Agitador TDI
            if (salidasPLCbits[15])
            {
                MotorTDI.Image = HMI_HITEX.Properties.Resources._1;
            }
            else
            {
                MotorTDI.Image = HMI_HITEX.Properties.Resources._0;
            }
            //Fin Agitador TDI

            //MEZCLADOR

            //TUBERIAS

            //P1
            if (salidasPLCbits[16] && !salidasPLCbits[4])
            {
                SP1D.Image = HMI_HITEX.Properties.Resources.D111;
                SP1C.Image = HMI_HITEX.Properties.Resources.C11;
                SP1I.Image = HMI_HITEX.Properties.Resources.I11;
            }
            else if (!salidasPLCbits[16] && !salidasPLCbits[4])
            {
                SP1D.Image = HMI_HITEX.Properties.Resources.D101;
                SP1C.Image = HMI_HITEX.Properties.Resources.C10;
                SP1I.Image = HMI_HITEX.Properties.Resources.I10;
            }
            else if (!salidasPLCbits[16] && salidasPLCbits[4])
            {
                SP1D.Image = HMI_HITEX.Properties.Resources.D003;
                SP1C.Image = HMI_HITEX.Properties.Resources.C002;
                SP1I.Image = HMI_HITEX.Properties.Resources.I001;
            }
            //FIN P1

            //P2
            if (salidasPLCbits[17] && !salidasPLCbits[7])
            {
                SP2D.Image = HMI_HITEX.Properties.Resources.D111;
                SP2C.Image = HMI_HITEX.Properties.Resources.C11;
                SP2I.Image = HMI_HITEX.Properties.Resources.I11;
            }
            else if (!salidasPLCbits[17] && !salidasPLCbits[7])
            {
                SP2D.Image = HMI_HITEX.Properties.Resources.D101;
                SP2C.Image = HMI_HITEX.Properties.Resources.C10;
                SP2I.Image = HMI_HITEX.Properties.Resources.I10;
            }
            else if (!salidasPLCbits[17] && salidasPLCbits[7])
            {
                SP2D.Image = HMI_HITEX.Properties.Resources.D003;
                SP2C.Image = HMI_HITEX.Properties.Resources.C002;
                SP2I.Image = HMI_HITEX.Properties.Resources.I001;
            }
            //FIN P2

            //TDI
            if (salidasPLCbits[18] && !salidasPLCbits[10])
            {
                STDID.Image = HMI_HITEX.Properties.Resources.D11;
                TubTDIC.Image = HMI_HITEX.Properties.Resources.I112;
                TubTDII.Image = HMI_HITEX.Properties.Resources.C111;
            }
            else if (!salidasPLCbits[18] && !salidasPLCbits[10])
            {
                STDID.Image = HMI_HITEX.Properties.Resources.D10;
                TubTDIC.Image = HMI_HITEX.Properties.Resources.I101;
                TubTDII.Image = HMI_HITEX.Properties.Resources.C101;
            }
            else if (!salidasPLCbits[18] && salidasPLCbits[10])
            {
                STDID.Image = HMI_HITEX.Properties.Resources.D002;
                TubTDIC.Image = HMI_HITEX.Properties.Resources.I002;
                TubTDII.Image = HMI_HITEX.Properties.Resources.C003;
            }
            //FIN TDI

            //FIN TUBERIAS

            //MOTORES
            if (salidasPLCbits[19] && !salidasPLCbits[20])
            {
                MotorMM.Image = HMI_HITEX.Properties.Resources._1;
                MotorMMD.Image = HMI_HITEX.Properties.Resources._1;
                MotorMMI.Image = HMI_HITEX.Properties.Resources._1;
            }
            else if (salidasPLCbits[19] && salidasPLCbits[20])
            {
                MotorMM.Image = HMI_HITEX.Properties.Resources._2;
                MotorMMD.Image = HMI_HITEX.Properties.Resources._2;
                MotorMMI.Image = HMI_HITEX.Properties.Resources._2;
            }
            else if (!salidasPLCbits[19] && !salidasPLCbits[20])
            {
                MotorMM.Image = HMI_HITEX.Properties.Resources._0;
                MotorMMD.Image = HMI_HITEX.Properties.Resources._0;
                MotorMMI.Image = HMI_HITEX.Properties.Resources._0;
            }
            //FIN MOTORES

            //FIN MEZCLADOR


            if ((bool)plc.Read("DB1.DBX0.0")) //cambiar el boton de inicio a false
            {
                plc.Write("DB1.DBX0.0", false);
            }

            if ((bool)plc.Read("DB1.DBX14.1")) //cambiar el boton de descarga a false
            {
                plc.Write("DB1.DBX14.1", false);
            }

            //Posicion Brazo
            if (Brazo[7]) //centro
            {
                Glob.Mpos = 1;
            }

            if (Brazo[5]) //derecha
            {
                Glob.Mpos = 3;
            }

            if (Brazo[6]) //izquierda
            {
                Glob.Mpos = 2;
            }

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
            if (!automan)
            {
                PUTanqueTDI v = new PUTanqueTDI();
                v.Show();
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Esta seguro que desea realizar la descarga?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                plc.Write("DB1.DBX14.1", true); //Descarga

                //MOTOR MEZCLADOR
                /*MotorMM.Image = HMI_HITEX.Properties.Resources._2;

                MotorMMD.Image = HMI_HITEX.Properties.Resources._2;

                MotorMMI.Image = HMI_HITEX.Properties.Resources._2;*/
                //FIN MOTOR MEZCLADOR

                tMR.Enabled = true;
            }

        }

        private void TMR_Tick(object sender, EventArgs e)
        {
            //MOTOR MEZCLADOR
            /*MotorMM.Image = HMI_HITEX.Properties.Resources._0;

            MotorMMD.Image = HMI_HITEX.Properties.Resources._0;

            MotorMMI.Image = HMI_HITEX.Properties.Resources._0;*/
            //FIN MOTOR MEZCLADOR

            button3.Enabled = true;

            tMR.Stop();

            MessageBox.Show("Proceso culminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (automan)
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_on_white_48dp;
                automan = false;
                button3.Enabled = false;
                plc.Write("DB1.DBX14.0",true);
            }
            else
            {
                pictureBox1.Image = HMI_HITEX.Properties.Resources.baseline_toggle_off_white_48dp;
                automan = true;
                button3.Enabled = true;
                plc.Write("DB1.DBX14.0", false);
            };
            //bool aux = (bool)plc.Read("DB1.DBX14.0");
            //Console.WriteLine(aux);
            /*if (plc.IsConnected)
            {
                Console.WriteLine("conectado");
                //plc.ReadBytes(DataType.DataBlock, 1, 0, 1);
                var result = plc.Read("DB1.DBX14.0");
                Console.WriteLine(result);
                //plc.Write(0, true);
            }*/
            //var dwords = plc.ReadBytes(DataType.DataBlock, 1, 0, 10);
            //Console.WriteLine(aux);
        }

        private void TP2_Click(object sender, EventArgs e)
        {
            if (!automan)
            {
                PUTanque v = new PUTanque();
                v.Show();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow valores = dt.Rows[comboBox1.SelectedIndex];
            Vp1 = Convert.ToUInt16(valores["tP1"]);
            Vp2 = Convert.ToUInt16(valores["tP2"]); 
            Vtdi = Convert.ToUInt16(valores["tTDI"]);
            plc.Write("DB1.DBW28", Vp1);
            plc.Write("DB1.DBW30", Vp2);
            plc.Write("DB1.DBW32", Vtdi);

        }

        private void BDerecha_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX15.5", true);
        }

        private void BCentro_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBX15.5", false);
        }

        private void BIzquierda_Click(object sender, EventArgs e)
        {
            bool pe = (bool)plc.Read("DB1.DBX15.6");
            plc.Write("DB1.DBX15.6", !pe);
        }

        private void TP1_Click(object sender, EventArgs e)
        {
            if (!automan)
            {
                PUTanqueP1 v = new PUTanqueP1();
                v.Show();
            }
        }

        private void Mezclador_Click(object sender, EventArgs e)
        {
            if (!automan)
            {
                PUMezclador v = new PUMezclador();
                v.Show();
            }
        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
