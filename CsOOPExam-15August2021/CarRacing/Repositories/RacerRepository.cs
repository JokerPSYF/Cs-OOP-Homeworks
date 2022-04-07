using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>//, IEnumerable<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models { get => models.AsReadOnly(); }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidAddRacerRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(IRacer model) => this.models.Remove(model);
        
        public IRacer FindBy(string property)
            => models.FirstOrDefault(x => x.Username == property);

        //-----------------------------------------------

        //public IEnumerator<IRacer> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}