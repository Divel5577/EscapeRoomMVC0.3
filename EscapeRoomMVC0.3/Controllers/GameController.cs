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

            if (IsPositionWalkable(newX, newY))
            {
                player.Move(deltaX, deltaY);

                // Zaktualizuj tylko część mapy
                DisplayMap.Update(currentRoom, player);

                var item = GetItemAtPosition(newX, newY);
                if (item != null)
                {
                    player.Inventory.InteractWithItem(item);
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
        public void ShowInventory()
        {
            bool exitInventory = false;

            while (!exitInventory)
            {
                Console.Clear();
                exitInventory = player.Inventory.ShowInventoryMenu(); // Zmieniona metoda zwróci true po wyjściu z ekwipunku
            }

            // Po wyjściu z ekwipunku wracamy do wyświetlenia mapy
            DisplayMap.Show(currentRoom, player);
        }



    }
}
