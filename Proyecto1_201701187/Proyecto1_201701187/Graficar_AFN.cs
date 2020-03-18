using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    class Graficar_AFN
    {

        String ruta;
        StringBuilder grafo;
        
        

        public void generardot(String name)
        {

            System.IO.File.WriteAllText(name + ".dot", grafo.ToString());
            ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe ");
            startInfo.Arguments = "-Tpng " + name + ".dot -o " + name + ".png ";
            Process.Start(startInfo).WaitForExit();

        }

        public void graficar(String contents, String name)
        {

            grafo = new StringBuilder();
            ruta = name + ".png";
            grafo.Append(contents);
            Console.WriteLine(contents);
            this.generardot(name);
            abrir();

        }


        public String abrir()
        {
            if (File.Exists(this.ruta))
            {
                try
                {
                    System.Diagnostics.Process.Start(this.ruta); //Hace que la imagen se abra
                    return this.ruta;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error" + ex);
                    return "";
                }
            }
            else
            {
                Console.WriteLine("Archivo no existe");
                return "";
            }
        }


    }
}
