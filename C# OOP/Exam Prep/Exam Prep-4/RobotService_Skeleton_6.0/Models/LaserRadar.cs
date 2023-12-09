using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int LazerRaderInterfaceStandard = 20_082;
        private const int LazerRaderBatteryUsage = 5_000;
        public LaserRadar() 
            : base(LazerRaderInterfaceStandard, LazerRaderBatteryUsage)
        {

        }
    }
}
