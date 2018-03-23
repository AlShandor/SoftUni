using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private int capacity;
        private List<Item> items;

        protected Bag()
        {
            items = new List<Item>();
        }

        public int Load => items.Select(i => i.Weight).Sum();

        public int Capacity
        {
            get { return this.capacity; }
            protected set
            {
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = items.FirstOrDefault(i => i.GetType().Name == name);
            items.Remove(item);

            return item;
        }

    }
}
