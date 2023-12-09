using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int SpecializedArmInterfaceStandart = 10_045;
        private const int SpecializedArmBatteryUsage = 10_000;
        public SpecializedArm() 
            : base(SpecializedArmInterfaceStandart, SpecializedArmBatteryUsage)
        {

        }
    }
}
