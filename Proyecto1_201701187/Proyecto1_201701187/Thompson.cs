using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Thompson
    {
        int i = 0;
        List<Lista_ER> er;
        String name_file; 
        Automata root;
        Sub_Conjuntos deterministas;
        public Thompson(List<Lista_ER>er, String name)
        {

            this.er = er;
            this.name_file = name;
            Root = create();
            this.Root.creation_alphabet(er);
            Root.graph(Name_file);

            Sub_Conjuntos s = new Sub_Conjuntos(Root);
            this.Deterministas = s;

        }

        public string Name_file
        {
            get
            {
                return name_file;
            }

            set
            {
                name_file = value;
            }
        }

        public Automata Root
        {
            get
            {
                return root;
            }

            set
            {
                root = value;
            }
        }

        public Sub_Conjuntos Deterministas
        {
            get
            {
                return deterministas;
            }

            set
            {
                deterministas = value;
            }
        }

        public Automata create()
        {
            switch (er.ElementAt(i).getDescripcion())
            {

                case "Concatenacion": 
                    i++;
                    Automata section1_Conca = create(); 
                    Automata section2_Conca = create();
                    Automata resultadoConcat = concatenacion(section2_Conca, section1_Conca);
                    return resultadoConcat;
                    break;
                case "Or":
                    i++;
                    Automata section1_Or = create();
                    Automata section2_Or = create(); 
                    Automata resultado = Positiva(section1_Or, section2_Or);
                    return resultado;
                    break;
                case "kleen": 
                    i++;
                    Automata section_Kleen = create();
                    Automata resultadoK = Kleen(section_Kleen);
                    return resultadoK;
                    break;
                case "positiva":
                    i++;
                    Automata section_plus = create(); 
                    Automata section_plus_Kleen = Kleen(section_plus); 
                    Automata answer_plus = concatenacion(section_plus_Kleen, section_plus); 
                    return answer_plus;
                    break;
                case "aparicion": 
                    i++;
                    Automata section_appearance = create();
                    Automata section_epsilon = afnSimple(new Lista_ER("ε", "Epsilon")); 
                    Automata answer_appearance = Positiva(section_appearance, section_epsilon); 
                    return answer_appearance;
                    break;
                case "cadena":
                    Automata section_Cadena = afnSimple(er.ElementAt(i));
                    return section_Cadena;
                    break;
                case "identificador":
                    Automata section_Id = afnSimple(er.ElementAt(i));
                    return section_Id;
                    break;
          
            }

            return null;
        }

        public Automata Kleen(Automata automataFN)
        {
            Automata afn_kleene = new Automata();

            Estado new_begin = new Estado(0);
            afn_kleene.States.Add(new_begin);
            afn_kleene.Initial = new_begin;

            for (int i = 0; i < automataFN.States.Count; i++)
            {
                Estado temporal = (Estado)automataFN.States.ElementAt(i);
                temporal.Identifier = i + 1;
                afn_kleene.States.Add(temporal);
            }

            Estado New_end = new Estado(automataFN.States.Count + 1);
            afn_kleene.States.Add(New_end);
            afn_kleene.Acceptance.Add(New_end);

            Estado previous_begin = automataFN.Initial;

            List<Estado> previous_End = automataFN.Acceptance;
            
            new_begin.Transitions.Add(new Trancision(new_begin, previous_begin, new Lista_ER("ε", "Epsilon")));
            new_begin.Transitions.Add(new Trancision(new_begin, New_end, new Lista_ER("ε", "Epsilon")));

            for (int i = 0; i < previous_End.Count; i++)
            {
                previous_End.ElementAt(i).Transitions.Add(new Trancision(previous_End.ElementAt(i), previous_begin, new Lista_ER("ε", "Epsilon")));
                previous_End.ElementAt(i).Transitions.Add(new Trancision(previous_End.ElementAt(i), New_end, new Lista_ER("ε", "Epsilon")));
            }
            afn_kleene.Alfabet = automataFN.Alfabet;
            afn_kleene.Lenguage_R = automataFN.Lenguage_R;
            return afn_kleene;
        }

        public Automata concatenacion(Automata AFN1, Automata AFN2)
        {

            Automata afn_concat = new Automata();
            int i = 0;

            for (i = 0; i < AFN2.States.Count; i++)
            {
                Estado temporal = (Estado)AFN2.States.ElementAt(i);
                temporal.Identifier = i;
               
                if (i == 0)
                {
                    afn_concat.Initial = temporal;
                }
                
                if (i == AFN2.States.Count - 1)
                {
                    for (int k = 0; k < AFN2.Acceptance.Count; k++)
                    {
                        temporal.Transitions.Add(new Trancision((Estado)AFN2.Acceptance.ElementAt(k), AFN1.Initial, new Lista_ER("ε", "Epsilon")));
                    }
                }
                afn_concat.States.Add(temporal);

            }

            for (int j = 0; j < AFN1.States.Count; j++)
            {
                Estado temporal = (Estado)AFN1.States.ElementAt(j);
                temporal.Identifier = i;

                if (AFN1.States.Count - 1 == j)
                    afn_concat.Acceptance.Add(temporal);
                afn_concat.States.Add(temporal);
                i++;
            }

            List<Lista_ER> alfabet = new List<Lista_ER>();
            foreach (Lista_ER ers in AFN1.Alfabet)
            {
                alfabet.Add(ers);
            }
            foreach (Lista_ER ers in AFN2.Alfabet)
            {
                alfabet.Add(ers);
            }
            afn_concat.Alfabet = alfabet;
            afn_concat.Lenguage_R = AFN1.Lenguage_R + " " + AFN2.Lenguage_R;

            return afn_concat;
        }

        public Automata Positiva(Automata AFN1, Automata AFN2)
        {
            Automata afn_positiva = new Automata();
            Estado New_begin = new Estado(0);

            New_begin.Transitions.Add(new Trancision(New_begin, AFN2.Initial, new Lista_ER("ε", "Epsilon")));

            afn_positiva.States.Add(New_begin);
            afn_positiva.Initial = New_begin;
            int i = 0;

            for (i = 0; i < AFN1.States.Count; i++)
            {
                Estado temporal = (Estado)AFN1.States.ElementAt(i);
                temporal.Identifier = (i + 1);
                afn_positiva.States.Add(temporal);
            }

            for (int j = 0; j < AFN2.States.Count; j++)
            {
                Estado temporal = (Estado)AFN2.States.ElementAt(j);
                temporal.Identifier = (i + 1);
                afn_positiva.States.Add(temporal);
                i++;
            }

            Estado New_end = new Estado(AFN1.States.Count + AFN2.States.Count + 1);
            afn_positiva.States.Add(New_end);
            afn_positiva.Acceptance.Add(New_end);

            Estado anteriorInicio = AFN1.Initial;
            List<Estado> anteriorFin = AFN1.Acceptance;
            List<Estado> anteriorFin2 = AFN2.Acceptance;

            // agregar transiciones desde el nuevo estado inicial
            New_begin.Transitions.Add(new Trancision(New_begin, anteriorInicio, new Lista_ER("ε", "Epsilon")));

            // agregar transiciones desde el anterior AFN 1 al estado final
            for (int k = 0; k < anteriorFin.Count; k++)
                anteriorFin.ElementAt(k).Transitions.Add(new Trancision(anteriorFin.ElementAt(k), New_end, new Lista_ER("ε", "Epsilon")));
            // agregar transiciones desde el anterior AFN 2 al estado final
            for (int k = 0; k < anteriorFin.Count; k++)
                anteriorFin2.ElementAt(k).Transitions.Add(new Trancision(anteriorFin2.ElementAt(k), New_end, new Lista_ER("ε", "Epsilon")));

            List<Lista_ER> alfabeto = new List<Lista_ER>();
            foreach (Lista_ER ers in AFN1.Alfabet)
            {
                alfabeto.Add(ers);
            }

            foreach (Lista_ER ers in AFN2.Alfabet)
            {
                alfabeto.Add(ers);
            }
            afn_positiva.Alfabet = alfabeto;
            afn_positiva.Lenguage_R = AFN1.Lenguage_R + " " + AFN2.Lenguage_R;
            afn_positiva.Lenguage_R = AFN1.Lenguage_R + " " + AFN2.Lenguage_R;
            return afn_positiva;
        }

        public Automata afnSimple(Lista_ER simboloRegex)
        {
            Automata automataFN = new Automata();
            Estado begin = new Estado(0);
            Estado aceptacion = new Estado(1);
            Trancision transition = new Trancision(begin, aceptacion, simboloRegex);
            begin.Transitions.Add(transition);
            automataFN.States.Add(begin);
            automataFN.States.Add(aceptacion);
            automataFN.Initial = begin;
            automataFN.Acceptance.Add(aceptacion);
            automataFN.Lenguage_R = simboloRegex.getEtiqueta() + "";
            i++;
            return automataFN;

        }









    }
}
