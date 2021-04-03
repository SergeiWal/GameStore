using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameStore
{
    [Serializable]
    public class SystemRequirements
    {
        public string OS { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }
        public int FreeMemory { get; set; }

        public SystemRequirements() { }
    }
}
