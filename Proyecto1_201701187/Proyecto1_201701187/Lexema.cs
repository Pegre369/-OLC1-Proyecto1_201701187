using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Lexema
    {

        private String nameEr;
        private String chain;

        public Lexema(string nameEr, string chain)
        {
            this.nameEr = nameEr;
            this.chain = chain;
        }

        public string NameEr
        {
            get
            {
                return nameEr;
            }

            set
            {
                nameEr = value;
            }
        }

        public string Chain
        {
            get
            {
                return chain;
            }

            set
            {
                chain = value;
            }
        }
    }
}
