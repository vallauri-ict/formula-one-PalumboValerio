using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Circuit
    {
        public Circuit(string circuitRef, string circuitName, string circuitLocation, 
                       string circuitCountry)
        {
            this.circuitRef = circuitRef;
            this.circuitName = circuitName;
            this.circuitLocation = circuitLocation;
            this.circuitCountry = circuitCountry;
        }

        public string circuitRef { get; set; }
        public string circuitName { get; set; }
        public string circuitLocation { get; set; }
        public string circuitCountry { get; set; }
    }
}
