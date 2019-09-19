﻿using System;
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
    public partial class Formula : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        public Formula()
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into recetas(tP1,tP2,tTDI,Nombre) values(@p1,@p2,@tdi,@Nombre)", con);
                cmd.Parameters.AddWithValue("p1", textBox1.Text);
                cmd.Parameters.AddWithValue("p2", textBox2.Text);
                cmd.Parameters.AddWithValue("tdi", textBox3.Text);
                cmd.Parameters.AddWithValue("Nombre", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Receta almacenada exitosamente", "Receta almacenada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }
    }
}
