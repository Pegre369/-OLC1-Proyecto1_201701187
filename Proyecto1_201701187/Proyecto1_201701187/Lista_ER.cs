using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Lista_ER
    {

        private String etiqueta;
        private String descripcion;

        public Lista_ER(String etiqueta, String descripcion)
        {
            this.etiqueta = etiqueta;
            this.descripcion = descripcion;
        }

        public String getEtiqueta()
        {
            return etiqueta;
        }

        public void setEtiqueta(String etiqueta)
        {
            this.etiqueta = etiqueta;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }






    }
}
