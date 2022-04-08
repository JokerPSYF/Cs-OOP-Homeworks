using System.Collections.Generic;
using SpaceStation.Models.Bags.Contracts;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public ICollection<string> Items { get; }

        public Backpack()
        {
            Items = new List<string>();
        }
    }
}