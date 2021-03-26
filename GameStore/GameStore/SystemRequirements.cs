using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameStore
{
    [Serializable]
    class SystemRequirements
    {
        public string OS { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }
        public int FreeMemory { get; set; }

        public SystemRequirements() { }
        public SystemRequirements(string os, string processor, int ram, int memory)
        {
            OS = os;
            Processor = processor;
            RAM = ram;
            FreeMemory = memory;
        }
    }
}
