using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire tires;
        private int engineIndex;
        private int tiresIndex;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Tire Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public int EngineIndex
        {
            get { return engineIndex; }
            set { engineIndex = value; }
        }

        public int TiresIndex
        {
            get { return tiresIndex; }
            set { tiresIndex = value; }
        }


        public Car()
        {

        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model,
            int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model,
           int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire tires)
           : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public Car(string make, string model,
          int year, double fuelQuantity, double fuelConsumption, int engineIndex, int tiresIndex)
          : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            EngineIndex = engineIndex;
            TiresIndex = tiresIndex;
        }
    }
}
