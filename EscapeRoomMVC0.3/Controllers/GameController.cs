using EscapeRoomMVC0._3.Models;
using EscapeRoomMVC0._3.Models.Items;
using EscapeRoomMVC0._3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Controllers
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

            // Sprawdzamy, czy pozycja nowa nie wychodzi poza mapę i czy jest dostępna do ruchu
            if (IsPositionWalkable(newX, newY))
            {
                player.Move(deltaX, deltaY);

                // Sprawdzamy, czy gracz wszedł na przedmiot
                var item = GetItemAtPosition(newX, newY);
                if (item != null)
                {
                    InteractWithItem(item); // Wyświetlenie menu interakcji
                }
            }
        }


        private bool IsPositionWalkable(int x, int y)
        {
            // Sprawdzenie, czy pozycja jest w granicach mapy i nie jest ścianą
            return currentRoom.AsciiMap.Split('\n')[y][x] != '#';
        }

        private Item GetItemAtPosition(int x, int y)
        {
            return currentRoom.Items.FirstOrDefault(item => item.PositionX == x && item.PositionY == y);
        }

        public void AddItemToInventory(Item item)
        {
            player.Inventory.AddItem(item); // Dodaje przedmiot do ekwipunku gracza
            Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
        }

        public void UseItemFromInventory(string itemName)
        {
            var item = player.Inventory.GetItem(itemName);
            if (item != null)
            {
                if (item is Journal)
                {
                    Console.WriteLine("Czytasz dziennik. Zawiera wskazówki dotyczące otwarcia sejfu i drzwi.");
                }
                else if (item is Key)
                {
                    Console.WriteLine("Klucz może być użyty tylko przy drzwiach.");
                }
                else
                {
                    Console.WriteLine($"Użyłeś {item.Name}, ale nic się nie wydarzyło.");
                }
            }
            else
            {
                Console.WriteLine("Nie masz tego przedmiotu w ekwipunku.");
            }
        }
        public void InteractWithItem(Item item)
        {
            int selectedInteraction = InteractionMenu.DisplayInteractions(item);

            switch (item.Interactions[selectedInteraction])
            {
                case "Oglądaj":
                    Console.WriteLine(item.Description);
                    break;
                case "Zbierz":
                    if (item.IsCollectible)
                    {
                        player.Inventory.AddItem(item);
                        Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
                        // Usunięcie przedmiotu z pokoju po zebraniu
                        currentRoom.Items.Remove(item);
                    }
                    break;
                case "Przesuń":
                    if (item is Bookshelf || item is Painting)
                    {
                        Console.WriteLine($"Przesunąłeś {item.Name}.");
                        // Jeśli to obraz, odsłoń sejf
                        if (item is Painting)
                        {
                            var safe = currentRoom.HiddenItems.FirstOrDefault(i => i is Safe);
                            if (safe != null)
                            {
                                currentRoom.RevealItem(safe);
                                Console.WriteLine("Odkryłeś sejf ukryty za obrazem!");
                            }
                        }
                    }
                    break;
                case "Otwórz":
                    if (item is Safe safeItem)
                    {
                        Console.Write("Podaj kod do sejfu: ");
                        string code = Console.ReadLine();
                        safeItem.Open(code);
                        if (safeItem.IsOpen)
                        {
                            // Odsłoń klucz w sejfie
                            var key = currentRoom.HiddenItems.FirstOrDefault(i => i is Key);
                            if (key != null)
                            {
                                key.PositionX = player.PositionX;
                                key.PositionY = player.PositionY;
                                currentRoom.RevealItem(key);
                                Console.WriteLine("Znalazłeś klucz w sejfie!");
                            }
                        }
                    }
                    else if (item is Door)
                    {
                        Console.Write("Podaj kod do drzwi: ");
                        string code = Console.ReadLine();
                        if (player.Inventory.ContainsItem("Klucz") && code == "5678") // Przykładowy kod
                        {
                            Console.WriteLine("Otworzyłeś drzwi i wydostałeś się z pokoju. Gratulacje!");
                            // Logika zakończenia gry
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Nie udało się otworzyć drzwi.");
                        }
                    }
                    break;
                case "Przeszukaj":
                    if (item is Desk)
                    {
                        Console.WriteLine("Przeszukując biurko, znalazłeś dziennik.");
                        // Dziennik jest już na biurku, więc nie musimy nic więcej robić
                    }
                    break;
                default:
                    Console.WriteLine("Brak dostępnej akcji.");
                    break;
            }
        }


        public void ShowInventory()
        {
            player.Inventory.DisplayItems();
        }
    }
}
