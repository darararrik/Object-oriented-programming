using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal interface IComputer
    {
        enum TypeCpu;
        enum Mnfctrr;
        enum TypeOs;
        public int FrqncyCpu { get; set; }
        public int RamSize { get; set; }
        public List<string> InstalledSoft { get; set; }
        public List<string> Users { get; set; }
    }
}
