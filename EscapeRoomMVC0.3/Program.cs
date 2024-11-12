using EscapeRoomMVC0._3.Controllers;
using EscapeRoomMVC0._3.Helpers;
using EscapeRoomMVC0._3.Models;
using EscapeRoomMVC0._3.Views;

public class Program
{
    static void Main()
    {
        // Inicjalizacja gracza, pokoju, mapy gry
        Player player = new Player(5, 5);
        Room startRoom = new Room("Biblioteka", "Assets/room1_map.txt", "Assets/room1_legend.txt");

        // Inicjalizacja przedmiotów w pokoju
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
