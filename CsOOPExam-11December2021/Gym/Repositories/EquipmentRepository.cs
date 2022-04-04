using System.Collections.Generic;
using System.Linq;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment> //!!!

    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => this.models.AsReadOnly();
        
        public void Add(IEquipment model)
            => models.Add(model);

        public bool Remove(IEquipment model)
            => models.Remove(model);

        public IEquipment FindByType(string type)
            => models.FirstOrDefault(x => x.GetType().Name == type);
        
    }
}