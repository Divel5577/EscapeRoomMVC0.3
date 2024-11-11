using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models
{
    public class Player
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Inventory Inventory { get; private set; }

        public Player(int startX, int startY)
        {
            PositionX = startX;
            PositionY = startY;
            Inventory = new Inventory(); // Zmieniono na Inventory zamiast List<Item>
        }

        public void Move(int deltaX, int deltaY)
        {
            PositionX += deltaX;
            PositionY += deltaY;
        }
    }

}
