using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Trancision
    {

        private Estado begin;
        private Estado end;
        private Lista_ER symbol;

        public Trancision()
        {

        }
        public Trancision(Estado begin, Estado end, Lista_ER symbol)
        {
            Begin = begin;
            End = end;
            Symbol = symbol;
        }

        public Estado Begin
        {
            get
            {
                return begin;
            }

            set
            {
                begin = value;
            }
        }

        public Estado End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        public Lista_ER Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
            }
        }

        
    }
}
