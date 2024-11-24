using System;
using EscapeRoomMVC.Models;
using EscapeRoomMVC.Models.Items;
using EscapeRoomMVC.Views;
using EscapeRoomMVC0._3.Models;

namespace EscapeRoomMVC.Controllers
{
    public class GameController
    {
        private Player player;
        private Room currentRoom;

        public GameController(Player player, Room room)
        {
            this.player = player;
            this.currentRoom = room;
        }

        public void MovePlayer(ConsoleKey direction)
        {
            int deltaX = 0, deltaY = 0;

            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    deltaY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    deltaY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    deltaX = -1;
                    break;
                case ConsoleKey.RightArrow:
                    deltaX = 1;
                    break;
            }

            int newX = player.PositionX + deltaX;
            int newY = player.PositionY + deltaY;

            if (IsPositionWalkable(newX, newY))
            {
                player.Move(deltaX, deltaY);

                // Zaktualizuj tylko część mapy
                DisplayMap.Update(currentRoom, player);

                var item = GetItemAtPosition(newX, newY);
                if (item != null)
                {
                    InteractWithItem(item); // Wywołanie menu interakcji
                }
            }
        }



        private bool IsPositionWalkable(int x, int y)
        {
            var mapLines = currentRoom.AsciiMap.Split('\n');

            // Sprawdzenie granic mapy
            if (y < 0 || y >= mapLines.Length || x < 0 || x >= mapLines[y].Length)
            {
                return false;
            }

            // Sprawdzenie, czy pole nie jest ścianą
            return mapLines[y][x] != '#';
        }


        private void InteractWithItem(Item item)
        {
            bool exitInteraction = false;

            while (!exitInteraction)
            {
                int selectedIndex = InteractionMenu.DisplayInteractions(item);

                if (selectedIndex != -1)
                {
                    string interaction = item.Interactions[selectedIndex];
                    Console.Clear();

                    // Wywołanie logiki interakcji
                    player.Inventory.PerformItemInteraction(item, interaction);

                    Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu interakcji.");
                    Console.ReadLine();
                }
                else
                {
                    // Wyjście z menu interakcji
                    exitInteraction = true;
                }
            }
        }

        public void ShowInventory()
        {
            bool exitInventory = false;

            while (!exitInventory)
            {
                Console.Clear();
                Console.WriteLine("Twój ekwipunek:");

                var items = player.Inventory.GetItems();
                if (items.Count == 0)
                {
                    Console.WriteLine("Ekwipunek jest pusty.");
                    Console.WriteLine("\nNaciśnij Enter, aby wrócić.");
                    Console.ReadLine();
                    return;
                }

                int selectedIndex = 0;
                ConsoleKey key;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Twój ekwipunek:");
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.WriteLine($"> {items[i].Name}"); // Zaznaczony przedmiot
                        }
                        else
                        {
                            Console.WriteLine($"  {items[i].Name}");
                        }
                    }
                    Console.WriteLine("\nUżyj strzałek do wyboru, Enter aby wybrać, Esc aby wyjść.");

                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex == 0) ? items.Count - 1 : selectedIndex - 1;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex == items.Count - 1) ? 0 : selectedIndex + 1;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        var selectedItem = items[selectedIndex];
                        ShowItemInteractions(selectedItem); // Wyświetlenie menu interakcji
                    }

                } while (key != ConsoleKey.Escape);

                exitInventory = true;
            }
        }
        private void ShowItemInteractions(Item item)
        {
            bool exitItemMenu = false;

            while (!exitItemMenu)
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
                            Console.WriteLine($"> {item.Interactions[i]}"); // Zaznaczona opcja
                        }
                        else
                        {
                            Console.WriteLine($"  {item.Interactions[i]}");
                        }
                    }
                    Console.WriteLine("  Wróć");

                    key = Console.ReadKey(true).Key;

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
                        if (selectedIndex == item.Interactions.Count)
                        {
                            exitItemMenu = true; // Wyjście z menu interakcji
                        }
                        else
                        {
                            string interaction = item.Interactions[selectedIndex];
                            Console.Clear();

                            // Wywołanie logiki interakcji
                            player.Inventory.PerformItemInteraction(item, interaction);

                            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu interakcji.");
                            Console.ReadLine();
                        }
                    }

                } while (!exitItemMenu);
            }
        }


        private Item GetItemAtPosition(int x, int y)
        {
            return currentRoom.Items.FirstOrDefault(item => item.PositionX == x && item.PositionY == y);
        }



    }
}
