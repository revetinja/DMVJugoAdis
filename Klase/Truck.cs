using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMWGUI_AJ
{
    class Truck : MotorVehicle
    {
        private double maxWeight;
        public Truck(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, double maxWeight)
            : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.maxWeight = maxWeight;
        }

        string show()
        {
            return "Truck " + "make and model " + fieldSeparator + " and has max. weight of" + maxWeight + recordSeparator;
        }

    }
}
