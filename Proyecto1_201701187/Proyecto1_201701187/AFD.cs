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
        public String Description()
        {
            return "['" + begin.Name_Char + "' , '" + symbol.getEtiqueta() + "' , '" + final.Name_Char + "']";
        }

        public String Description_graphviz()
        {
            return begin.Name_Char + "->" + final.Name_Char + " [label=\"" + symbol.getEtiqueta() + "\"];\n";
        }


    }
}
