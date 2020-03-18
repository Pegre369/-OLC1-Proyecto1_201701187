using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Automata
    {
        private Estado inicial;
        private List<Estado> aceptacion;
        private List<Estado> estados;
        private HashSet<Lista_ER> alfabeto;
        private String[] resultadoregex;
        private String LenguajeR;

        public Automata()
        {
            Estados = new List<Estado>();
            aceptacion = new List<Estado>();
            Alfabeto = new HashSet<Lista_ER>();
            Resultadoregex = new string[3];
        }

        public Estado Inicial
        {
            get
            {
                return inicial;
            }

            set
            {
                inicial = value;
            }
        }

        public List<Estado> Aceptacion
        {
            get
            {
                return aceptacion;
            }

            set
            {
                aceptacion = value;
            }
        }

        public List<Estado> Estados
        {
            get
            {
                return estados;
            }

            set
            {
                estados = value;
            }
        }

        public HashSet<Lista_ER> Alfabeto
        {
            get
            {
                return alfabeto;
            }

            set
            {
                alfabeto = value;
            }
        }

        public string[] Resultadoregex
        {
            get
            {
                return resultadoregex;
            }

            set
            {
                resultadoregex = value;
            }
        }

        public string LenguajeR1
        {
            get
            {
                return LenguajeR;
            }

            set
            {
                LenguajeR = value;
            }
        }


        public void creacion_alfabeto(List<Lista_ER>descripcion)
        {
            foreach (Lista_ER des in descripcion)
            {

                if (des.getDescripcion().Equals("cadena")|| des.getDescripcion().Equals("identificador"))
                {
                    Alfabeto.Add(des);
                }

            }
        }

        public void graficar(string name)
        {
            string texto = "digraph " + name + " {\n";
            texto += "\trankdir=LR;" + "\n";

            texto += "\tgraph [label=\"" + name + "\", labelloc=t, fontsize=20]; \n";
            texto += "\tnode [style = filled,color = mediumseagreen];";

            foreach (Estado e in this.Estados)
            {
                texto += " " + e.Identifier;
            }

            texto += ";" + "\n";
            texto += "\tnode [shape=circle];" + "\n";
            texto += "\tnode [color=midnightblue,fontcolor=white];\n" + "	edge [color=red];" + "\n";

            texto += "\tsecret_node [style=invis];\n" + "	secret_node -> " + this.Inicial.Identifier + " [label=\"inicio\"];" + "\n";
            List<string> duplicados = new List<string>();
            List<Estado> FiltroEstados = new List<Estado>();
            List<Trancision> FiltroTancisiones = new List<Trancision>();
            Trancision transicion = new Trancision();

            foreach (Estado e in this.Estados)
            {
                Estado ee = e;
                List<Trancision> trancisiones = e.Transitions;

                foreach (Trancision t in trancisiones)
                {

                    if (duplicados.Find(x=>x.Equals(t.Begin.Identifier + " -> " + t.End.Identifier + " [label=\"" + t.Symbol.getDescripcion() + "\"];"))==null)
                    {
                        transicion = t;
                        FiltroTancisiones.Add(t);
                        duplicados.Add(t.Begin.Identifier + " -> " + t.End.Identifier + " [label=\"" + t.Symbol.getDescripcion() + "\"];");
                        texto += "\t" + t.Begin.Identifier + " -> " + t.End.Identifier + " [label=\"" + t.Symbol.getDescripcion() + "\"];" + "\n";

                    }

                }

                ee.Transitions = FiltroTancisiones;
                FiltroEstados.Add(ee);
                FiltroTancisiones = new List<Trancision>();


            }

            texto += transicion.End.Identifier + "[shape=doublecircle]";
            texto += "}";
            this.Estados = FiltroEstados;

            Graficar_AFN niu = new Graficar_AFN();
            niu.graficar(texto, name); 

        }


    }
}
