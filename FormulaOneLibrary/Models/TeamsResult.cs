using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class TeamsResult
    {
        public TeamsResult(int teamResultsCode, int teamCode, int raceCode, int points)
        {
            this.teamResultsCode = teamResultsCode;
            this.raceCode = raceCode;
            this.teamCode = teamCode;
            this.points = points;
        }

        public int teamResultsCode { get; set; }
        public int raceCode { get; set; }
        public int teamCode { get; set; }
        public int points { get; set; }
    }
}
