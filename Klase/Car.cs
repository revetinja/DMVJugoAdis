using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMWGUI_AJ
{
    class Car : MotorVehicle
    {
        private string color;
        private bool AC;
        private int airbags;
        //public Car() { }
        public Car(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, string color, bool AC, int airbags) : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.color = color;
            this.AC = AC;
            this.airbags = airbags;
        }
        string show()
        {
            return "Car " + "make and model " + " in " + color + "have AC: " + AC + " and have " + airbags + "airbags";
        }
    }
}
