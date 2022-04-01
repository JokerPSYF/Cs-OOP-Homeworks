using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models;

        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models { get => models;  }

        public void Add(IVessel model) => this.models.Append(model);
        
        public bool Remove(IVessel model) => models.Remove(model);

        public IVessel FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}