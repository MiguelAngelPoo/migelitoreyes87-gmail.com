using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_final
{
    public partial class Busqueda : Form
    {

        SqlConnection conexion = new SqlConnection("Data source = DESKTOP-HCGSEP9\\MSSQLSERVER01; Initial Catalog = Proyecto; Integrated Security = true");
        public Busqueda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Alumno WHERE ID_Alumno = @ID_Alumno", conexion);
            comando.Parameters.AddWithValue("ID_Alumno", textBox6.Text);
            conexion.Open();
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                textBox2.Text = registros["nombre"].ToString();
                textBox3.Text = registros["grupo"].ToString();
                textBox4.Text = registros["materia"].ToString();
                textBox5.Text = registros["carrera"].ToString();
            }
            conexion.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
