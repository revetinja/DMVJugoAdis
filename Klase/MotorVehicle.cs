using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMWGUI_AJ
{
    abstract class MotorVehicle
    {
        string VIN;
        string make;
        string model;
        DateTime dateOfProduction; 

        // Date and time, has to be bigger than now
        protected int noOfWheels; 

        // Has to be bigger than 2 and less than 18
        protected int noOfSeats;  

        // Has to be equal or bigger to one

        public MotorVehicle() { }

        // This is integer of number of wheels and integer of number of seats
        public MotorVehicle(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction)  
        {
            this.VIN = VIN;
            this.make = make;
            this.model = model;
            this.noOfSeats = noOfSeats;
            this.noOfWheels = noOfWheels;
            this.dateOfProduction = dateOfProduction;
        }



        // If statement when VIN is valid return true, otherwise it will return false.

        public bool SetVIN(string VIN)
        {
            if (VIN.Length != 17) return false;
            else return true;
        }

        public string show()
        {
            return string.Format("{1,17}{0}{2,15}{0}{3,15}{0}{4:MMddyy}{0}{5,1}{0}{6,2}", " ", VIN, make, model, dateOfProduction, noOfWheels, noOfSeats);
        }

        public const char fieldSeparator = '|';
        public const char recordSeparator = '\n';
        
    }
}
