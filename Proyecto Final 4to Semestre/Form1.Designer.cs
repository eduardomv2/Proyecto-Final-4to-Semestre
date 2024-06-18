namespace Proyecto_Final_4to_Semestre
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.btnGuardarCSV = new System.Windows.Forms.Button();
            this.btnGuardarJSON = new System.Windows.Forms.Button();
            this.btnGuardarXML = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLeerXML = new System.Windows.Forms.Button();
            this.btnLeerJSON = new System.Windows.Forms.Button();
            this.btnLeerCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnGuardarYaml = new System.Windows.Forms.Button();
            this.btnLeerYAML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToOrderColumns = true;
            this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.Location = new System.Drawing.Point(12, 37);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(1418, 534);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnGuardarCSV
            // 
            this.btnGuardarCSV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCSV.Location = new System.Drawing.Point(84, 638);
            this.btnGuardarCSV.Name = "btnGuardarCSV";
            this.btnGuardarCSV.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarCSV.TabIndex = 1;
            this.btnGuardarCSV.Text = "CSV";
            this.btnGuardarCSV.UseVisualStyleBackColor = true;
            this.btnGuardarCSV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardarJSON
            // 
            this.btnGuardarJSON.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarJSON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarJSON.Location = new System.Drawing.Point(190, 638);
            this.btnGuardarJSON.Name = "btnGuardarJSON";
            this.btnGuardarJSON.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarJSON.TabIndex = 2;
            this.btnGuardarJSON.Text = "JSON";
            this.btnGuardarJSON.UseVisualStyleBackColor = true;
            this.btnGuardarJSON.Click += new System.EventHandler(this.btnGuardarJSON_Click);
            // 
            // btnGuardarXML
            // 
            this.btnGuardarXML.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarXML.Location = new System.Drawing.Point(296, 638);
            this.btnGuardarXML.Name = "btnGuardarXML";
            this.btnGuardarXML.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarXML.TabIndex = 3;
            this.btnGuardarXML.Text = "XML";
            this.btnGuardarXML.UseVisualStyleBackColor = true;
            this.btnGuardarXML.Click += new System.EventHandler(this.btnGuardarXML_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(1202, 638);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLeerXML
            // 
            this.btnLeerXML.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeerXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeerXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerXML.Location = new System.Drawing.Point(820, 638);
            this.btnLeerXML.Name = "btnLeerXML";
            this.btnLeerXML.Size = new System.Drawing.Size(100, 28);
            this.btnLeerXML.TabIndex = 8;
            this.btnLeerXML.Text = "XML";
            this.btnLeerXML.UseVisualStyleBackColor = true;
            this.btnLeerXML.Click += new System.EventHandler(this.btnLeerXML_Click);
            // 
            // btnLeerJSON
            // 
            this.btnLeerJSON.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeerJSON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeerJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerJSON.Location = new System.Drawing.Point(714, 638);
            this.btnLeerJSON.Name = "btnLeerJSON";
            this.btnLeerJSON.Size = new System.Drawing.Size(100, 28);
            this.btnLeerJSON.TabIndex = 7;
            this.btnLeerJSON.Text = "JSON";
            this.btnLeerJSON.UseVisualStyleBackColor = true;
            this.btnLeerJSON.Click += new System.EventHandler(this.btnLeerJSON_Click);
            // 
            // btnLeerCSV
            // 
            this.btnLeerCSV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeerCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeerCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerCSV.Location = new System.Drawing.Point(608, 638);
            this.btnLeerCSV.Name = "btnLeerCSV";
            this.btnLeerCSV.Size = new System.Drawing.Size(100, 28);
            this.btnLeerCSV.TabIndex = 6;
            this.btnLeerCSV.Text = "CSV";
            this.btnLeerCSV.UseVisualStyleBackColor = true;
            this.btnLeerCSV.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 575);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1375, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "GUARDAR EN FORMATOS:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(740, 602);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "LEER LOS FORMATOS:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1136, 602);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "GUARDAR MODIFICACIONES:";
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.Chartreuse;
            this.btnMaximizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Location = new System.Drawing.Point(1388, 10);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(17, 15);
            this.btnMaximizar.TabIndex = 13;
            this.btnMaximizar.UseVisualStyleBackColor = false;
            this.btnMaximizar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(1412, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(17, 15);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(1363, 10);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(17, 15);
            this.btnMinimizar.TabIndex = 15;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnGuardarYaml
            // 
            this.btnGuardarYaml.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarYaml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarYaml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarYaml.Location = new System.Drawing.Point(402, 638);
            this.btnGuardarYaml.Name = "btnGuardarYaml";
            this.btnGuardarYaml.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarYaml.TabIndex = 16;
            this.btnGuardarYaml.Text = "YAML";
            this.btnGuardarYaml.UseVisualStyleBackColor = true;
            this.btnGuardarYaml.Click += new System.EventHandler(this.btnGuardarYaml_Click);
            // 
            // btnLeerYAML
            // 
            this.btnLeerYAML.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeerYAML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeerYAML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerYAML.Location = new System.Drawing.Point(926, 638);
            this.btnLeerYAML.Name = "btnLeerYAML";
            this.btnLeerYAML.Size = new System.Drawing.Size(100, 28);
            this.btnLeerYAML.TabIndex = 17;
            this.btnLeerYAML.Text = "YAML";
            this.btnLeerYAML.UseVisualStyleBackColor = true;
            this.btnLeerYAML.Click += new System.EventHandler(this.btnLeerYAML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1442, 689);
            this.Controls.Add(this.btnLeerYAML);
            this.Controls.Add(this.btnGuardarYaml);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMaximizar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLeerXML);
            this.Controls.Add(this.btnLeerJSON);
            this.Controls.Add(this.btnLeerCSV);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnGuardarXML);
            this.Controls.Add(this.btnGuardarJSON);
            this.Controls.Add(this.btnGuardarCSV);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button btnGuardarCSV;
        private System.Windows.Forms.Button btnGuardarJSON;
        private System.Windows.Forms.Button btnGuardarXML;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLeerXML;
        private System.Windows.Forms.Button btnLeerJSON;
        private System.Windows.Forms.Button btnLeerCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnGuardarYaml;
        private System.Windows.Forms.Button btnLeerYAML;
    }
}

