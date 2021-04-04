using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class LangState
    {
        private static LangState state;
        private static readonly object locker = new object();
        public Languege Languege { get; set; }

        private LangState()
        {
        }
        public static LangState GetState()
        {
            if (state == null)
            {
                lock (locker)
                {
                    if (state == null)
                    {
                        state = new LangState();
                    }
                }
            }
            return state;
        }
    }
}
