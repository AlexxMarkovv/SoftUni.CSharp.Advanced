using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get { return Multiprocessor.Count; }
        }

        public List<CPU> Multiprocessor
        {
            get { return  multiprocessor; }
            set { multiprocessor = value; }
        }


        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            bool isExist = false;
            if (Multiprocessor.Count > 0)
            for (int i = 0; i < Multiprocessor.Count; i++)
            {
                if (Multiprocessor[i].Brand == brand)
                {
                    isExist = true;
                    Multiprocessor.RemoveAt(i);
                }
            }

            return isExist;
        }

        public CPU MostPowerful()
        {
            CPU cpu = null;

            double highestFreq = int.MinValue;

            if (Multiprocessor.Count == 0)
            {
                return null;
            }

            foreach (var item in Multiprocessor)
            {
                if (item.Frequency > highestFreq)
                {
                    highestFreq = item.Frequency;
                    cpu = item;
                }
            }

            return cpu;
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var item in Multiprocessor)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
