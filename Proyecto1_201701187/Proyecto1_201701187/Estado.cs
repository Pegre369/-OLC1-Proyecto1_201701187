using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Estado
    {

        private int identifier;
        private List<Trancision> transitions;

        public Estado(int identifier)
        {
            Identifier = identifier;
            Transitions = new List<Trancision>();
        }

        public int Identifier
        {
            get
            {
                return identifier;
            }

            set
            {
                identifier = value;
            }
        }

        public List<Trancision> Transitions
        {
            get
            {
                return transitions;
            }

            set
            {
                transitions = value;
            }
        }
    }
}
