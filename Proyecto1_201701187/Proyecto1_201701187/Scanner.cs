using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
   public class Scanner
    {
        private List<Tokens> Lista_Aceptacion = new List<Tokens>();
        private List<Tokens> Lista_Error = new List<Tokens>();
        public int fila=0;
        public int columna = 0;


        public void Aceptar(String descripcion, String lexema, int fila, int columna, int id)
        {
            Tokens nuevo = new Tokens(descripcion, lexema, fila, columna, id);
            Lista_Aceptacion.Add(nuevo);
        }

        public void scanner(String entrada)
        {
            String Lexema = "";
            String Entrada = entrada;
            char caracter = ' ';
            int estado = 0;

            for (int i = 0; i < Entrada.Length; i++)
            {

                caracter = Entrada[i];

                switch (estado)
                {
                    //Verificacion de Simbolos Permitidos #,$,%,&,',(,),*,+,,,-,.,:,=,?,@,[,\,],^,_,`,{,|,}
                    case 0:

                        if (caracter == (char)35)
                        {
                            Aceptar("Numeral", Char.ToString(caracter), fila, columna, 6);
                            estado = 0;

                        } else if (caracter == (char)36)
                        {
                            Aceptar("Signo de Pesos", Char.ToString(caracter), fila, columna, 7);
                            estado = 0;

                        }else if (caracter == (char)37)
                        {
                            Aceptar("Signo de Porcentaje", Char.ToString(caracter), fila, columna, 8);
                            estado = 0;

                        }else if (caracter == (char)38)
                        {
                            Aceptar("Ampersand", Char.ToString(caracter), fila, columna, 9);
                            estado = 0;

                        }else if (caracter == (char)39)
                        {
                            Aceptar("Comillas simple", Char.ToString(caracter), fila, columna, 10);
                            estado = 0;
                            
                        }else if (caracter == (char)40)
                        {
                            Aceptar("Parentesis que abre", Char.ToString(caracter), fila, columna, 11);
                            estado = 0;

                        }else if (caracter == (char)41)
                        {
                            Aceptar("Parentesis que cierra", Char.ToString(caracter), fila, columna, 12);
                            estado = 0;

                        }else if (caracter == (char)42)
                        {
                            Aceptar("Asterisco", Char.ToString(caracter), fila, columna, 13);
                            estado = 0;

                        }else if (caracter == (char)43)
                        {
                            Aceptar("Signo más", Char.ToString(caracter), fila, columna, 14);
                            estado = 0;

                        }else if (caracter == (char)44)
                        {
                            Aceptar("Coma", Char.ToString(caracter), fila, columna, 15);
                            estado = 0;

                        }else if (caracter == (char)45)
                        {
                            Aceptar("Signo menos", Char.ToString(caracter), fila, columna, 16);
                            estado = 0;

                        }else if (caracter == (char)46)
                        {
                            Aceptar("Punto", Char.ToString(caracter), fila, columna, 17);
                            estado = 0;

                        }else if (caracter == (char)58)
                        {
                            Aceptar("Dos Puntos", Char.ToString(caracter), fila, columna, 18);
                            estado = 0;

                        }else if(caracter == (char)61)
                        {
                            Aceptar("Signo igual", Char.ToString(caracter), fila, columna, 19);
                            estado = 0;

                        }else if (caracter == (char)63)
                        {
                            Aceptar("Signo de interrogación", Char.ToString(caracter), fila, columna, 20);
                            estado = 0;
                        }else if (caracter == (char)64)
                        {
                            Aceptar("Arroba", Char.ToString(caracter), fila, columna, 21);
                            estado = 0;
                        }else if (caracter == (char)91)
                        {
                            Aceptar("Corchete que abre", Char.ToString(caracter), fila, columna, 22);
                            estado = 0;

                        } else if (caracter == (char)92)
                        {
                            Aceptar("Diagonal invertida", Char.ToString(caracter), fila, columna, 23);
                            estado = 0;

                        }else if (caracter == (char)93)
                        {
                            Aceptar("Corchete que cierra", Char.ToString(caracter), fila, columna, 24);
                            estado = 0;

                        }else if (caracter == (char)94)
                        {
                            Aceptar("Acento circunflejo", Char.ToString(caracter), fila, columna, 25);
                            estado = 0;

                        }else if (caracter == (char)95)
                        {
                            Aceptar("Guion bajo", Char.ToString(caracter), fila, columna, 26);
                            estado = 0;

                        }else if (caracter == (char)96)
                        {
                            Aceptar("Acento grave", Char.ToString(caracter), fila, columna, 27);
                            estado = 0;

                        }else if (caracter == (char)123)
                        {
                            Aceptar("Llave que abre", Char.ToString(caracter), fila, columna, 28);
                            estado = 0;

                        }else if (caracter == (char)124)
                        {
                            Aceptar("Barra Vertical", Char.ToString(caracter), fila, columna, 29);
                            estado = 0;
                            
                        }else if (caracter == (char)125)
                        {
                            Aceptar("Llave que cierra", Char.ToString(caracter), fila, columna, 30);
                            estado = 0;

                        }else if (caracter == (char)59)
                        {
                            Aceptar("Punto y coma", Char.ToString(caracter), fila, columna, 31);
                            estado = 0;

                        }else if (caracter == (char)33)
                        {
                            Aceptar("Signo de admiración", Char.ToString(caracter), fila, columna, 35);
                            estado = 0;

                        }else if (caracter == (char)62)
                        {
                            Aceptar("Mayor que", Char.ToString(caracter), fila, columna, 36);
                            estado = 0;

                        }else if (caracter == (char)126)
                        {
                            Aceptar("Tilde", Char.ToString(caracter), fila, columna, 37);
                            estado = 0;
                        
                        //Verificar si es Letra
                        }else if(Char.IsLetter(caracter))
                        {
                            Lexema += caracter;
                            estado = 1;

                        //Verificar si es Digito
                        }else if (Char.IsDigit(caracter))
                        {
                            Lexema += caracter;
                            estado = 2;

                        //Verificar si es Diagonal
                        }else if (caracter == (char)47)
                        {
                            Lexema += caracter;
                            estado = 3;
                            
                        //Verificar si es <
                        }else if (caracter == (char)60)
                        {
                            Lexema += caracter;
                            estado = 5;
                         
                        //Verificar si son comillas      
                        }else if (caracter == (char)34)
                        {
                            Lexema += caracter;
                            estado = 8;

                        //Verificar si es salto de linea
                        }else if (caracter == '\n')
                        {
                            columna = 1;
                            fila++;
                            estado = 0;

                        //Si es un espacio en blanco, tab, etc.
                        }
                        else if (caracter == ' ' | caracter == '\t' | caracter == '\b' | caracter == '\r' | caracter == '\f')
                        {

                        }else
                        {
                            Tokens Error = new Tokens("Error Lexico", Char.ToString(caracter), fila, columna, 0);
                            Lista_Error.Add(Error);
                            Lexema = "";
                            estado = 0;
                        }
                        break;

                    case 1:

                        //Verificar si es letra
                        if (Char.IsLetter(caracter))
                        {
                            Lexema += caracter;
                            estado = 1; 

                        //Verificar si es Digito
                        }else if (Char.IsDigit(caracter))
                        {
                            Lexema += caracter;
                            estado = 1;

                        //Verificar si es _
                        }else if (caracter == (char)95)
                        {
                            Lexema += caracter;
                            estado = 1;

                        }else
                        {
                            Palabra_Reservada(Lexema);
                            Lexema = "";
                            estado = 0;
                            i--;

                        }
                        break;


                    case 2:

                        //Verificar si es Digito
                        if (Char.IsDigit(caracter))
                        {
                            Lexema += caracter;
                            estado = 2;
                        }
                        else
                        {
                            Aceptar("Digito", Lexema, fila, columna, 32);
                            Lexema = "";
                            estado = 0;
                            i--;
                        }

                        break;

                    case 3:

                        //Verificar si es diagonal
                        if (caracter == (char)47)
                        {
                            Lexema += caracter;
                            estado = 4;
                        }
                        else
                        {
                            Aceptar("Diagonal", Lexema, fila, columna, 33);
                            Lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;

                    case 4:

                        if (caracter != '\n')
                        {
                            Lexema += caracter;
                            estado = 4;
                        }
                        else
                        {
                            Aceptar("Comentario de una linea", Lexema, fila, columna, 2);
                            columna = 1;
                            fila++;
                            Lexema = "";
                            estado = 0;
                        }

                        break;

                    case 5:

                        //Verificar si es !
                        if (caracter == (char)33)
                        {
                            Lexema += caracter;
                            estado = 6;
                        }
                        else
                        {
                            Aceptar("Menor que", Lexema, fila, columna, 34);
                            Lexema = "";
                            estado = 0;
                            i--;
                        }

                        break;

                    case 6:

                        if (caracter != (char)33)
                        {
                            Lexema += caracter;
                            estado = 6;
                        }
                        else
                        {
                            Lexema += caracter;
                            estado = 7;
                        }
                        break;

                    case 7:

                        //Verificar si es >
                        if (caracter == (char)62)
                        {
                            Lexema += caracter;
                            Aceptar("Comentario Multilineas", Lexema, fila, columna, 3);
                            Lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            Lexema += caracter;
                            estado = 6;
                        }

                        break;

                    case 8:

                        if (caracter != (char)34)
                        {
                            Lexema += caracter;
                            estado = 8;
                        }
                        else
                        {
                            Lexema += caracter;
                            Aceptar("Lexema de entrada", Lexema, fila, columna, 4);
                            Lexema = "";
                            estado = 0;
                        }

                        break;

                }

                columna++;

            }

            Mandar_Lista();

        }


        public void Palabra_Reservada(String Lexema)
        {
            String Palabra;
            Palabra = Lexema;

            if (Palabra.Equals("CONJ"))
            {
                Aceptar("Palabra Reservada", Lexema, fila, columna, 1);
            }
            else
            {
                Aceptar("Identificador", Lexema, fila, columna, 5);
            }
        }

        public void Mandar_Lista()
        {
            Form1 mandar = new Form1();
            mandar.traer(Lista_Aceptacion, Lista_Error);

        }


    }
}
