using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Proyecto_Final_4to_Semestre
{
    public partial class Form1 : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          LoadData();
        }


        #region Metodo para cargar los datos de la base de datos en el DataGridView
        private void LoadData()
        {
            // Consulta SQL para obtener todos los registros de una tabla 
            string query = "SELECT * FROM spotify_songs";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Crear un adaptador de datos
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Crear un DataTable para almacenar los datos
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos del adaptador
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable como la fuente de datos del DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Mostrar mensaje de error en caso de que ocurra alguna excepción
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }
        #endregion

        private void GuardarEnCSV(string rutaArchivo)
        {
            // Crear un objeto StreamWriter para escribir en el archivo CSV
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                // Escribir la primera fila con los encabezados de las columnas
                StringBuilder filaEncabezados = new StringBuilder();
                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    filaEncabezados.Append(columna.HeaderText + ",");
                }
                writer.WriteLine(filaEncabezados.ToString());

                // Recorrer las filas del DataGridView y escribirlas en el archivo CSV
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    StringBuilder filaDatos = new StringBuilder();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        // Verificar si la celda está vacía antes de acceder a su valor
                        if (celda.Value != null)
                        {
                            filaDatos.Append(celda.Value.ToString() + ",");
                        }
                        else
                        {
                            // Manejar celdas vacías (opcional)
                            filaDatos.Append("[CELDA VACÍA],");
                        }
                    }
                    writer.WriteLine(filaDatos.ToString());
                }
            }
        }


        #region BOTONES PARA GUARDAR EN FORMATO 
        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar un diálogo para seleccionar la ruta del archivo CSV
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.Filter = "Archivos CSV (*.csv)|*.csv";
            dialogoGuardar.DefaultExt = "csv";

            if (dialogoGuardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Guardar el contenido del DataGridView en el archivo seleccionado
                    GuardarEnCSV(dialogoGuardar.FileName);

                    // Mostrar un mensaje de confirmación
                    MessageBox.Show("Datos guardados correctamente en el archivo: " + dialogoGuardar.FileName);
                }
                catch (Exception ex)
                {
                    // Manejar errores durante el proceso de guardado
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }

        #endregion

        #region BOTONES PARA LEER LOS FORMATOS
        private void button8_Click(object sender, EventArgs e)
        {
          
        }
        #endregion


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Maximizar la pantalla y normalizarla
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Minimizar la pantalla
            WindowState = FormWindowState.Minimized;
        }
    }
}
