namespace FileChecker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEvaluar = new System.Windows.Forms.Button();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReglas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.Invidual = new System.Windows.Forms.TabPage();
            this.Grupal = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEvaluarGrupal = new System.Windows.Forms.Button();
            this.btnCarpeta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReglas2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.tabMenu.SuspendLayout();
            this.Invidual.SuspendLayout();
            this.Grupal.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnEvaluar);
            this.groupBox1.Controls.Add(this.btnArchivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnReglas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a validar";
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.Location = new System.Drawing.Point(249, 124);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(119, 31);
            this.btnEvaluar.TabIndex = 6;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // btnArchivo
            // 
            this.btnArchivo.Location = new System.Drawing.Point(249, 72);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(119, 31);
            this.btnArchivo.TabIndex = 5;
            this.btnArchivo.Text = "Buscar archivo";
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Archivo a evaluar:";
            // 
            // btnReglas
            // 
            this.btnReglas.Location = new System.Drawing.Point(249, 35);
            this.btnReglas.Name = "btnReglas";
            this.btnReglas.Size = new System.Drawing.Size(119, 31);
            this.btnReglas.TabIndex = 1;
            this.btnReglas.Text = "Buscar reglas";
            this.btnReglas.UseVisualStyleBackColor = true;
            this.btnReglas.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reglas:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.btnReporte);
            this.gbResultados.Controls.Add(this.dgvResultados);
            this.gbResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultados.Location = new System.Drawing.Point(35, 222);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(432, 382);
            this.gbResultados.TabIndex = 5;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(165, 126);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(119, 31);
            this.btnReporte.TabIndex = 7;
            this.btnReporte.Text = "Generar reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(19, 25);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(389, 331);
            this.dgvResultados.TabIndex = 0;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.Invidual);
            this.tabMenu.Controls.Add(this.Grupal);
            this.tabMenu.Location = new System.Drawing.Point(29, 9);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(446, 207);
            this.tabMenu.TabIndex = 7;
            this.tabMenu.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Invidual
            // 
            this.Invidual.BackColor = System.Drawing.SystemColors.Control;
            this.Invidual.Controls.Add(this.groupBox1);
            this.Invidual.Location = new System.Drawing.Point(4, 22);
            this.Invidual.Name = "Invidual";
            this.Invidual.Padding = new System.Windows.Forms.Padding(3);
            this.Invidual.Size = new System.Drawing.Size(438, 181);
            this.Invidual.TabIndex = 0;
            this.Invidual.Text = "Individual";
            // 
            // Grupal
            // 
            this.Grupal.BackColor = System.Drawing.SystemColors.Control;
            this.Grupal.Controls.Add(this.groupBox3);
            this.Grupal.Location = new System.Drawing.Point(4, 22);
            this.Grupal.Name = "Grupal";
            this.Grupal.Padding = new System.Windows.Forms.Padding(3);
            this.Grupal.Size = new System.Drawing.Size(438, 181);
            this.Grupal.TabIndex = 1;
            this.Grupal.Text = "Grupal";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.btnEvaluarGrupal);
            this.groupBox3.Controls.Add(this.btnCarpeta);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnReglas2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 175);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos a validar";
            // 
            // btnEvaluarGrupal
            // 
            this.btnEvaluarGrupal.Location = new System.Drawing.Point(249, 124);
            this.btnEvaluarGrupal.Name = "btnEvaluarGrupal";
            this.btnEvaluarGrupal.Size = new System.Drawing.Size(119, 31);
            this.btnEvaluarGrupal.TabIndex = 6;
            this.btnEvaluarGrupal.Text = "Evaluar";
            this.btnEvaluarGrupal.UseVisualStyleBackColor = true;
            this.btnEvaluarGrupal.Click += new System.EventHandler(this.btnEvaluarGrupal_Click);
            // 
            // btnCarpeta
            // 
            this.btnCarpeta.Location = new System.Drawing.Point(249, 72);
            this.btnCarpeta.Name = "btnCarpeta";
            this.btnCarpeta.Size = new System.Drawing.Size(119, 31);
            this.btnCarpeta.TabIndex = 5;
            this.btnCarpeta.Text = "Buscar carpeta";
            this.btnCarpeta.UseVisualStyleBackColor = true;
            this.btnCarpeta.Click += new System.EventHandler(this.btnCarpeta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Carpeta de archivos:";
            // 
            // btnReglas2
            // 
            this.btnReglas2.Location = new System.Drawing.Point(249, 35);
            this.btnReglas2.Name = "btnReglas2";
            this.btnReglas2.Size = new System.Drawing.Size(119, 31);
            this.btnReglas2.TabIndex = 1;
            this.btnReglas2.Text = "Buscar reglas";
            this.btnReglas2.UseVisualStyleBackColor = true;
            this.btnReglas2.Click += new System.EventHandler(this.btnReglas2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reglas:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 628);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.gbResultados);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.tabMenu.ResumeLayout(false);
            this.Invidual.ResumeLayout(false);
            this.Grupal.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReglas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.Button btnEvaluar;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage Invidual;
        private System.Windows.Forms.TabPage Grupal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEvaluarGrupal;
        private System.Windows.Forms.Button btnCarpeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReglas2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReporte;
    }
}

