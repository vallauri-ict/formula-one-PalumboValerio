using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Driver
    {
        public Driver(string country, string team, int driverNumber, string driverFirstname, string driverLastname, 
                      DateTime driverDateOfBirth, string driverPlaceOfBirth)
        {
            this.country = country;
            this.team = team;
            this.driverNumber = driverNumber;
            this.driverFirstname = driverFirstname;
            this.driverLastname = driverLastname;
            this.driverDateOfBirth = driverDateOfBirth;
            this.driverPlaceOfBirth = driverPlaceOfBirth;
        }

        public string country { get; set; }
        public string team { get; set; }
        public int driverNumber { get; set; }
        public string driverFirstname { get; set; }
        public string driverLastname { get; set; }
        public DateTime driverDateOfBirth { get; set; }
        public string driverPlaceOfBirth { get; set; }
    }
}
