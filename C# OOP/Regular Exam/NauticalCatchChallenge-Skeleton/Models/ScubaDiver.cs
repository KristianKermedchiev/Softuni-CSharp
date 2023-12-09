using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        public ScubaDiver(string name) : base(name, 540)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double oxygenDecrease = 0.3 * TimeToCatch;
            int roundedOxygenDecrease = (int)Math.Round(oxygenDecrease, MidpointRounding.AwayFromZero);

            OxygenLevel = roundedOxygenDecrease;
        }

        public override void RenewOxy()
        {
            OxygenLevel = 540;
        }
    }
}
