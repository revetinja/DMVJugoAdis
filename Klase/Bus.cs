using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMWGUI_AJ
{
    class Bus : MotorVehicle
    {
        private string companyName;
        public Bus(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, string companyName) : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.companyName = companyName;
        }
        string show()
        {
            return "Bus " + "make and model " + fieldSeparator + ", from company: " + companyName + recordSeparator;
        }
    }
}
