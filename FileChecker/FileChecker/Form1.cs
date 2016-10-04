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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace FileChecker
{
    public partial class Form1 : Form
    {
        /*Variables necesarias para escribir en el excel*/
        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        object misValue;
        Workbook xlWorkBook;
        Worksheet xlWorkSheet;

        /*Variables para manejar los archivos*/
        string rulesFile;
        string filetoEvaluate;
        string evaluate;
        string rutaArchivos;
        string rutaResultados;
        FolderBrowserDialog folder = new FolderBrowserDialog();
        FolderBrowserDialog folderResultados = new FolderBrowserDialog();





        public Form1()
        {
            InitializeComponent();
            dgvResultados.ColumnCount = 2;
            dgvResultados.ColumnHeadersVisible = true;
            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            dgvResultados.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarReglas();
        }

        private void cargarReglas()
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
            folderResultados.Description = "Seleccione la carpeta donde se ubican los archivos a evaluar";

            if (folderResultados.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(folderResultados.SelectedPath + "\\resultados.xls");
                xlWorkBook.SaveAs(folderResultados.SelectedPath + "\\resultados.xls");
            }

           
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);
            MessageBox.Show("Archivo descargado con éxito");


        }

        private void btnReglas2_Click(object sender, EventArgs e)
        {
            cargarReglas();
        }

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            folder.Description = "Seleccione la carpeta donde se ubican los archivos a evaluar";

            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaArchivos = folder.SelectedPath;
                Console.WriteLine(rutaArchivos);

            }
        }

        private void btnEvaluarGrupal_Click(object sender, EventArgs e)
        {
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            else {//si existe excel en esta máquina

                try {
                    xlWorkBook = null;
                    xlWorkBook = xlApp.Workbooks.Add();
                }
                catch (COMException ex)
                {
                    Console.WriteLine(ex.InnerException.ToString());
                }

                misValue = System.Reflection.Missing.Value;

                int contadorFilas = 1;

                /*Si existen archivos válidos de hilos para la simulación*/
                if (Directory.GetFiles(rutaArchivos, "*.sql").Length != 0)
                {
                    string[] archivos = Directory.GetFiles(rutaArchivos, "*.sql");

                    xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[contadorFilas, 1] = "Estudiante";
                    xlWorkSheet.Cells[contadorFilas, 2] = "Regla";
                    xlWorkSheet.Cells[contadorFilas, 3] = "Cantidad";

                    foreach (string name in archivos)
                    {
                        evaluate = File.ReadAllText(name);

                        //añadir el nombre del archivo al excel
                        string[] division = name.Split('\\');
                        xlWorkSheet.Cells[contadorFilas+1, 1] = division[division.Length-1];

                        string rule;

                        // lee el conjunto de reglas para evaluar el archivo
                        System.IO.StreamReader file = new System.IO.StreamReader(rulesFile);

                        while ((rule = file.ReadLine()) != null)
                        {
                            contadorFilas++;
                            int resultados = Regex.Matches(evaluate.ToUpper(), rule.ToUpper()).Count;

                            xlWorkSheet.Cells[contadorFilas, 2] = rule.ToUpper();
                            xlWorkSheet.Cells[contadorFilas, 3] = resultados.ToString();

                            Console.WriteLine(rule);
                        }

                        file.Close();

                    }
                    MessageBox.Show("Archivo excel generado con éxito");

                }
            }
            
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
