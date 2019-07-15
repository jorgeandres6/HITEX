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
    public partial class Usuario : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        public Usuario()
        {
            InitializeComponent();
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

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into [Table](usuario,contrasena,tipo) values(@user,@pas,@type)",con);
                cmd.Parameters.AddWithValue("user", textBox1.Text);
                cmd.Parameters.AddWithValue("pas", textBox2.Text);
                cmd.Parameters.AddWithValue("type", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            MessageBox.Show("Usuario guardado exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //disp_data();
        }

        public void disp_data()
        {
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Console.WriteLine(sda);
                //dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
            

        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }
    }
    }
