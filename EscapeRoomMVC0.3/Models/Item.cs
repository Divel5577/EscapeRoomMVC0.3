using System;
using System.Collections.Generic;

namespace EscapeRoomMVC.Models.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCollectible { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string ImagePath { get; set; } // Ścieżka do obrazka ASCII
        public List<string> Interactions { get; private set; }

        protected Item(string name, string description, bool isCollectible, int positionX, int positionY, string imagePath)
        {
            Name = name;
            Description = description;
            IsCollectible = isCollectible;
            PositionX = positionX;
            PositionY = positionY;
            ImagePath = imagePath;
            Interactions = new List<string>();
        }

        public virtual void OnInteract(string interaction, Inventory inventory)
        {
            Console.WriteLine($"Interakcja z {Name}: {interaction}");
        }

        public void AddInteraction(string interaction)
        {
            Interactions.Add(interaction);
        }
    }
}
