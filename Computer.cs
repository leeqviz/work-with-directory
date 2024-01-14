using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWork
{
    [Serializable]
    class Computer
    {
        public string CPU;
        public string RAM;
        public string GPU;
        public string Storage;
        public string Motherboard;

        public Computer()
        {
            CPU = "noData";
            RAM = "noData";
            GPU = "noData";
            Storage = "noData";
            Motherboard = "noData";
        }

        public Computer(string cpu, string ram, string gpu, string storage, string motherboard)
        {
            CPU = cpu;
            RAM = ram;
            GPU = gpu;
            Storage = storage;
            Motherboard = motherboard;
        }

        public void Display()
        {
            Console.WriteLine("[CPU=" + CPU +
                ", RAM=" + RAM +
                ", GPU=" + GPU +
                ", storage=" + Storage +
                ", motherboard=" + Motherboard + "]");
        }
    }
}
