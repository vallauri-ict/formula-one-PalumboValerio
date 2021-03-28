using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Result
    {
        public Result(string race, string driver, string team, string resultPosition, string resultTime, int resultNlap, int resultPoints, int resultFastestLap, string resultFastestLapTime)
        {
            this.race = race;
            this.driver = driver;
            this.team = team;
            this.resultPosition = resultPosition;
            this.resultTime = resultTime;
            this.resultNlap = resultNlap;
            this.resultPoints = resultPoints;
            this.resultFastestLap = resultFastestLap;
            this.resultFastestLapTime = resultFastestLapTime;
        }

        public string race { get; set; }
        public string driver { get; set; }
        public string team { get; set; }
        public string resultPosition { get; set; }
        public string resultTime { get; set; }
        public int resultNlap { get; set; }
        public int resultPoints { get; set; }
        public int resultFastestLap { get; set; }
        public string resultFastestLapTime { get; set; }
    }
}
