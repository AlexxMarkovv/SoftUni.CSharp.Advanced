using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        public string model;
        public double fuelAmount;
        public double fuelConsumptionFor1Km;
        public double travelledDistance;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionFor1Km
        {
            get { return fuelConsumptionFor1Km; }
            set { fuelConsumptionFor1Km = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(double distance)
        {
            if (distance * FuelConsumptionFor1Km > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= distance * fuelConsumptionFor1Km;
                TravelledDistance += distance;
            }
        }
    }
}
