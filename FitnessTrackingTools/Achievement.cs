using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingTools
{
    public class Achievement
    {
        public double progress { get; set; }
        public double goal { get; set; }

        public Achievement (double goal)
        { 
            this.goal = goal;
            progress = 0;
        }

        public double getProgress()
        {
            return progress;
        }

        public double getProgressPercent()
        {
            return progress / goal;
        }

        public string getMedal()
        {
            double prog = getProgressPercent() * 100;

            if (prog < 10) return "None";
            else if (prog >= 10 && prog < 20) return "Iron";
            else if (prog >= 20 && prog < 40) return "Bronze";
            else if (prog >= 40 && prog < 60) return "Silver";
            else if (prog >= 60 && prog < 100) return "Gold";
            else if (prog >= 100) return "Platinum";

            else return "error";
        }

        public void incrementProgress(double val)
        {
            progress += val;
        }
    }
}
