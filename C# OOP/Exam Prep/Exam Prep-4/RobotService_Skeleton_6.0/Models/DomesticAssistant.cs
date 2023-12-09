using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        public DomesticAssistant(string model) 
            : base(2000, model, 20000)
        {

        }
    }
}
