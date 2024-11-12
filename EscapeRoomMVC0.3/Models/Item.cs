using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Interactions { get; private set; }
        public bool IsCollectible { get; set; }
        public int PositionX { get; set; } // Nowa właściwość
        public int PositionY { get; set; } // Nowa właściwość

        public Item(string name, string description, bool isCollectible, int positionX, int positionY)
        {
            Name = name;
            Description = description;
            IsCollectible = isCollectible;
            PositionX = positionX;
            PositionY = positionY;
            Interactions = new List<string>();
        }

        public void AddInteraction(string interaction)
        {
            Interactions.Add(interaction);
        }
    }
}
