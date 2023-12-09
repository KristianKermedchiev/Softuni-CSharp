using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        public IndustrialAssistant(string model) 
            : base(5000, model, 40000)
        {

        }
    }
}
