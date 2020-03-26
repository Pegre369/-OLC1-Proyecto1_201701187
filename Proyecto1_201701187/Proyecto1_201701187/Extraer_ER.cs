using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Extraer_ER
    {

        public static List<Tokens> ListaTokens;
        public static List<string> ERs = new List<string>();
        public static String cadena;
        public static List<Lista_ER> Caracteres = new List<Lista_ER>();
        public static List<Thompson> guardado = new List<Thompson>();
        public static int index=1;
        public static bool bandera = false;

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
                    // Verifico si es -
                    if (ListaTokens[i].getId() == 16)
                    {
                        cadena += ListaTokens[i].getLexema();
                        i++;
                        //Verificar si es >
                        if (ListaTokens[i].getId() == 36)
                    {
                             cadena += ListaTokens[i].getLexema();
                            i++;
                        //Ciclo para validar todo lo que esta despues del > y antes del punto y coma
                        while (ListaTokens[i].getId() != 31)
                        {
                            //Verificar si es el punto de concatenacion
                            if (ListaTokens[i].getId() == 17)
                            {
                                if (cadena != null)
                                {

                                    cadena += ListaTokens[i].getLexema();
                                    i++;
                                    //Valido todo lo que esta antes del punto y coma

                                    while (ListaTokens[i].getId() != 31)
                                    {
                                        cadena = cadena + ListaTokens[i].getLexema();
                                        i++;
                                    }

                                    ERs.Add(cadena);
                                    cadena = null;

                                }


                            }
                            else
                            {
                                cadena = null;
                                i++;
                            }

                        }


                    }
                }
             } 

            }



              //Verificar si mi Linkedlist esta llena
               for (int i = 0; i < ERs.Count; i++) {
                  if(ERs[i]!=null){
                    Console.WriteLine(ERs[i]);
                  }
              }

            Separacion();
        }

        public void agregar(String etiqueta, String descripcion)
        {

            Lista_ER nuevo = new Lista_ER(etiqueta, descripcion);
            Caracteres.Add(nuevo);

        }

        public void Separacion()
        {
            string nombreER = "";
            String cc = "";
            String er = "";
            char caracter = ' ';
            int estado = 0;

            //Aqui recorro la linkedlist que contiene la ER 
            for (int i = 0; i < ERs.Count; i++)
            {
                

                er = ERs[i];
                for (int name = 0; name < er.Length; name++)
                {
                    caracter = er[name];
                    if (Char.IsLetter(caracter))
                    {
                        nombreER += caracter;
                    }
                    else if (Char.IsDigit(caracter))
                    {
                        nombreER += caracter;
                    }
                    else if (caracter == (char)95)
                    {
                        nombreER += caracter;
                    }
                    else
                    {
                        break;
                    }
                }
                //Aqui separo la ER de caracter por caracter y lo guardo en una linkedlist de caracteres
                for (int j = 3; j < er.Length; j++)
                {

                    caracter = er[j];

                    switch (estado)
                    {

                        case 0:

                            if (caracter == (char)46)
                            {
                                agregar(Char.ToString(caracter), "Concatenacion");
                                estado = 0;
                            }
                            else if (caracter == (char)124)
                            {
                                agregar(Char.ToString(caracter), "Or");
                                estado = 0;
                            }
                            else if (caracter == (char)63)
                            {
                                agregar(Char.ToString(caracter), "aparicion");
                                estado = 0;
                            }
                            else if (caracter == (char)42)
                            {
                                agregar(Char.ToString(caracter), "kleen");
                                estado = 0;
                            }
                            else if (caracter == (char)43)
                            {
                                agregar(Char.ToString(caracter), "positiva");
                                estado = 0;
                            }
                            else if (caracter == (char)34)
                            {
                                estado = 1;
                            }
                            else if (Char.IsLetter(caracter))
                            {
                                cc += caracter;
                                estado = 2;
                            }
                            else if (caracter == (char)59)
                            {

                            }
                            break;

                        case 1:

                            if (caracter != (char)34)
                            {
                                cc += caracter;
                            }
                            else
                            {

                                agregar(cc, "cadena");
                                cc = "";
                                estado = 0;
                            }

                            break;

                        case 2:

                            if (Char.IsLetter(caracter))
                            {
                                cc += caracter;
                            }
                            else if (Char.IsDigit(caracter))
                            {
                                cc += caracter;
                            }
                            else if (caracter == (char)95)
                            {
                                cc += caracter;
                            }
                            else
                            {

                                agregar(cc, "identificador");
                                cc = "";
                                j--;
                                estado = 0;
                                
                            }

                            break;
                        

                    }

                }

              /*  //Verificacion si separa la Expresion Regular  es correcta 
                   for (int j = 0; j < Caracteres.Count; j++) {

                      if (Caracteres[j] != null) {

                          Console.WriteLine(Caracteres[j].getEtiqueta() + " -> " + Caracteres[j].getDescripcion());

                      }
                  }
                Console.WriteLine(nombreER);
                  break;*/


                Thompson thom = new Thompson(Caracteres,nombreER ,"AFN" + index, "AFD"+index, "Tabla_Transicion"+index);
                Form1 mandar = new Form1();
                mandar.traer_nombre("AFN" + index, "AFD" + index, "Tabla_Transicion" + index);
                guardado.Add(thom);
                index++;
                Caracteres.Clear();
            }



        }


    }
}
