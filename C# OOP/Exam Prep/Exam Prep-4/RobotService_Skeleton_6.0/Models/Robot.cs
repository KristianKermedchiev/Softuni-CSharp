using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {

        private string model;
        private int batteryCapacity;
        private int batteryLevel;

        private readonly List<int> interfaceStandards;

        protected Robot(int convertionCapacityIndex, string model, int batteryCapacity)
        {
            ConvertionCapacityIndex = convertionCapacityIndex;
            Model = model;
            BatteryCapacity = batteryCapacity;
            BatteryLevel = BatteryCapacity;
            ConvertionCapacityIndex = ConvertionCapacityIndex;

            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get;
            private set;
        }

        public int ConvertionCapacityIndex
        {
            get;
            private set;
        }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {

            int energy = ConvertionCapacityIndex * minutes;

            if (energy > BatteryCapacity - BatteryLevel)
            {
                BatteryLevel = BatteryCapacity;
            }
            else
            {
                BatteryCapacity += energy;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);

            // Decrease both BatteryCapacity and BatteryLevel
            batteryCapacity -= supplement.BatteryUsage;
            batteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if(batteryLevel >= consumedEnergy)
            {
                batteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string supplementsInstalled = InterfaceStandards.Any()
                ? $"{string.Join(" ", InterfaceStandards)}"
                : "none";

            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: { BatteryLevel}");
            sb.AppendLine($"--Supplements installed: {supplementsInstalled}");

            return sb.ToString().Trim();
        }
    }
}
