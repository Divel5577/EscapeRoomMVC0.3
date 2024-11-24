using EscapeRoomMVC.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace EscapeRoomMVC.Models
{
    public class Inventory
    {
        private List<Item> Items;

        public Inventory()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (!Items.Any(existingItem => existingItem.Name == item.Name))
            {
                Items.Add(item);
                Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
            }
            else
            {
                Console.WriteLine($"{item.Name} już znajduje się w ekwipunku.");
            }
        }
        public Item GetItem(string name)
        {
            return Items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Item> GetItems()
        {
            return Items; // Zwraca listę przedmiotów w ekwipunku
        }

        public void PerformItemInteraction(Item item, string interaction)
        {
            item.OnInteract(interaction, this);
        }


        public bool HasItem(string name)
        {
            return Items.Any(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

    }
}
