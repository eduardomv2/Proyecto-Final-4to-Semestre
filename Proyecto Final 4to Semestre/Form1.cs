using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Proyecto_Final_4to_Semestre
{
    public partial class Form1 : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private DataTable dataTable;
        private BindingSource bindingSource;
        private SqlDataAdapter dataAdapter;
        


        public Form1()
        {
            InitializeComponent();   
            InitializeDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataGridView.RowHeadersVisible = false; // Oculta la columna de encabezado de filas

            // Configurar colores de fondo y de texto de las filas
            DataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color de fondo opaco
            DataGridView.RowsDefaultCellStyle.ForeColor = Color.Black; // Color de texto

            // Configurar colores de fondo y de texto de las celdas
            DataGridView.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220); // Color de fondo opaco
            DataGridView.DefaultCellStyle.ForeColor = Color.Black; // Color de texto
                
            // Configurar color de fondo de las filas seleccionadas
            DataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Color de selección opaco
            DataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            LoadData();


        }

        private void InitializeDataGridView()
        {
            bindingSource = new BindingSource();
            DataGridView.DataSource = bindingSource;

        }



        #region Metodo para cargar los datos de la base de datos en el DataGridView
        private void LoadData()
        {
            try
            {
                dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM spotify_songs", connection);
                    dataAdapter.Fill(dataTable);
                }

                // Enlazar el DataTable con el DataGridView
                DataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde la base de datos: " + ex.Message);
            }
        }
        #endregion

        #region BOTON PARA GUARDAR EN FORMATO CSV
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

        //METODO PARA GUARDAR EN CSV

        private void GuardarEnCSV(string rutaArchivo)
        {
            // Crear un objeto StreamWriter para escribir en el archivo CSV
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                // Escribir la primera fila con los encabezados de las columnas
                StringBuilder filaEncabezados = new StringBuilder();
                foreach (DataGridViewColumn columna in DataGridView.Columns)
                {
                    filaEncabezados.Append(columna.HeaderText + ",");
                }
                writer.WriteLine(filaEncabezados.ToString());

                // Recorrer las filas del DataGridView y escribirlas en el archivo CSV
                foreach (DataGridViewRow fila in DataGridView.Rows)
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
                            // Manejar celdas vacías
                            filaDatos.Append("[CELDA VACÍA],");
                        }
                    }
                    writer.WriteLine(filaDatos.ToString());
                }
            }
        }



        #endregion

        #region BOTON PARA LEER FORMATOS CSV
        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar archivo CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataTable = LeerDesdeCSV(filePath);
                if (dataTable.Rows.Count > 0)
                {
                    DataGridView.DataSource = dataTable;
                }
            }
        }

        //METODO PARA LEER DESDE CSV
        private DataTable LeerDesdeCSV(string filePath)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer archivo CSV: " + ex.Message);
            }
            return dataTable;
        }

        #endregion

        #region BOTON PARA GUARDAR EN FORMATO JSON
        private void btnGuardarJSON_Click(object sender, EventArgs e)
        {
            List<object> dataList = new List<object>();

            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!row.IsNewRow) // Verificar si la fila no es nueva
                {
                    Dictionary<string, object> rowData = new Dictionary<string, object>();

                    // Iterar a través de las celdas de la fila
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Obtener el nombre de la columna y el valor de la celda
                        string columnName = DataGridView.Columns[cell.ColumnIndex].Name;
                        object cellValue = cell.Value;

                        // Agregar el nombre de la columna y el valor a rowData
                        rowData[columnName] = cellValue;
                    }

                    // Agregar rowData a la lista dataList
                    dataList.Add(rowData);
                }
            }

            // Serializar la lista de objetos a JSON usando Newtonsoft.Json
            string json = JsonConvert.SerializeObject(dataList, Formatting.Indented);

            // Mostrar diálogo para guardar archivo
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*";
            saveFileDialog1.Title = "Guardar datos JSON";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = "spotify_songs_data.json";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Guardar JSON en el archivo seleccionado por el usuario
                string filePath = saveFileDialog1.FileName;
                File.WriteAllText(filePath, json);

                MessageBox.Show("Datos guardados en formato JSON correctamente en:\n" + filePath);
            }
        }
        #endregion

        #region BOTON PARA LEER FORMATO JSON
        private void btnLeerJSON_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar archivo JSON";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataTable = LeerDesdeJSON(filePath);
                if (dataTable != null)
                {
                    DataGridView.DataSource = dataTable;
                }
            }
        }

        private DataTable LeerDesdeJSON(string filePath)
        {
            DataTable tempDataTable = new DataTable();
            try
            {
                if (File.Exists(filePath))
                {
                    // Leer el contenido del archivo JSON
                    string jsonContent = File.ReadAllText(filePath);

                    // Deserializar el JSON a una lista de objetos anónimos
                    var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);

                    // Verificar si dataList tiene elementos
                    if (dataList != null && dataList.Count > 0)
                    {
                        // Agregar columnas al DataTable basado en las claves del primer diccionario
                        foreach (var key in dataList[0].Keys)
                        {
                            tempDataTable.Columns.Add(key);
                        }

                        // Agregar filas al DataTable
                        foreach (var data in dataList)
                        {
                            DataRow row = tempDataTable.NewRow();
                            foreach (var key in data.Keys)
                            {
                                row[key] = data[key]?.ToString(); // Convertir valores a cadena
                            }
                            tempDataTable.Rows.Add(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El archivo JSON \"{Path.GetFileName(filePath)}\" está vacío o no tiene el formato esperado.");
                    }
                }
                else
                {
                    MessageBox.Show($"El archivo JSON \"{Path.GetFileName(filePath)}\" no existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer archivo JSON \"{Path.GetFileName(filePath)}\": {ex.Message}");
            }
            return tempDataTable;
        }



        #endregion

        #region BOTON PARA GUARDAR EN FORMATO XML

        private void btnGuardarXML_Click(object sender, EventArgs e)
        {
            // Mostrar diálogo para guardar archivo
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
            saveFileDialog1.Title = "Guardar datos XML";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = "spotify_songs_data.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtener el DataTable desde el DataSource del DataGridView
                    DataTable dataTable = (DataTable)DataGridView.DataSource;

                    if (dataTable != null)
                    {
                        // Asignar un nombre al DataTable si no tiene uno
                        if (string.IsNullOrEmpty(dataTable.TableName))
                        {
                            dataTable.TableName = "spotify_songs";
                        }

                        // Guardar el DataTable como XML en el archivo seleccionado por el usuario
                        string filePath = saveFileDialog1.FileName;
                        dataTable.WriteXml(filePath, XmlWriteMode.WriteSchema);

                        MessageBox.Show("Datos guardados en formato XML correctamente en:\n" + filePath);
                    }
                    else
                    {
                        MessageBox.Show("No hay datos en el DataGridView para guardar.");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores durante el proceso de guardado
                    MessageBox.Show("Error al guardar el archivo XML: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
        #endregion

        #region Boton para leer en XML

        private void btnLeerXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar archivo XML";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataTable = LeerDesdeXML(filePath);
                if (dataTable.Rows.Count > 0)
                {
                    DataGridView.DataSource = dataTable;
                }
            }
        }

        private DataTable LeerDesdeXML(string filePath)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Leer el archivo XML en un DataSet
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(filePath);

                // Verificar si el DataSet tiene al menos una tabla y esta tiene al menos una fila
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    // Asignar la tabla del DataSet al DataTable
                    dataTable = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer archivo XML: " + ex.Message);
            }
            return dataTable;
        }

        #endregion 

        #region BOTON PARA GUARDAR EN FORMATO YAML

        private void btnGuardarYaml_Click(object sender, EventArgs e)
        {
            // Obtener el DataTable desde el DataSource del DataGridView
            DataTable dataTable = (DataTable)DataGridView.DataSource;

            // Convertir DataTable a una lista de diccionarios para facilitar la serialización
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();
            foreach (DataRow row in dataTable.Rows)
            {
                var dict = row.Table.Columns.Cast<DataColumn>()
                            .ToDictionary(col => col.ColumnName, col => row[col]);
                dataList.Add(dict);
            }

            // Serializar a YAML usando YamlDotNet
            var serializer = new SerializerBuilder()
                                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                .Build();

            string yaml = serializer.Serialize(dataList);

            // Mostrar diálogo para guardar archivo
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos YAML (*.yaml)|*.yaml|Todos los archivos (*.*)|*.*";
            saveFileDialog1.Title = "Guardar datos YAML";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = "spotify_songs_data.yaml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Guardar el YAML en el archivo seleccionado por el usuario
                    string filePath = saveFileDialog1.FileName;
                    File.WriteAllText(filePath, yaml);

                    MessageBox.Show("Datos guardados en formato YAML correctamente en:\n" + filePath);
                }
                catch (Exception ex)
                {
                    // Manejar errores durante el proceso de guardado
                    MessageBox.Show("Error al guardar el archivo YAML: " + ex.Message);
                }
            }
        }
        #endregion

        #region Boton para Leer en YAML
        private void btnLeerYAML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos YAML (*.yaml;*.yml)|*.yaml;*.yml|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar archivo YAML";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataTable = LeerDesdeYAML(filePath);
                if (dataTable.Rows.Count > 0)
                {
                    DataGridView.DataSource = dataTable;
                }
            }
        }

        private DataTable LeerDesdeYAML(string filePath)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Crear un deserializador YAML
                Deserializer deserializer = new Deserializer();

                // Leer el contenido del archivo YAML
                string yamlContent = File.ReadAllText(filePath);

                // Deserializar el contenido YAML a una lista de diccionarios
                List<Dictionary<string, object>> dataList = deserializer.Deserialize<List<Dictionary<string, object>>>(yamlContent);

                // Si dataList tiene elementos
                if (dataList.Count > 0)
                {
                    // Agregar columnas al DataTable basado en las claves del primer diccionario
                    foreach (var key in dataList[0].Keys)
                    {
                        dataTable.Columns.Add(key);
                    }

                    // Agregar filas al DataTable
                    foreach (var data in dataList)
                    {
                        DataRow row = dataTable.NewRow();
                        foreach (var key in data.Keys)
                        {
                            row[key] = data[key]?.ToString(); // Convertir valores a cadena
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer archivo YAML: " + ex.Message);
            }
            return dataTable;
        }

        #endregion

        #region BOTONES PARA MANEJAR EL TAMAÑO DE LA VENTANA
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
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    // Configurar el comando DELETE
                    SqlCommand deleteCommand = new SqlCommand(
                        "DELETE FROM spotify_songs WHERE track_id = @track_id", connection);
                    deleteCommand.Parameters.Add("@track_id", SqlDbType.NVarChar, 50, "track_id");
                    dataAdapter.DeleteCommand = deleteCommand;

                    // Configurar el comando INSERT
                    SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO spotify_songs (track_id, track_name, track_artist, track_popularity, " +
                        "track_album_id, track_album_name, track_album_release_date, playlist_name, playlist_id, " +
                        "playlist_genre, playlist_subgenre, danceability, energy, [key], loudness, mode, speechiness, " +
                        "acousticness, instrumentalness, liveness, valence, tempo, duration_ms) " +
                        "VALUES (@track_id, @track_name, @track_artist, @track_popularity, @track_album_id, " +
                        "@track_album_name, @track_album_release_date, @playlist_name, @playlist_id, @playlist_genre, " +
                        "@playlist_subgenre, @danceability, @energy, @key, @loudness, @mode, @speechiness, " +
                        "@acousticness, @instrumentalness, @liveness, @valence, @tempo, @duration_ms); " +
                        "SELECT * FROM spotify_songs WHERE track_id = SCOPE_IDENTITY();", connection);
                    insertCommand.Parameters.Add("@track_id", SqlDbType.NVarChar, 50, "track_id").Value = DBNull.Value; // Valor generado automáticamente por la base de datos
                    insertCommand.Parameters.Add("@track_name", SqlDbType.VarChar, -1, "track_name");
                    insertCommand.Parameters.Add("@track_artist", SqlDbType.VarChar, -1, "track_artist");
                    insertCommand.Parameters.Add("@track_popularity", SqlDbType.TinyInt, 1, "track_popularity");
                    insertCommand.Parameters.Add("@track_album_id", SqlDbType.NVarChar, 50, "track_album_id");
                    insertCommand.Parameters.Add("@track_album_name", SqlDbType.VarChar, -1, "track_album_name");
                    insertCommand.Parameters.Add("@track_album_release_date", SqlDbType.DateTime2, 7, "track_album_release_date");
                    insertCommand.Parameters.Add("@playlist_name", SqlDbType.VarChar, -1, "playlist_name");
                    insertCommand.Parameters.Add("@playlist_id", SqlDbType.NVarChar, 50, "playlist_id");
                    insertCommand.Parameters.Add("@playlist_genre", SqlDbType.NVarChar, 50, "playlist_genre");
                    insertCommand.Parameters.Add("@playlist_subgenre", SqlDbType.NVarChar, 50, "playlist_subgenre");
                    insertCommand.Parameters.Add("@danceability", SqlDbType.Float, 8, "danceability");
                    insertCommand.Parameters.Add("@energy", SqlDbType.Float, 8, "energy");
                    insertCommand.Parameters.Add("@key", SqlDbType.TinyInt, 1, "key");
                    insertCommand.Parameters.Add("@loudness", SqlDbType.Float, 8, "loudness");
                    insertCommand.Parameters.Add("@mode", SqlDbType.Bit, 1, "mode");
                    insertCommand.Parameters.Add("@speechiness", SqlDbType.Float, 8, "speechiness");
                    insertCommand.Parameters.Add("@acousticness", SqlDbType.Float, 8, "acousticness");
                    insertCommand.Parameters.Add("@instrumentalness", SqlDbType.Float, 8, "instrumentalness");
                    insertCommand.Parameters.Add("@liveness", SqlDbType.Float, 8, "liveness");
                    insertCommand.Parameters.Add("@valence", SqlDbType.Float, 8, "valence");
                    insertCommand.Parameters.Add("@tempo", SqlDbType.Float, 8, "tempo");
                    insertCommand.Parameters.Add("@duration_ms", SqlDbType.Int, 4, "duration_ms");
                    dataAdapter.InsertCommand = insertCommand;

                    // Configurar el comando UPDATE
                    SqlCommand updateCommand = new SqlCommand(
                        "UPDATE spotify_songs SET " +
                        "track_name = @track_name, " +
                        "track_artist = @track_artist, " +
                        "track_popularity = @track_popularity, " +
                        "track_album_id = @track_album_id, " +
                        "track_album_name = @track_album_name, " +
                        "track_album_release_date = @track_album_release_date, " +
                        "playlist_name = @playlist_name, " +
                        "playlist_id = @playlist_id, " +
                        "playlist_genre = @playlist_genre, " +
                        "playlist_subgenre = @playlist_subgenre, " +
                        "danceability = @danceability, " +
                        "energy = @energy, " +
                        "[key] = @key, " +
                        "loudness = @loudness, " +
                        "mode = @mode, " +
                        "speechiness = @speechiness, " +
                        "acousticness = @acousticness, " +
                        "instrumentalness = @instrumentalness, " +
                        "liveness = @liveness, " +
                        "valence = @valence, " +
                        "tempo = @tempo, " +
                        "duration_ms = @duration_ms " +
                        "WHERE track_id = @track_id", connection);
                    updateCommand.Parameters.Add("@track_id", SqlDbType.NVarChar, 50, "track_id");
                    updateCommand.Parameters.Add("@track_name", SqlDbType.VarChar, -1, "track_name");
                    updateCommand.Parameters.Add("@track_artist", SqlDbType.VarChar, -1, "track_artist");
                    updateCommand.Parameters.Add("@track_popularity", SqlDbType.TinyInt, 1, "track_popularity");
                    updateCommand.Parameters.Add("@track_album_id", SqlDbType.NVarChar, 50, "track_album_id");
                    updateCommand.Parameters.Add("@track_album_name", SqlDbType.VarChar, -1, "track_album_name");
                    updateCommand.Parameters.Add("@track_album_release_date", SqlDbType.DateTime2, 7, "track_album_release_date");
                    updateCommand.Parameters.Add("@playlist_name", SqlDbType.VarChar, -1, "playlist_name");
                    updateCommand.Parameters.Add("@playlist_id", SqlDbType.NVarChar, 50, "playlist_id");
                    updateCommand.Parameters.Add("@playlist_genre", SqlDbType.NVarChar, 50, "playlist_genre");
                    updateCommand.Parameters.Add("@playlist_subgenre", SqlDbType.NVarChar, 50, "playlist_subgenre");
                    updateCommand.Parameters.Add("@danceability", SqlDbType.Float, 8, "danceability");
                    updateCommand.Parameters.Add("@energy", SqlDbType.Float, 8, "energy");
                    updateCommand.Parameters.Add("@key", SqlDbType.TinyInt, 1, "key");
                    updateCommand.Parameters.Add("@loudness", SqlDbType.Float, 8, "loudness");
                    updateCommand.Parameters.Add("@mode", SqlDbType.Bit, 1, "mode");
                    updateCommand.Parameters.Add("@speechiness", SqlDbType.Float, 8, "speechiness");
                    updateCommand.Parameters.Add("@acousticness", SqlDbType.Float, 8, "acousticness");
                    updateCommand.Parameters.Add("@instrumentalness", SqlDbType.Float, 8, "instrumentalness");
                    updateCommand.Parameters.Add("@liveness", SqlDbType.Float, 8, "liveness");
                    updateCommand.Parameters.Add("@valence", SqlDbType.Float, 8, "valence");
                    updateCommand.Parameters.Add("@tempo", SqlDbType.Float, 8, "tempo");
                    updateCommand.Parameters.Add("@duration_ms", SqlDbType.Int, 4, "duration_ms");
                    dataAdapter.UpdateCommand = updateCommand;

                    // Actualizar la base de datos con los cambios realizados en el DataTable
                    dataAdapter.Update(dataTable);

                    // Confirmación de cambios guardados
                    MessageBox.Show("Cambios guardados correctamente en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios en la base de datos: " + ex.Message);
            }
        }

        private void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Eliminar la fila de la base de datos
            DataRowView rowView = (DataRowView)e.Row.DataBoundItem;
            DataRow row = rowView.Row;
            row.Delete();
        }

        private void DataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Manejar la inserción o actualización de una fila en el DataGridView
            DataGridViewRow dataGridViewRow = DataGridView.Rows[e.RowIndex];

            // Verificar si es una nueva fila o una fila existente
            if (dataGridViewRow.IsNewRow) return;

            // Actualizar la fila en el DataTable
            DataRowView rowView = (DataRowView)dataGridViewRow.DataBoundItem;
            DataRow row = rowView.Row;
            row["track_id"] = dataGridViewRow.Cells["track_id"].Value;
            row["track_name"] = dataGridViewRow.Cells["track_name"].Value;
            row["track_artist"] = dataGridViewRow.Cells["track_artist"].Value;
            row["track_popularity"] = dataGridViewRow.Cells["track_popularity"].Value;
            row["track_album_id"] = dataGridViewRow.Cells["track_album_id"].Value;
            row["track_album_name"] = dataGridViewRow.Cells["track_album_name"].Value;
            row["track_album_release_date"] = dataGridViewRow.Cells["track_album_release_date"].Value;
            row["playlist_name"] = dataGridViewRow.Cells["playlist_name"].Value;
            row["playlist_id"] = dataGridViewRow.Cells["playlist_id"].Value;
            row["playlist_genre"] = dataGridViewRow.Cells["playlist_genre"].Value;
            row["playlist_subgenre"] = dataGridViewRow.Cells["playlist_subgenre"].Value;
            row["danceability"] = dataGridViewRow.Cells["danceability"].Value;
            row["energy"] = dataGridViewRow.Cells["energy"].Value;
            row["key"] = dataGridViewRow.Cells["key"].Value;
            row["loudness"] = dataGridViewRow.Cells["loudness"].Value;
            row["mode"] = dataGridViewRow.Cells["mode"].Value;
            row["speechiness"] = dataGridViewRow.Cells["speechiness"].Value;
            row["acousticness"] = dataGridViewRow.Cells["acousticness"].Value;
            row["instrumentalness"] = dataGridViewRow.Cells["instrumentalness"].Value;
            row["liveness"] = dataGridViewRow.Cells["liveness"].Value;
            row["valence"] = dataGridViewRow.Cells["valence"].Value;
            row["tempo"] = dataGridViewRow.Cells["tempo"].Value;
            row["duration_ms"] = dataGridViewRow.Cells["duration_ms"].Value;
        }
    }
}

