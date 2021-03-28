using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class TeamsResult
    {
        public TeamsResult(string team, string race, int points)
        {
            this.race = race;
            this.team = team;
            this.points = points;
        }

        public string race { get; set; }
        public string team { get; set; }
        public int points { get; set; }
    }
}
