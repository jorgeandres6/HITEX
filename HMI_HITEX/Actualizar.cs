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
    public partial class Actualizar : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");
        public Actualizar()
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

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main v = new Main();
            v.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 v = new Form1();
            v.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE recetas SET tP1=@p1, tP2=@p2, tTDI=@tdi WHERE id=@id", con);
                cmd.Parameters.AddWithValue("p1", textBox1.Text);
                cmd.Parameters.AddWithValue("p2", textBox2.Text);
                cmd.Parameters.AddWithValue("tdi", textBox3.Text);
                cmd.Parameters.AddWithValue("id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Formula actualizada exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
            
        }
    }
}
