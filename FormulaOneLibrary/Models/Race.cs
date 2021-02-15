using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Race
    {
        public Race(int raceYear, int raceRound, string raceName,
                    DateTime raceDate, string raceTime)
        {
            this.raceYear = raceYear;
            this.raceRound = raceRound;
            this.raceName = raceName;
            this.raceDate = raceDate;
            this.raceTime = raceTime;
        }

        public int raceYear { get; set; }
        public int raceRound { get; set; }
        public string raceName { get; set; }
        public DateTime raceDate { get; set; }
        public string raceTime { get; set; }
    }
}
