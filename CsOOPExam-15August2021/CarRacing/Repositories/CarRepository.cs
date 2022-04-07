using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models { get => models.AsReadOnly(); }


        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(ICar model) => this.models.Remove(model);

        public ICar FindBy(string property) 
            => models.FirstOrDefault(x => x.VIN == property);
        
    }
}