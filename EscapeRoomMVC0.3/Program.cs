using EscapeRoomMVC.Controllers;
using EscapeRoomMVC.Helpers;
using EscapeRoomMVC.Models;
using EscapeRoomMVC.Views;

public class Program
{
    static void Main()
    {
        Player player = new Player(5, 5);
        Room startRoom = new Room("Biblioteka", "Assets/room1_map.txt", "Assets/room1_legend.txt");

        RoomInitializer.InitializeItems(startRoom);

        GameController gameController = new GameController(player, startRoom);

        Console.WriteLine("Witaj w Bibliotece.");
        Console.WriteLine("Opis: To stara, podziemna biblioteka pełna kurzu i sekretów.");
        Console.WriteLine("Twoim celem jest wydostanie się z pokoju, rozwiązując zagadki.");
        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();

        bool isRunning = true;
        while (isRunning)
        {
            DisplayMap.Show(startRoom, player);

            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    gameController.MovePlayer(key);
                    break;
                case ConsoleKey.I:
                    gameController.ShowInventory();
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
            }
        }
    }
}
