using EscapeRoomMVC.Models;
using EscapeRoomMVC.Models.Items;

namespace EscapeRoomMVC.Views
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
                        Console.WriteLine($"> {item.Interactions[i]}"); // Opcja zaznaczona
                    }
                    else
                    {
                        Console.WriteLine($"  {item.Interactions[i]}");
                    }
                }
                Console.WriteLine("  Wróć"); // Opcja powrotu

                key = Console.ReadKey(true).Key; // Użycie ReadKey(true), aby uniknąć wyświetlania klawiszy

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? item.Interactions.Count : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == item.Interactions.Count) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    // Zwróć wybraną opcję
                    return (selectedIndex == item.Interactions.Count) ? -1 : selectedIndex;
                }

            } while (key != ConsoleKey.Escape); // Opcja Esc pozwala wyjść z menu

            return -1; // Wróć w przypadku użycia Esc
        }



    }
}
