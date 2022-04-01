using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class Repository : IRepository<IVessel>
    {
        public IReadOnlyCollection<IVessel> Models { get; private set; }

        public Repository()
        {
            Models = new List<IVessel>();
        }

        public void Add(IVessel model)
        {
            if (!Models.Contains(model))
            {
                this.Models.Append(model);
            }
        }

        public bool Remove(IVessel model)
        {
            if (!Models.Contains(model))
            {
                return false;
            }

            List<IVessel> newVessels = Models.ToList();
            newVessels.Remove(model);
            Models = newVessels.AsReadOnly();

            return true;
        }

        public IVessel FindByName(string name)
        {
            IVessel vessel = Models.FirstOrDefault(x => x.Name == name);

            if (vessel == default) return null;

            return vessel;
        }
    }
}