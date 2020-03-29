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
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("Data source = DESKTOP-HCGSEP9\\MSSQLSERVER01; Initial Catalog = Proyecto; Integrated Security = true");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("conectado");
            }
            catch (Exception)
            {
                MessageBox.Show("error");


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            SqlCommand comando = new SqlCommand("Select * from Alumno", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            gvAlumno.DataSource = tabla;

            


            //Asi se manda a llamar una ventan de form
            //Form Form1 = new Alumnos_DatosG();
            //Form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Alumno WHERE ID_Alumno = @ID_Alumno";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID_Alumno", textBox1.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Alumno dado de baja");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Alumno (ID_Alumno,nombre,grupo,materia,carrera) VALUES (@ID_Alumno,@nombre,@grupo,@materia,@carrera)";
            conexion.Open();

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID_Alumno", textBox6.Text);
            comando.Parameters.AddWithValue("@nombre", textBox2.Text);
            comando.Parameters.AddWithValue("@grupo", comboBox3.Text);
            comando.Parameters.AddWithValue("@materia", comboBox1.Text);
            comando.Parameters.AddWithValue("@carrera", comboBox2.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("dato Insertado");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Form1 = new Alumnos_DatosG();
            Form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Busqueda();
            Form1.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
