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
    public partial class Op_proceso : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        public Op_proceso()
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

        private void Button3_Click(object sender, EventArgs e)
        {
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
    }
}
