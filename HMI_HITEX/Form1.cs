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
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT tipo FROM [Table] WHERE usuario=@user AND contrasena=@pas", con);
                cmd.Parameters.AddWithValue("user", textBox1.Text);
                cmd.Parameters.AddWithValue("pas", textBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    Console.WriteLine(dt.Rows[0][0].ToString());
                    if (dt.Rows[0][0].ToString()=="Administrador")
                    {
                        Main v = new Main();
                        v.Show();
                    }
                    else
                    {
                        Op_proceso v = new Op_proceso();
                        v.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña errados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
           
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
