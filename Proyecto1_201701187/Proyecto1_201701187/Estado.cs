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
        private int name_state;
        private List<Estado> state;
        public List<int> inserted = new List<int>();
        public List<int> key = new List<int>();
        public bool final;



        public Estado(int identifier)
        {
            Identifier = identifier;
            Transitions = new List<Trancision>();
        }

        public void AFDState(int id)
        {
            Name_state = id;
            State = new List<Estado>();
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

        //AFD
        public List<Estado> State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public int Name_state
        {
            get
            {
                return name_state;
            }

            set
            {
                name_state = value;
            }
        }

        public string Name_Char
        {
            get
            {
                return ((char)(Name_state + 64)).ToString();
            }
        }

    }
}
