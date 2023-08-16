using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            this.multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get { return multiprocessor; } set { multiprocessor = value; } }
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpuToRemove = Multiprocessor.FirstOrDefault(c => c.Brand == brand);

            if (cpuToRemove != null)
            {
                Multiprocessor.Remove(cpuToRemove);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerfulCPU = Multiprocessor.OrderByDescending(c => c.Frequency).FirstOrDefault();

            return mostPowerfulCPU;
        }

        public CPU GetCPU(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(c => c.Brand == brand);

            return cpu;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (CPU cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
