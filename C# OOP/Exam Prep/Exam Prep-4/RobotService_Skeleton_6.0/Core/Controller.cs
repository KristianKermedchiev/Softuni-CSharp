using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {

        IRepository<ISupplement> supplements;
        IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository(); 
        }

        public string CreateRobot(string model, string typeName)
        {
            if(typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return $"Robot type {typeName} cannot be created.";
            }

            if (typeName == "DomesticAssistant")
            {
                robots.AddNew(new DomesticAssistant(model));
            }
            else if (typeName == "IndustrialAssistant")
            {
                robots.AddNew(new IndustrialAssistant(model));
            }

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return $"{typeName} is not compatible with our robots.";
            }

            ISupplement newSupplement;

            if (typeName == "SpecializedArm")
            {
                newSupplement = new SpecializedArm();
            }
            else if (typeName == "LaserRadar")
            {
                newSupplement = new LaserRadar();
            }
            else
            {
                return $"{typeName} is not a valid supplement type.";
            }

            supplements.AddNew(newSupplement);

            return $"{typeName} is created and added to the SupplementRepository.";
        }


        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> filteredRobots = robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(interfaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!filteredRobots.Any())
            {
                return $"Unable to perform service, {interfaceStandard} not supported!";
            }

            int availablePower = filteredRobots.Sum(r => r.BatteryLevel);

            if (availablePower < totalPowerNeeded)
            {
                // Corrected logic to calculate the remaining power needed
                int remainingPowerNeeded = totalPowerNeeded - availablePower;
                return $"{serviceName} cannot be executed! {remainingPowerNeeded} more power needed.";
            }

            int usedRobotsCount = 0;

            foreach (IRobot robot in filteredRobots)
            {
                usedRobotsCount++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }
            }

            return $"{serviceName} is performed successfully with {usedRobotsCount} robots.";
        }



        public string Report()
        {
            IEnumerable<IRobot> filteredRobots = robots.Models().OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            StringBuilder sb = new();

            foreach (IRobot robot in filteredRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> filteredRobots = robots
                .Models()
                .Where(r => r.Model == model && r.BatteryCapacity / 2 > r.BatteryLevel);

            int robotsCount = 0;

            foreach(IRobot robot in filteredRobots)
            {
                robotsCount++;
                robot.Eating(minutes);
            }

            return $"Robots fed: {robotsCount}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements
                .Models()
                .FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            IRobot robot = robots
                 .Models()
                 .FirstOrDefault(r => r.Model == model && !r.InterfaceStandards.Contains(supplement.InterfaceStandard));

            if (robot == null)
            {
                return $"All {model} are already upgraded!";
            }

            robot.InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";
        }


    }
}
