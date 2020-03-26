using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
   public class AFD
    {

        public Estado begin;
        public Estado final;
        public Lista_ER symbol;

        public AFD(Estado ini, Estado fin, Lista_ER sim)
        {
            begin = ini;
            final = fin;
            symbol = sim;

        }

        public String Description_graphviz(int i)
        {
            if (i==0)
            {
                return "inicio ->" + begin.Name_Char + " [label= \"Inicio\"];\n"+begin.Name_Char + "->" + final.Name_Char + " [label=\"" + symbol.getEtiqueta() + "\"];\n";

            }
            else
            {
                return begin.Name_Char + "->" + final.Name_Char + " [label=\"" + symbol.getEtiqueta() + "\"];\n";
            }
            
        }


    }
}
