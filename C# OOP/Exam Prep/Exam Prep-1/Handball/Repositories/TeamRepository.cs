using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;
        public IReadOnlyCollection<ITeam> Models
        {
            get { return teams.AsReadOnly(); }
        }

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return teams.Any(p => p.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return teams.FirstOrDefault(p => p.Name == name);

        }

        public bool RemoveModel(string name)
        {
            ITeam team = GetModel(name);

            return teams.Remove(team);
        }
    }
}
