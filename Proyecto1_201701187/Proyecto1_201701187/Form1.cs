using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201701187
{
    public partial class Form1 : Form
    {

        public String Archivos;
        public int contador_guardado;
        private static List<Tokens> Lista_Aceptacion = new List<Tokens>();
        private static List<Tokens> Lista_Error = new List<Tokens>();
        public static List<string> nombresAFN = new List<string>();
        public static List<string> nombresAFD = new List<string>();
        public static List<string> nombresTabla = new List<string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Selector_de_archivos = new OpenFileDialog();
            Selector_de_archivos.Filter = "Archivo extencion er|*.er";
            Selector_de_archivos.Title = "Select a Cursor File";
            if (Selector_de_archivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                StreamReader lector = new StreamReader(Selector_de_archivos.FileName);
                Archivos = Selector_de_archivos.FileName;
                entrada.Text = lector.ReadToEnd();
                Dock = DockStyle.Fill;
                lector.Close();
                contador_guardado = 1;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contador_guardado == 1)
            {
                StreamWriter sobreescribir = new StreamWriter(Archivos);
                sobreescribir.Write(entrada.Text);
                sobreescribir.Close();
            }
            else
            {
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.Title = "Seleccione donde quiere guardar el Documento nuevo...";
                Guardar.Filter = "Archivo extencion ddc|*.ddc";
                Guardar.AddExtension = true;
                if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter escribir = new StreamWriter(Guardar.FileName);
                    escribir.Write(entrada.Text);
                    escribir.Close();
                    Archivos = Guardar.FileName;
                    contador_guardado = 1;
                   
                }

            }
        }

        private void loadThompsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_Aceptacion.Clear();
            Lista_Error.Clear();

            Scanner iniciar = new Scanner();
            iniciar.scanner(entrada.Text);

            if (Lista_Error.Count!=0)
            {
                Console.WriteLine("Existe error");
            }else
            {
                Console.WriteLine("Todo bien, todo correcto");
                Extraer_ER mandar = new Extraer_ER();
                mandar.ER(Lista_Aceptacion);
                agregar();
            }

            
        }

        public void traer(List<Tokens> lista_aceptada, List<Tokens> lista_error)
        {

            Lista_Aceptacion = lista_aceptada;
            Lista_Error = lista_error;
        }

        public void traer_nombre(string AFN, String AFD, string Tabla)
        {
            nombresAFN.Add(AFN);
            nombresAFD.Add(AFD);
            nombresTabla.Add(Tabla);
        }

        public void agregar()
        {
            for (int i = 0; i < nombresAFN.Count; i++)
            {
                AFN.Items.Add(nombresAFN[i]);
                
            }

            for (int i = 0; i < nombresAFD.Count; i++)
            {
                AFD.Items.Add(nombresAFD[i]);

            }

            for (int i = 0; i < nombresTabla.Count; i++)
            {
                Tabla.Items.Add(nombresTabla[i]);

            }

        }

        private void AFN_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posiciones;

            posiciones = AFN.SelectedIndex+1;
            Form2 abrir = new Form2("D:\\Casca\\Documents\\Compi 1\\-OLC1-Proyecto1_201701187\\Proyecto1_201701187\\Proyecto1_201701187\\bin\\Debug\\" + "AFN" + posiciones + ".png");
            abrir.Show();

        }

        private void AFD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posiciones;

            posiciones = AFD.SelectedIndex + 1;
            Form2 abrir = new Form2("D:\\Casca\\Documents\\Compi 1\\-OLC1-Proyecto1_201701187\\Proyecto1_201701187\\Proyecto1_201701187\\bin\\Debug\\" + "AFD" + posiciones + ".png");
            abrir.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Tabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posiciones;

            posiciones = Tabla.SelectedIndex + 1;
            Form2 abrir = new Form2("D:\\Casca\\Documents\\Compi 1\\-OLC1-Proyecto1_201701187\\Proyecto1_201701187\\Proyecto1_201701187\\bin\\Debug\\" + "Tabla_Transicion" + posiciones + ".png");
            abrir.Show();
        }
    }
}
