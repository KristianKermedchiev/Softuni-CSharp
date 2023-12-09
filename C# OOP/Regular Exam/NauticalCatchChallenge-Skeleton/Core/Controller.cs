using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {

        IRepository<IFish> fish;
        IRepository<IDiver> divers;

        public Controller()
        {
            fish = new FishRepository();
            divers = new DiverRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if( diverType != "FreeDiver" && diverType != "ScubaDiver")
            {
                return $"{diverType} is not allowed in our competition.";
            }

            var foundDiver = divers.Models.FirstOrDefault(d => d.Name == diverName);

            if (foundDiver != null)
            {
                return $"{diverName} is already a participant -> {divers.GetType().Name}.";
            }

            if (diverType == "FreeDiver")
            {
                divers.AddModel(new FreeDiver(diverName));
            }
            else if (diverType == "ScubaDiver")
            {
                divers.AddModel(new ScubaDiver(diverName));
            }

            return $"{diverName} is successfully registered for the competition -> {divers.GetType().Name}.";
        }


        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != "ReefFish" && fishType != "DeepSeaFish" && fishType != "PredatoryFish")
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            var foundFish = fish.Models.FirstOrDefault(f => f.Name == fishName);

            if (foundFish != null)
            {
                return $"{fishName} is already allowed -> {fish.GetType().Name}.";
            }

            if (fishType == "ReefFish")
            {
                fish.AddModel(new ReefFish(fishName, points));
            }
            else if(fishType == "DeepSeaFish")
            {
                fish.AddModel(new DeepSeaFish(fishName, points));
            }
            else if ((fishType == "PredatoryFish"))
            {
                fish.AddModel(new PredatoryFish(fishName, points));
            }

            return $"{fishName} is allowed for chasing.";
        }


        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            var foundDiver = divers.Models.FirstOrDefault(d => d.Name == diverName);
            var foundFish = fish.Models.FirstOrDefault(f => f.Name == fishName);

            if (foundDiver == null)
            {
                return $"{divers.GetType().Name} has no {diverName} registered for the competition.";
            }

            if (foundFish == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            if (foundDiver.HasHealthIssues == true)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (foundDiver.OxygenLevel < foundFish.TimeToCatch)
            {
                foundDiver.Miss(foundFish.TimeToCatch);

                if (foundDiver.OxygenLevel <= 0)
                {
                    foundDiver.UpdateHealthStatus();
                }

                return $"{diverName} missed a good {fishName}.";
            }
            else if (foundDiver.OxygenLevel ==  foundFish.TimeToCatch)
            {
                if (isLucky == true)
                {
                    foundDiver.Hit(foundFish);

                    if (foundDiver.OxygenLevel <= 0)
                    {
                        foundDiver.UpdateHealthStatus();
                    }

                    return $"{diverName} hits a {foundFish.Points}pt. {fishName}.";
                }
                else
                {
                    foundDiver.Miss(foundFish.TimeToCatch);

                    if (foundDiver.OxygenLevel <= 0)
                    {
                        foundDiver.UpdateHealthStatus();
                    }

                    return $"{diverName} missed a good {fishName}.";
                }
            }

                foundDiver.Hit(foundFish);

            if(foundDiver.OxygenLevel <= 0)
            {
                foundDiver.UpdateHealthStatus();
            }

                return $"{diverName} hits a {foundFish.Points}pt. {fishName}.";
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            var foundDivers = divers.Models
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name);

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach( var diver in foundDivers)
            {
                if(diver.HasHealthIssues == false)
                {
                    sb.AppendLine(diver.ToString().Trim());
                }
            }
            return sb.ToString().Trim();

        }

        

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            var foundDiver = divers.Models.FirstOrDefault(d => d.Name == diverName);

            sb.AppendLine(foundDiver.ToString().Trim());
            sb.AppendLine("Catch Report:");

            foreach (var item in foundDiver.Catch)
            {
                var foundFish = fish.GetModel(item);

                sb.AppendLine(foundFish.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            int recoveredDiversCount = 0;

            foreach (var diver in divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    diver.UpdateHealthStatus();

                    diver.RenewOxy();

                    recoveredDiversCount++;
                }
            }
            return $"Divers recovered: {recoveredDiversCount}";
        }

        
    }
}
