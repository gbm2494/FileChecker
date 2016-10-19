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
        
        //ruta del archivo de reglas 
        string rulesFile;

        //ruta del archivo a evaluar individualmente
        string filetoEvaluate;

        //contenido del archivo a evaluar
        string evaluate;

        //ruta de la carpeta donde se encuentran todos los archivos a evaluar grupalmente
        string rutaArchivos;

        //ruta donde se debe guardar el archivo de resultados
        string rutaResultados;

        //folders para obtener las rutas
        FolderBrowserDialog folder = new FolderBrowserDialog();
        FolderBrowserDialog folderResultados = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent(); 
        }

        /*
         */
        public void estiloGrid()
        {
            dgvResultados.ColumnCount = 2;
            dgvResultados.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            dgvResultados.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        }

        /*Botón para cargar el conjunto de reglas en el botón del panel individual
         */
        private void button1_Click(object sender, EventArgs e)
        {
            cargarReglas();
        }

        /*
         */
        private void cargarReglas()
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Se muestra el dialogo
            if (result == DialogResult.OK) // Resultado de la selección
            {
                rulesFile = openFileDialog1.FileName;
                Console.WriteLine(rulesFile);
            }
        }

        /*Botón para cargar el archivo a evaluar individualmente
         */
        private void btnArchivo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog(); // Se muestra el dialogo
            
            if (result == DialogResult.OK) // Resultado de la selección
            {
                filetoEvaluate = openFileDialog2.FileName;
                Console.WriteLine(filetoEvaluate);

                try
                {
                    //carga en memoria el contenido del archivo
                    //evaluate = File.ReadAllText(filetoEvaluate);
                    evaluate = quitarComentarios(filetoEvaluate);
                    //Console.WriteLine(evaluate); 

                }
                catch (IOException)
                {
                }
            }
        }

        /*
         */
        public string quitarComentarios(string ruta)
        {
            string linea;
            bool comentario = false;
            bool comentarioLinea = false;
            string resultado = "";

            // lee el conjunto de reglas para evaluar el archivo
            System.IO.StreamReader file = new System.IO.StreamReader(ruta);

            while ((linea = file.ReadLine()) != null)
            {
                if (linea.Contains("/*") == true && linea.Contains("*/") == false)
                {
                    comentario = true;
                }
                else if ((linea.Contains("/*") == true && linea.Contains("*/") == true) || linea.Contains("--") == true)
                {
                    comentarioLinea = true;
                }

                if (comentarioLinea == false && comentario == false)
                {
                    resultado = resultado + linea;
                  //  Console.WriteLine(linea);
                }

                if (linea.Contains("*/") == true)
                {
                    comentario = false;
                }

                if ((linea.Contains("/*") == true && linea.Contains("*/") == true) || linea.Contains("--") == true)
                {
                    comentarioLinea = false;
                }

            }

            file.Close();

            return resultado;
        }

        /*Botón para evaluar individualmente un archivo*/
        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            string rule;

            dgvResultados.Columns.Add("Regla", "Regla");
            dgvResultados.Columns.Add("Cantidad", "Cantidad");

            // lee el conjunto de reglas para evaluar el archivo
            System.IO.StreamReader file = new System.IO.StreamReader(rulesFile);

            while ((rule = file.ReadLine()) != null)
            {
                int resultados = Regex.Matches(evaluate.ToUpper(), rule.ToUpper()).Count;

                string[] fila = new string[] { rule.ToUpper(), resultados.ToString() };

                dgvResultados.Rows.Add(fila);
               // Console.WriteLine(rule);
            }

            file.Close();

        }

        /*
         */
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

        /*
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            btnReporte.Hide();
        }

        /*
         */
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

        /*Botón para cargar las reglas en el panel grupal
         */
        private void btnReglas2_Click(object sender, EventArgs e)
        {
            cargarReglas();
        }

        /*Botón para cargar la ruta donde se desea guardar el excel de resultados
         */
        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            folder.Description = "Seleccione la carpeta donde se ubican los archivos a evaluar";

            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaArchivos = folder.SelectedPath;
                Console.WriteLine(rutaArchivos);

            }
        }

        /*Botón para generar la evaluación grupal
         */
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

                    int cambioColor = 0;

                    xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[contadorFilas, 1] = "Estudiante";
                    xlWorkSheet.Cells[contadorFilas, 2] = "Regla";
                    xlWorkSheet.Cells[contadorFilas, 3] = "Cantidad";

                    foreach (string name in archivos)
                    {
                        cambioColor++;
                        evaluate = quitarComentarios(name);

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
                            if (cambioColor % 2 == 0)
                            {
                                xlWorkSheet.Cells[contadorFilas, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                                xlWorkSheet.Cells[contadorFilas, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                            }
                            else
                            {
                                xlWorkSheet.Cells[contadorFilas, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                                xlWorkSheet.Cells[contadorFilas, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            
                        }


                            //Console.WriteLine(rule);
                        }

                        file.Close();

                    }
                    MessageBox.Show("Archivo excel generado con éxito");

                }
            }
            
        }

        /*
         */
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
