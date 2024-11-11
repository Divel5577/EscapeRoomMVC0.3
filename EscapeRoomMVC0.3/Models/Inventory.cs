using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item.IsCollectible)
            {
                items.Add(item);
                Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
            }
            else
            {
                Console.WriteLine($"{item.Name} nie można dodać do ekwipunku.");
            }
        }

        public bool ContainsItem(string itemName)
        {
            return items.Any(i => i.Name == itemName);
        }

        public void RemoveItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"{itemName} został usunięty z ekwipunku.");
            }
        }

        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(i => i.Name == itemName);
        }

        public void DisplayItems()
        {
            Console.WriteLine("Ekwipunek:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }

}
