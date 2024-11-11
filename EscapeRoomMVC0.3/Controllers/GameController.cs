using EscapeRoomMVC0._3.Models;
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
                Console.WriteLine($"Użyłeś {item.Name}.");
                player.Inventory.RemoveItem(itemName); // Usuń przedmiot po użyciu, jeśli to konieczne
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
                    }
                    break;
                case "Użyj":
                    UseItemFromInventory(item.Name);
                    break;
            }
        }


        public void ShowInventory()
        {
            player.Inventory.DisplayItems();
        }
    }
}
