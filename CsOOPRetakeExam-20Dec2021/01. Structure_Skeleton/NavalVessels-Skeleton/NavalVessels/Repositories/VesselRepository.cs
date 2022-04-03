﻿using System.Collections.Generic;
using System.Linq;
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

        public IReadOnlyCollection<IVessel> Models => models;  

        public void Add(IVessel model) => models.Add(model);
        
        public bool Remove(IVessel model) => models.Remove(model);

        public IVessel FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}