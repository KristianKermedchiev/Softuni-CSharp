using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {

        private readonly List<ISupplement> supplements = new List<ISupplement>();

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            var supplement = supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);

            return supplement;
        }

        public IReadOnlyCollection<ISupplement> Models() => supplements.AsReadOnly();

        public bool RemoveByName(string typeName) => supplements.Remove(supplements.FirstOrDefault(s => s.GetType().Name == typeName));
    }
}
