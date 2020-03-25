using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Sub_Conjuntos
    {
        List<Lista_ER> alfabeto;
        int inicial;
        Estado afdInicial;
        //PILAS Y ARREGLOS PARA EL MANEJO DE DATOS
        List<Trancision> estados = new List<Trancision>();
        Stack<Trancision> estados_pendientes = new Stack<Trancision>();
        List<Estado> tablaDeEstados = new List<Estado>();
        Queue<Estado> AFDpendientes = new Queue<Estado>();
        public List<AFD> DescripcionDelAFD = new List<AFD>();
        Automata automata;

        public Sub_Conjuntos(Automata a)
        {
            alfabeto = a.Alfabet;
            AdaptaEstados(a);
            inicial = a.Initial.Identifier;
            afdInicial = a.Initial;
            automata = a;
            Calculo();
            graficar("a");
        }

        private void AdaptaEstados(Automata a)
        {
            foreach (Estado e in a.States)
            {
                List<Trancision> transiciones = e.Transitions;
                foreach (Trancision t in transiciones)
                {
                    estados.Add(t);
                }

            }
        }

        private void Calculo()
        {
            //CERRADURA EPSILON AL ESTADO INICIAL
            Cerradura(null, inicial, new Lista_ER( "ε", "Epsilon"), 1);

            //CALCULAMOS LOS DISTINTOS ESTADOS
            while (AFDpendientes.Count > 0)
            {
                for (int i = 0; i < alfabeto.Count; i++)
                {
                    Estado estadotmp = Mover(AFDpendientes.Peek(), alfabeto.ElementAt(i));

                    //SE VERIFICA QUE EL RESULTADO DE MOVER DIERA UN ESTADO VALIDO (NO POZO)
                    if (estadotmp.key.Count > 0)
                    {
                        //VERIFICA SI EL ESTADO YA EXISTE
                        if (EstadoPrevio(estadotmp) == false)
                        {
                            Estado result = null;

                            //SI LA LLAVE DEL ESTADO NO EXISTE PREVIAMENTE
                            for (int j = 0; j < estadotmp.inserted.Count; j++)
                            {
                                result = Cerradura(estadotmp, estadotmp.inserted.ElementAt(j), new Lista_ER("ε", "Epsilon"), estadotmp.Identifier);
                            }
                            if (result != null)
                            {
                                //SE ASIGNA UN NOMBRE UNICO
                                result.Identifier = tablaDeEstados.Count + 1;

                                //SE AGREGA EL ESTADO A LA TABLA
                                tablaDeEstados.Add(result);

                                //SE GUARDA SI EL ESTADO ES FINAL O NO
                                esFinal(result);

                                //SE AGREGA EL ESTADO A LA DESCRIPCION DE ESTADOS
                                DescripcionDelAFD.Add(new AFD(AFDpendientes.Peek(), result, alfabeto.ElementAt(i)));
                            }
                        }
                        else
                        {
                            //SI LA LLAVE DEL ESTADO YA SE HABIA CALCULADO EN UN ESTADO PREVIO
                            DescripcionDelAFD.Add(new AFD(AFDpendientes.Peek(), NombrePrevio(estadotmp), alfabeto.ElementAt(i)));
                        }
                    }
                }
                AFDpendientes.Dequeue();
            }
        }

        private Estado NombrePrevio(Estado estadoactual)
        {
            //REVISAR IMPLEMENTACCION
            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if (Igual(tablaDeEstados.ElementAt(i).key, estadoactual.key))
                {
                    return tablaDeEstados.ElementAt(i);
                }
            }
            return null;
        }
        
        private bool EstadoPrevio(Estado estadoactual)
        {
            bool existe = false;
            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if (Igual(tablaDeEstados.ElementAt(i).key, estadoactual.key))
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }

        private bool Igual(List<int> a, List<int> b)
        {
            bool res = false;
            int sum = 0;
            if (a.Count == b.Count)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a.ElementAt(i) == b.ElementAt(i))
                    {
                        sum++;
                    }
                }
                if (sum == a.Count)
                {
                    res = true;
                }
            }
            return res;
        }

        private Estado Mover(Estado estado, Lista_ER simbolo)
        {
            Estado temp = new Estado(tablaDeEstados.Count + 1);
            for (int i = 0; i < estado.inserted.Count; i++)
            {
                for (int j = 0; j < estados.Count; j++)
                {
                    if (estado.inserted.ElementAt(i) == estados.ElementAt(j).Begin.Identifier)
                    {
                        if (estados.ElementAt(j).Symbol.getDescripcion().Equals(simbolo.getDescripcion()) && estados.ElementAt(j).Symbol.getEtiqueta().Equals(simbolo.getEtiqueta()))
                        {
                            if (!temp.inserted.Contains(estados.ElementAt(j).End.Identifier))
                            {
                                temp.inserted.Add(estados.ElementAt(j).End.Identifier);
                                temp.key.Add(estados.ElementAt(j).End.Identifier);
                            }
                        }
                    }
                }
            }
            temp.key.Sort();
            return temp;
        }

        private void esFinal(Estado estado)
        {
            estado.final = false;
            for (int i = 0; i < estado.inserted.Count; i++)
            {
                if (automata.Acceptance.Any(u => u.Identifier == (estado.inserted.ElementAt(i))))
                {
                    estado.final = true;
                }
            }
        }

        private Estado Cerradura(Estado estadoactual, int inicio, Lista_ER simbolo, int Nombre)
        {
            Estado estado;
            if (estadoactual == null)
            {
                //CREAR UN NUEVO ESTADO AFD
                estado = new Estado(Nombre);
                estado.inserted.Add(inicio);
                estado.key.Add(inicio);
                tablaDeEstados.Add(estado);
            }
            else
            {
                estado = estadoactual;
                if (!estado.inserted.Contains(inicio))
                {
                    estado.inserted.Add(inicio);
                }
            }

            for (int i = 0; i < estados.Count; i++)
            {
                if (estados.ElementAt(i).Begin.Identifier == inicio)
                {
                    //Quizas lleve otra condicion
                    if (estados.ElementAt(i).Symbol.getDescripcion().Equals(simbolo.getDescripcion()) && estados.ElementAt(i).Symbol.getEtiqueta().Equals(simbolo.getEtiqueta()))
                    {
                        if (!estados_pendientes.Contains(estados.ElementAt(i)))
                        {
                            estados_pendientes.Push(estados.ElementAt(i));
                        }
                    }
                }
            }
            while (estados_pendientes.Count > 0)
            {
                Cerradura(estado, estados_pendientes.Pop().End.Identifier, simbolo, estado.Identifier);
            }
            if (!AFDpendientes.Contains(estado))
            {
                AFDpendientes.Enqueue(estado);
            }
            return estado;
        }


        public String ImprimeFinales()
        {
            String str = "[";
            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if (tablaDeEstados.ElementAt(i).final == true)
                {
                    str = str + "'" + tablaDeEstados.ElementAt(i).Name_Char + "',";
                }
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str + "]";

        }

        //IMPRIME LA DESCRIPCION DEL AFD
    /*    public void ImprimeAFD()
        {
            Console.WriteLine("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            for (int i = 0; i < DescripcionDelAFD.Count; i++)
            {
                System.Windows.Forms.MessageBox.Show(DescripcionDelAFD.ElementAt(i).Description());
                Console.WriteLine(DescripcionDelAFD.ElementAt(i).Description_graphviz());
            }

        }*/

        public void graficar(string nombre)
        {
            nombre = nombre + "AFD";
            string texto = "digraph " + nombre + " {\n";
            texto += "\trankdir=LR;" + "\n";

            texto += "\tgraph [label=\"" + nombre + "\", labelloc=t, fontsize=20]; \n";
            texto += "\tnode [style = filled,color = mediumseagreen];";
            texto += "\tnode [shape=point];inicio;";
            texto += "\n";
            texto += "\tnode [shape=circle];" + "\n";
            texto += "\tnode [color=midnightblue,fontcolor=white];\n" + "	edge [color=red];" + "\n";
           
            for (int i = 0; i < DescripcionDelAFD.Count; i++)
            {
                texto += "\n";
                texto += "\t";
                texto += DescripcionDelAFD.ElementAt(i).Description_graphviz();
            }

            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if (tablaDeEstados.ElementAt(i).final == true)
                {
                    texto += "\n";
                    texto += "\t";
                    texto += tablaDeEstados.ElementAt(i).Name_Char + "[shape=doublecircle];";
                }
            }

            texto += "\n }";
            Graficar_AFN g = new Graficar_AFN();
            g.graficar(texto, nombre);

        }


    }

}

