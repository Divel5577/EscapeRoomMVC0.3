using EscapeRoomMVC0._3.Controllers;
using EscapeRoomMVC0._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace EscapeRoomMVC0._3.Views
{
    public class DisplayMap
    {
        public static void Show(Room room, Player player)
        {
            Console.Clear();
            Console.WriteLine("Pokój: " + room.Name);

            // Wyświetlenie mapy z pozycją gracza
            var mapLines = room.AsciiMap.Split('\n');
            for (int y = 0; y < mapLines.Length; y++)
            {
                for (int x = 0; x < mapLines[y].Length; x++)
                {
                    if (x == player.PositionX && y == player.PositionY)
                    {
                        Console.Write('@'); // Wstawienie gracza
                    }
                    else
                    {
                        Console.Write(mapLines[y][x]);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nLegenda:");
            Console.WriteLine(room.Legend);

            Console.WriteLine("\nNaciśnij strzałki, aby się poruszać lub I, aby otworzyć ekwipunek.");
        }
    }

}
