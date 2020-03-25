using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201701187
{
    public class Estado
    {
        //AFN
        private int identifier;
        private List<Trancision> transitions;

        //AFD
        public List<int> inserted = new List<int>();
        public List<int> key = new List<int>();
        public bool final;



        public Estado(int identifier)
        {
            Identifier = identifier;
            Transitions = new List<Trancision>();

        }

       

        //AFN
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
        
        public string Name_Char
        {
            get
            {
                return ((char)(Identifier + 64)).ToString();
            }
        }

    }
}
