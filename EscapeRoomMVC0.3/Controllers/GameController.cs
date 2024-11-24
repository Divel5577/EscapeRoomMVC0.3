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
        private DateTime startTime;
        private DateTime? endTime;

        public DateTime StartTime => startTime;
        public bool IsGameRunning { get; set; }

        public GameController(Player player, Room room)
        {
            this.player = player;
            this.currentRoom = room;
            IsGameRunning = true;
        }

        public void StartGame(DateTime? loadedStartTime = null)
        {
            startTime = loadedStartTime ?? DateTime.Now;
            Console.WriteLine("Gra rozpoczęta!");
        }


        public void EndGame()
        {
            endTime = DateTime.Now;
            IsGameRunning = false;

            DisplayGameTime();
            Console.WriteLine("Dziękujemy za grę! Naciśnij dowolny klawisz, aby zakończyć.");
            Console.ReadKey();
            Environment.Exit(0); // Kończy program po podsumowaniu
        }

        private void DisplayGameTime()
        {
            if (endTime.HasValue)
            {
                TimeSpan gameDuration = endTime.Value - startTime;
                Console.WriteLine($"Czas gry: {gameDuration.Hours:D2}:{gameDuration.Minutes:D2}:{gameDuration.Seconds:D2}");
            }
            else
            {
                Console.WriteLine("Gra nie została zakończona poprawnie.");
            }
        }

        public void CheckForEndGame()
        {
            foreach (var item in currentRoom.Items)
            {
                if (item is Door door && door.IsOpen)
                {
                    EndGame();
                    break;
                }
            }
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
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"Interakcje z przedmiotem: {item.Name}");
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
                        return; // Powrót do mapy
                    }

                    string interaction = item.Interactions[selectedIndex];
                    Console.Clear();

                    // Obsługa interakcji
                    player.Inventory.PerformItemInteraction(item, interaction);

                    Console.WriteLine("\nNaciśnij Enter, aby wrócić.");
                    Console.ReadLine();
                }

            } while (true);
        }


        public void ShowInventory()
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
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
                Console.WriteLine("  Wróć");

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? items.Count : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == items.Count) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == items.Count)
                    {
                        return; // Powrót do mapy
                    }

                    var selectedItem = items[selectedIndex];
                    ShowItemInteractions(selectedItem); // Wywołanie menu interakcji dla przedmiotu
                }

            } while (true);
        }

        private void ShowItemInteractions(Item item)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"Interakcje z przedmiotem: {item.Name}");
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
                        return; // Powrót do ekwipunku
                    }

                    string interaction = item.Interactions[selectedIndex];
                    Console.Clear();

                    // Obsługa interakcji
                    player.Inventory.PerformItemInteraction(item, interaction);

                    Console.WriteLine("\nNaciśnij Enter, aby wrócić.");
                    Console.ReadLine();
                }

            } while (true);
        }



        private Item GetItemAtPosition(int x, int y)
        {
            return currentRoom.Items.FirstOrDefault(item => item.PositionX == x && item.PositionY == y);
        }



    }
}
