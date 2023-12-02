using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            bool isRemoved = false;

            for (int i = 0; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].VIN == vin)
                {
                    Vehicles.RemoveAt(i);
                    isRemoved = true;
                }
            }
            return isRemoved;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            Vehicle vehicle = null;
            int lowestMileage = int.MaxValue;

            foreach (Vehicle v in Vehicles)
            {
                if (v.Mileage < lowestMileage)
                {
                    lowestMileage = v.Mileage;
                    vehicle = v;
                }
            }

            return vehicle;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
