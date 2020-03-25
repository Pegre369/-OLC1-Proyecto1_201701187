using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Automata
    {
        private Estado initial;
        private List<Estado> acceptance;
        private List<Estado> states;
        private List<Lista_ER> alfabet;
        private String[] answer_regex;
        private String lenguage_R;

        public Automata()
        {
            States = new List<Estado>();
            acceptance = new List<Estado>();
            Alfabet = new List<Lista_ER>();
            Answer_regex = new string[3];
        }

        public Estado Initial
        {
            get
            {
                return initial;
            }

            set
            {
                initial = value;
            }
        }

        public List<Estado> Acceptance
        {
            get
            {
                return acceptance;
            }

            set
            {
                acceptance = value;
            }
        }

        public List<Estado> States
        {
            get
            {
                return states;
            }

            set
            {
                states = value;
            }
        }

        public List<Lista_ER> Alfabet
        {
            get
            {
                return alfabet;
            }

            set
            {
                alfabet = value;
            }
        }

        public string[] Answer_regex
        {
            get
            {
                return answer_regex;
            }

            set
            {
                answer_regex = value;
            }
        }

        public string Lenguage_R
        {
            get
            {
                return lenguage_R;
            }

            set
            {
                lenguage_R = value;
            }
        }

        public void creation_alphabet(List<Lista_ER>descripcion)
        {
            foreach (Lista_ER des in descripcion)
            {

                if (des.getDescripcion().Equals("cadena")|| des.getDescripcion().Equals("identificador"))
                {
                    if (!(Alfabet.Any(u=>u.getEtiqueta().Equals(des.getEtiqueta())&&u.getDescripcion().Equals(des.getDescripcion()))))
                    {
                            Alfabet.Add(des);
                    
                    }
                    
                }

            }
        }

        public void graph(string name)
        {
            string texto = "digraph " + name + " {\n";
            texto += "\trankdir=LR;" + "\n";

            texto += "\tgraph [label=\"" + name + "\", labelloc=t, fontsize=18]; \n";
            texto += "\tnode [style = filled];";

            foreach (Estado e in this.States)
            {
                texto += " " + e.Identifier;
            }

            texto += ";" + "\n";
            texto += "\tnode [shape=circle];" + "\n";
            
            texto += "\tnode [shape=point];inicio;\n" + "	inicio -> " + this.Initial.Identifier + " [label=\"inicio\"];" + "\n";
            List<string> duplicados = new List<string>();
            List<Estado> FiltroEstados = new List<Estado>();
            List<Trancision> FiltroTancisiones = new List<Trancision>();
            Trancision transicion = new Trancision();

            foreach (Estado e in this.States)
            {
                Estado ee = e;
                List<Trancision> trancisiones = e.Transitions;

                foreach (Trancision t in trancisiones)
                {

                    if (duplicados.Find(x=>x.Equals(t.Begin.Identifier + " -> " + t.End.Identifier + " [label=\"" + t.Symbol.getEtiqueta() + "\"];"))==null)
                    {
                        transicion = t;
                        FiltroTancisiones.Add(t);
                        duplicados.Add(t.Begin.Identifier + " -> " + t.End.Identifier + " [label=\"" + t.Symbol.getEtiqueta() + "\"];");
                        texto += "\t" + t.Begin.Identifier + " -> " + t.End.Identifier + " [label=\"" + t.Symbol.getEtiqueta() + "\"];" + "\n";

                    }

                }

                //ee.Transitions = FiltroTancisiones;
                FiltroEstados.Add(ee);
                FiltroTancisiones = new List<Trancision>();


            }

            texto += transicion.End.Identifier + "[shape=doublecircle]";
            texto += "}";
           // this.States = FiltroEstados;

            Graficar_AFN niu = new Graficar_AFN();
            niu.graficar(texto, name); 

        }


    }
}
