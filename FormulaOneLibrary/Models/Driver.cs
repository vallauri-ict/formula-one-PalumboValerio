using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Driver
    {
        public Driver(int driverCode, string team, string country, string driverFirstname, string driverLastname, 
                      DateTime driverDateOfBirth, string driverPlaceOfBirth)
        {
            this.driverCode = driverCode;
            this.team = team;
            this.country = country;
            this.driverFirstname = driverFirstname;
            this.driverLastname = driverLastname;
            this.driverDateOfBirth = driverDateOfBirth;
            this.driverPlaceOfBirth = driverPlaceOfBirth;
        }

        public int driverCode { get; set; }
        public string team { get; set; }
        public string country { get; set; }
        public string driverFirstname { get; set; }
        public string driverLastname { get; set; }
        public DateTime driverDateOfBirth { get; set; }
        public string driverPlaceOfBirth { get; set; }
    }
}
