using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Team
    {
        public Team(string teamFullName, string teamBase, string teamChief,
                    string teamPowerUnit, int teamWorldChampionships, 
                    int teamPolePositions)
        {
            this.teamFullName = teamFullName;
            this.teamBase = teamBase;
            this.teamChief = teamChief;
            this.teamPowerUnit = teamPowerUnit;
            this.teamWorldChampionships = teamWorldChampionships;
            this.teamPolePositions = teamPolePositions;
        }

        public string teamFullName { get; set; }
        public string teamBase { get; set; }
        public string teamChief { get; set; }
        public string teamPowerUnit { get; set; }
        public int teamWorldChampionships { get; set; }
        public int teamPolePositions { get; set; }
    }
}
