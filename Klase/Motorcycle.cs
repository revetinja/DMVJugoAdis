using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMWGUI_AJ
{
    class Motorcycle : MotorVehicle
    {
        private double ccm;
        public Motorcycle(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, double ccm) : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.ccm = ccm;
        }
        string show()
        {
            return "Motorcycle " + "make and model " + " and has ccm of: " + ccm;
        }
    }
}
