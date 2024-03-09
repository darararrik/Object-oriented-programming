using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal interface IComputer
    {
        enum type_cpu;
        enum name_manufacturer;
        enum type_OS;
        public int frqncy_cpu { get; set; }
        public int ramSize { get; set; }
        public List<string> installed_soft { get; set; }
        public List<string> users { get; set; }
    }
}
