using EscapeRoomMVC0._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Views
{
    public static class InteractionMenu
    {
        public static int DisplayInteractions(Item item)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"Interakcje z: {item.Name}");
                for (int i = 0; i < item.Interactions.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {item.Interactions[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"  {item.Interactions[i]}");
                    }
                }
                Console.WriteLine("  Wróć");

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? item.Interactions.Count : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == item.Interactions.Count) ? 0 : selectedIndex + 1;
                }

            } while (key != ConsoleKey.Enter);

            // Zwraca -1, jeśli wybrano "Wróć"
            return selectedIndex == item.Interactions.Count ? -1 : selectedIndex;
        }
    }


}
