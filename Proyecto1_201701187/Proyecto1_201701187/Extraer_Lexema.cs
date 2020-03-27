using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Extraer_Lexema
    {
        public static List<Lexema> lista_lexema = new List<Lexema>();
        public static List<string> Entrada = new List<string>();
        public static List<Tokens> ListaTokens;
        public static string nombre;
        public static string cadena;
        public static bool bandera=false;

        public void agregar(String nombre, String cadena)
        {

            Lexema nuevo = new Lexema(nombre, cadena);
            lista_lexema.Add(nuevo);

        }

        public void ER(List<Tokens> Aceptacion)
        {
            ListaTokens = Aceptacion;


            //Recorrido para sacar la ER de la tabla tokens
            for (int i = 0; i < ListaTokens.Count; i++)
            {

                //Verificar si es ID
                if (ListaTokens[i].getId() == 5)
                {
                    cadena = ListaTokens[i].getLexema();
                    i++;
                    // Verifico si es :
                    if (ListaTokens[i].getId() == 18)
                    {
                        cadena += ListaTokens[i].getLexema();
                        i++;
                        //Verificar si es Lexema de entrada
                        if (ListaTokens[i].getId() == 4)
                        {
                            cadena += ListaTokens[i].getLexema();
                            Entrada.Add(cadena);
                       }

                    }
                    else
                    {
                        cadena = null;
                    }


                        }
                    }

            for (int i = 0; i < Entrada.Count; i++)
            {
                Console.WriteLine(Entrada[i]);
            }

            desglozar();

        }


        public void desglozar()
        {
            String juntar = "";
            string nombre = "";
            string cad = "";
            String er = "";
            char caracter = ' ';
            int estado = 0;

            for (int i = 0; i < Entrada.Count; i++)
            {
                er = Entrada[i];

                for (int j = 0; j < er.Length; j++)
                {
                    caracter = er[j];

                    switch (estado)
                    {
                        case 0:
                            if (Char.IsLetter(caracter))
                            {
                                juntar += caracter;
                                estado = 2;
                            }
                            else if (caracter == (char)34)
                            {
                                estado = 1;
                            }
                            break;

                        case 1:

                            if (caracter != (char)34)
                            {
                                cad += caracter;
                            }
                            else
                            {

                               // cad = juntar;
                                juntar = "";
                                estado = 0;
                            }

                            break;

                        case 2:

                            if (Char.IsLetter(caracter))
                            {
                                juntar += caracter;
                            }
                            else if (Char.IsDigit(caracter))
                            {
                                juntar += caracter;
                            }
                            else if (caracter == (char)95)
                            {
                                juntar += caracter;
                            }
                            else
                            {

                                nombre = juntar;
                                juntar = "";
                                j--;
                                estado = 0;

                            }

                            break;

                    }


                }

                agregar(nombre,cad);
                cad = "";
            }

            for (int i = 0; i < lista_lexema.Count; i++)
            {
                Console.WriteLine(lista_lexema[i].Chain);
            }

            Form1 mandar = new Form1();
           // mandar.Lexemas(lista_lexema);


        }

    }


}


