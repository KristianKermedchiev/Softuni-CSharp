using Handball.Core.Contracts;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string LeagueStandings()
        {
            throw new NotImplementedException();
        }

        public string NewContract(string playerName, string teamName)
        {
            throw new NotImplementedException();
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            throw new NotImplementedException();
        }

        public string NewPlayer(string typeName, string name)
        {
            throw new NotImplementedException();
        }

        public string NewTeam(string name)
        {
            
        }

        public string PlayerStatistics(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
