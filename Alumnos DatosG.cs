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
    public partial class Alumnos_DatosG : Form
    {
        SqlConnection conexion = new SqlConnection("Data source = DESKTOP-HCGSEP9\\MSSQLSERVER01; Initial Catalog = Proyecto; Integrated Security = true");
        public Alumnos_DatosG()
        {
            InitializeComponent();
        }

        private void Alumnos_DatosG_Load(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("SELECT  nombre FROM Materia", conexion);
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {

                comboBox1.Items.Add(registro["nombre"].ToString());
            }
            conexion.Close();


            SqlCommand comando1 = new SqlCommand("SELECT  Nombre FROM carrera", conexion);
            conexion.Open();
            SqlDataReader registro1 = comando1.ExecuteReader();
            while (registro1.Read())
            {

                comboBox2.Items.Add(registro1["Nombre"].ToString());
            }
            conexion.Close();


            SqlCommand comando2 = new SqlCommand("SELECT  nombre FROM grupo", conexion);
            conexion.Open();
            SqlDataReader registro2 = comando2.ExecuteReader();
            while (registro2.Read())
            {

                comboBox3.Items.Add(registro2["nombre"].ToString());
            }
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          string query = "UPDATE Alumno SET nombre = @nombre,grupo = @grupo,materia = @materia, carrera = @carrera WHERE ID_Alumno = @ID_Alumno";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@nombre", textBox2.Text);
            comando.Parameters.AddWithValue("@ID_Alumno", textBox1.Text);
            comando.Parameters.AddWithValue("@grupo", comboBox3.Text);
            comando.Parameters.AddWithValue("@materia", comboBox1.Text);
            comando.Parameters.AddWithValue("@carrera", comboBox2.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Actualizado");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
