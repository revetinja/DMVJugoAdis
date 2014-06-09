using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMWGUI_AJ
{
    class Taxi : Car
    {
        private bool licence;
        public Taxi(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, string color, bool AC, int airbags, bool licence): base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction, color, AC, airbags)
        {
            this.licence = licence;
        }
        string show()
        {
            return "Taxi " + "make and model " + " and it has license plate: " + licence;
        }
    }
}
