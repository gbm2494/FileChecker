using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChecker
{
    public partial class Form1 : Form
    {
        string rulesFile;
        string filetoEvaluate;
        string evaluate;
        string rutaArchivos;
        FolderBrowserDialog folder = new FolderBrowserDialog();




        public Form1()
        {
            InitializeComponent();
            dgvResultados.ColumnCount = 2;
            dgvResultados.ColumnHeadersVisible = true;
            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgvResultados.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                rulesFile = openFileDialog1.FileName;
                Console.WriteLine(rulesFile);
            }
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            
            if (result == DialogResult.OK) // Test result.
            {
                filetoEvaluate = openFileDialog1.FileName;
                Console.WriteLine(filetoEvaluate);

                try
                {
                    evaluate = File.ReadAllText(filetoEvaluate);
                    //Console.WriteLine(evaluate); 

                }
                catch (IOException)
                {
                }
            }
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string rule;

            dgvResultados.Columns[0].Name = "Regla";
            dgvResultados.Columns[1].Name = "Cantidad";

            // lee el conjunto de reglas para evaluar el archivo
            System.IO.StreamReader file = new System.IO.StreamReader(rulesFile);

            while ((rule = file.ReadLine()) != null)
            {
                int resultados = Regex.Matches(evaluate.ToUpper(), rule.ToUpper()).Count;

                string[] fila = new string[] { rule.ToUpper(), resultados.ToString() };

                dgvResultados.Rows.Add(fila);
                Console.WriteLine(rule);
            }

            file.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab == tabMenu.TabPages["Grupal"])//your specific tabname
            {
                btnReporte.Show();
                dgvResultados.Hide();
            }
            else {
                btnReporte.Hide();
                dgvResultados.Show();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnReporte.Hide();
        }


        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void btnReglas2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                rulesFile = openFileDialog1.FileName;
                Console.WriteLine(rulesFile);
            }
        }

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            folder.Description = "Seleccione la carpeta donde se ubican los archivos a evaluar";

            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaArchivos = folder.SelectedPath;
            }
        }

        private void btnEvaluarGrupal_Click(object sender, EventArgs e)
        {
            ///*Si existen archivos válidos de hilos para la simulación*/
            //if (Directory.GetFiles(rutaArchivos, "*.sql").Length != 0)
            //{
            //    string[] archivos = Directory.GetFiles(rutaArchivos, "*.sql");

            //    foreach (string name in archivos)
            //    {

            //    }
            //}
            //    int counter = 0;
            //string rule;

            //dgvResultados.Columns[0].Name = "Regla";
            //dgvResultados.Columns[1].Name = "Cantidad";

            //// lee el conjunto de reglas para evaluar el archivo
            //System.IO.StreamReader file = new System.IO.StreamReader(rulesFile);

            //while ((rule = file.ReadLine()) != null)
            //{
            //    int resultados = Regex.Matches(evaluate.ToUpper(), rule.ToUpper()).Count;

            //    string[] fila = new string[] { rule.ToUpper(), resultados.ToString() };

            //    dgvResultados.Rows.Add(fila);
            //    Console.WriteLine(rule);
            //}

            //file.Close();
        }
    }
}
