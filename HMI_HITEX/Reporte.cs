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
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace HMI_HITEX
{
    public partial class Reporte : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\Hitex.mdf;Integrated Security=True;Connect Timeout=30");

        DataTable dt = new DataTable();

        string fecha;
        string fechaF;

        public Reporte()
        {
            InitializeComponent();

            fecha = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
            fechaF = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM reporte WHERE Fecha_produccion = '"+fecha+"'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                Console.WriteLine(sda);
                dataGridView1.DataSource = dt;
                con.Close();
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
            SLDocument doc = new SLDocument();
            doc.ImportDataTable(1,1,dt,true);
            doc.SaveAs(@"C:\Users\ADMIN\Documents\Reportes\" + fechaF + ".xlsx");
            MessageBox.Show("Documento generado en mis Documentos con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt.Clear();
            fecha = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
            fechaF = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM reporte WHERE Fecha_produccion = '" + fecha + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                Console.WriteLine(sda);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception m)
            {
                Console.WriteLine("{0} Exception caught.", m);
            }
        }
    }
}
