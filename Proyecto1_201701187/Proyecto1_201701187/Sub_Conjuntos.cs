using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Sub_Conjuntos
    {
        List<Lista_ER> alfabet;
        int initial;
        Estado afdInitial;
        List<Trancision> states = new List<Trancision>();
        Stack<Trancision> pending_states = new Stack<Trancision>();
        List<Estado> Table_States = new List<Estado>();
        Queue<Estado> AFD_pendent = new Queue<Estado>();
        public List<AFD> Description_AFD = new List<AFD>();
        public string [,] table_matriz;
        public int fila;
        public int columna;
        Automata automaton;

        public Sub_Conjuntos(Automata a, string name, string nametabla)
        {
            alfabet = a.Alfabet;
            Adaptation_States(a);
            initial = a.Initial.Identifier;
            afdInitial = a.Initial;
            automaton = a;
            Calculation();
            graph(name);
            table();
            ShowAlfabet(alfabet,nametabla);
            
        }

        private void Adaptation_States(Automata a)
        {
            foreach (Estado sta in a.States)
            {
                List<Trancision> transition = sta.Transitions;
                foreach (Trancision trans in transition)
                {
                    states.Add(trans);
                }

            }
        }

        private void Calculation()
        {

            Clench(null, initial, new Lista_ER( "ε", "Epsilon"), 1);

            while (AFD_pendent.Count > 0)
            {
                for (int i = 0; i < alfabet.Count; i++)
                {
                    Estado Temporary_state = Move(AFD_pendent.Peek(), alfabet.ElementAt(i));

                    if (Temporary_state.key.Count > 0)
                    {
                        if (Previous_State(Temporary_state) == false)
                        {
                            Estado result = null;

                            for (int j = 0; j < Temporary_state.inserted.Count; j++)
                            {
                                result = Clench(Temporary_state, Temporary_state.inserted.ElementAt(j), new Lista_ER("ε", "Epsilon"), Temporary_state.Identifier);
                            }
                            if (result != null)
                            {
                               
                                result.Identifier = Table_States.Count + 1;
                                Table_States.Add(result);
                                Is_Final(result);
                                Description_AFD.Add(new AFD(AFD_pendent.Peek(), result, alfabet.ElementAt(i)));
                            }
                        }
                        else
                        {
                            Description_AFD.Add(new AFD(AFD_pendent.Peek(), Previous_Name(Temporary_state), alfabet.ElementAt(i)));
                        }
                    }
                }
                AFD_pendent.Dequeue();
            }
        }

        private Estado Previous_Name(Estado Actual_State)
        {
        for (int i = 0; i < Table_States.Count; i++)
            {
                if (Same(Table_States.ElementAt(i).key, Actual_State.key))
                {
                    return Table_States.ElementAt(i);
                }
            }
            return null;
        }
        
        private bool Previous_State(Estado Actual_State)
        {
            bool exist = false;
            for (int i = 0; i < Table_States.Count; i++)
            {
                if (Same(Table_States.ElementAt(i).key, Actual_State.key))
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }

        private bool Same(List<int> x, List<int> y)
        {
            bool result = false;
            int sum = 0;
            if (x.Count == y.Count)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (x.ElementAt(i) == y.ElementAt(i))
                    {
                        sum++;
                    }
                }
                if (sum ==y.Count)
                {
                    result = true;
                }
            }
            return result;
        }

        private Estado Move(Estado state, Lista_ER symbol)
        {
            Estado temporary = new Estado(Table_States.Count + 1);
            for (int i = 0; i < state.inserted.Count; i++)
            {
                for (int j = 0; j < states.Count; j++)
                {
                    if (state.inserted.ElementAt(i) == states.ElementAt(j).Begin.Identifier)
                    {
                        if (states.ElementAt(j).Symbol.getDescripcion().Equals(symbol.getDescripcion()) && states.ElementAt(j).Symbol.getEtiqueta().Equals(symbol.getEtiqueta()))
                        {
                            if (!temporary.inserted.Contains(states.ElementAt(j).End.Identifier))
                            {
                                temporary.inserted.Add(states.ElementAt(j).End.Identifier);
                                temporary.key.Add(states.ElementAt(j).End.Identifier);
                            }
                        }
                    }
                }
            }
            temporary.key.Sort();
            return temporary;
        }

        private void Is_Final(Estado State)
        {
            State.final = false;
            for (int i = 0; i < State.inserted.Count; i++)
            {
                if (automaton.Acceptance.Any(u => u.Identifier == (State.inserted.ElementAt(i))))
                {
                    State.final = true;
                }
            }
        }

        private Estado Clench(Estado Actual_state, int begin, Lista_ER symbol, int Name)
        {
            Estado estado;
            if (Actual_state == null)
            {
                estado = new Estado(Name);
                estado.inserted.Add(begin);
                estado.key.Add(begin);
                Table_States.Add(estado);
            }
            else
            {
                estado = Actual_state;
                if (!estado.inserted.Contains(begin))
                {
                    estado.inserted.Add(begin);
                }
            }

            for (int i = 0; i < states.Count; i++)
            {
                if (states.ElementAt(i).Begin.Identifier == begin)
                {
                    //Quizas lleve otra condicion
                    if (states.ElementAt(i).Symbol.getDescripcion().Equals(symbol.getDescripcion()) && states.ElementAt(i).Symbol.getEtiqueta().Equals(symbol.getEtiqueta()))
                    {
                        if (!pending_states.Contains(states.ElementAt(i)))
                        {
                            pending_states.Push(states.ElementAt(i));
                        }
                    }
                }
            }
            while (pending_states.Count > 0)
            {
                Clench(estado, pending_states.Pop().End.Identifier, symbol, estado.Identifier);
            }
            if (!AFD_pendent.Contains(estado))
            {
                AFD_pendent.Enqueue(estado);
            }
            return estado;
        }

        public void graph(string name)
        {
            
            string text = "digraph " + name + " {\n";
            text += "\trankdir=LR;" + "\n";

            text += "\tgraph [label=\"" + name + "\", labelloc=t, fontsize=18]; \n";
            text += "\tnode [style = filled];";
            text += "\tnode [shape=point];inicio;";
            text += "\n";
            text += "\tnode [shape=circle];" + "\n";
           
            for (int i = 0; i < Description_AFD.Count; i++)
            {
                text += "\n";
                text += "\t";
                text += Description_AFD.ElementAt(i).Description_graphviz(i);
            }

            for (int i = 0; i < Table_States.Count; i++)
            {
                if (Table_States.ElementAt(i).final == true)
                {
                    text += "\n";
                    text += "\t";
                    text += Table_States.ElementAt(i).Name_Char + "[shape=doublecircle];";
                }
            }

            text += "\n }";
            Graficar_AFN g = new Graficar_AFN();
            g.graficar(text, name);

        }

        public void ShowAlfabet(List<Lista_ER> alfabet, string name)
        {
            string text = "digraph H {\n" +
            "aHtmlTable [\n shape = plaintext\n" +
            "label =<\n" +
            "<table border = '0' cellborder = '1' color = 'blue' cellspacing = '0'>\n";
             
             for (int f= 0; f<fila; f++)
             {
                text += "<tr>";
                for (int c = 0; c < columna; c++)
                {
                    text += "<td>" + table_matriz[f,c] + "</td>";
                }
                text += "</tr>\n";
            }
           
            text += "</table>\n" +
                 ">];\n"+
                 "}";

             //Console.WriteLine(text);
             Graficar_AFN g = new Graficar_AFN();
             g.graficar(text, name);

            

        }

        public void table()
        {
          
            int apuntador = 0;

            columna = alfabet.Count + 1 ;
            fila = Table_States.Count+1;

            table_matriz = new string[fila,columna];

            table_matriz[0, 0] = " ";

            for (int i = 1; i <columna ; i++)
            {
                table_matriz[0, i] = alfabet.ElementAt(apuntador).getEtiqueta();
                apuntador++;
            }

            apuntador = 0;

            for (int i = 1; i<fila; i++)
            {
                table_matriz[i, 0] = Table_States.ElementAt(apuntador).Name_Char;
                apuntador++;
            }

            int titu=0;
            

            for (int i = 0; i < columna; i++)
            {
                if (table_matriz[0,i].Equals(Description_AFD.ElementAt(titu).symbol.getEtiqueta()))
                {
                    titu = 0;

                    for (int j = 0; j < fila; j++)
                    {
                        if (titu == Description_AFD.Count)
                        {
                            titu = 0;
                            break;
                        }else
                        {
                            if (table_matriz[0, i].Equals(Description_AFD.ElementAt(titu).symbol.getEtiqueta()))
                            {
                                if (table_matriz[j, 0].Equals(Description_AFD.ElementAt(titu).begin.Name_Char))
                                {
                                    Console.WriteLine("si jalo");
                                    table_matriz[j, i] = Description_AFD.ElementAt(titu).final.Name_Char;
                                    titu++;
                                }
                                else
                                {
                                    if (table_matriz[j, 0] == " ")
                                    {

                                    }
                                }
                            }
                            else
                            {
                                if (table_matriz[j, 0] == " ")
                                {

                                }
                                else
                                {
                                    titu++;
                                    j--;
                                }
                            }
                        }
                        
                    }

                    titu = 0;

                 } else
                {
                    if (table_matriz[0, i] == " ")
                    {

                    }
                    else
                    {
                        titu++;
                        i--;
                    }
                }
                


              }


            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columna; j++)
                {
                    Console.Write(table_matriz[i,j]);
                }
                Console.WriteLine();
            }


            }



        }

        
    }



