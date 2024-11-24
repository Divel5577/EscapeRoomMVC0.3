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
        public int LastPositionX { get; set; } // Nowe pole
        public int LastPositionY { get; set; } // Nowe pole
        public Inventory Inventory { get; private set; }

        public Player(int startX, int startY)
        {
            PositionX = startX;
            PositionY = startY;
            LastPositionX = startX;
            LastPositionY = startY;
            Inventory = new Inventory();
        }

        public void Move(int deltaX, int deltaY)
        {
            LastPositionX = PositionX;
            LastPositionY = PositionY;
            PositionX += deltaX;
            PositionY += deltaY;
        }
    }


}
