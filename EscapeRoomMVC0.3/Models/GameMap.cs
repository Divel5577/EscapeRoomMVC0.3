﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoomMVC.Models;

namespace EscapeRoomMVC0._3.Models
{
    public class GameMap
    {
        public Room CurrentRoom { get; private set; }
        private Player player;

        public GameMap(Player player, Room startRoom)
        {
            this.player = player;
            CurrentRoom = startRoom;
        }

        public void MovePlayer(string direction)
        {
            Room nextRoom = CurrentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                CurrentRoom = nextRoom;
                // Resetuje pozycję gracza w nowym pokoju (przykładowo na początek pokoju)
                player.PositionX = 0;
                player.PositionY = 0;
            }
            else
            {
                Console.WriteLine("Nie możesz pójść w tym kierunku.");
            }
        }
    }

}
