using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Nodo
    {
        public String etiquetas;
        public Nodo derecha;
        public Nodo izquierda;
        public String descripcion;


        public Nodo(String nombre, String descrip)
        {

            this.etiquetas = nombre;
            this.descripcion = descrip;
            this.derecha = null;
            this.izquierda = null;
        }

        public String getEtiquetas()
        {
            return etiquetas;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

    }
}
