using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.ExceedMaximumBagCapacity));
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.EmptyBag));
            }

            Item currItem = items.FirstOrDefault(x => x.GetType().Name == name);

            if (currItem == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(currItem);

            return currItem;
        }
    }
}