﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilities.Models
{
    public class Stats
    {
        public Stats(string driver, int totPoints, decimal averagePoints, int nFastestLap, 
                     int nFirstPlace, int nSecondPlace, int nThirdPlace, int nPodius)
        {
            this.driver = driver;
            this.totPoints = totPoints;
            this.averagePoints = averagePoints;
            this.nFastestLap = nFastestLap;
            this.nFirstPlace = nFirstPlace;
            this.nSecondPlace = nSecondPlace;
            this.nThirdPlace = nThirdPlace;
            this.nPodius = nPodius;
        }

        public string driver { get; set; }
        public int totPoints { get; set; }
        public decimal averagePoints { get; set; }
        public int nFastestLap { get; set; }
        public int nFirstPlace { get; set; }
        public int nSecondPlace { get; set; }
        public int nThirdPlace { get; set; }
        public int nPodius { get; set; }
    }
}
