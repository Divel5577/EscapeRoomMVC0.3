using EscapeRoomMVC.Controllers;
using EscapeRoomMVC.Helpers;
using EscapeRoomMVC.Models;
using EscapeRoomMVC.Views;
using System;

public class Program
{
    static void Main()
    {
        string saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "game_save.json");
        Player player = null;
        Room startRoom = null;
        GameController gameController = null;

        MainMenu mainMenu = new MainMenu();
        int choice = mainMenu.Display();

        switch (choice)
        {
            case 0: // Rozpocznij nową grę
                player = new Player(5, 5);
                startRoom = new Room("Biblioteka", "Assets/room1_map.txt", "Assets/room1_legend.txt");
                RoomInitializer.InitializeItems(startRoom,gameController);
                gameController = new GameController(player, startRoom);
                gameController.StartGame();
                break;

            case 1: // Wczytaj zapis
                var loadedState = GameState.Load(saveFilePath);
                if (loadedState != null)
                {
                    player = loadedState.Player;
                    startRoom = new Room(loadedState.CurrentRoomName, "Assets/room1_map.txt", "Assets/room1_legend.txt");
                    RoomInitializer.InitializeItems(startRoom,gameController);
                    gameController = new GameController(player, startRoom);
                    gameController.StartGame(loadedState.StartTime);
                }
                else
                {
                    Console.WriteLine("Nie udało się wczytać zapisu. Rozpoczynanie nowej gry.");
                    player = new Player(5, 5);
                    startRoom = new Room("Biblioteka", "Assets/room1_map.txt", "Assets/room1_legend.txt");
                    RoomInitializer.InitializeItems(startRoom,gameController);
                    gameController = new GameController(player, startRoom);
                    gameController.StartGame();
                }
                break;

            case 2: // Wyjdź
                Console.WriteLine("Dziękujemy za grę!");
                return;
        }

        bool isRunning = true;

        while (isRunning && gameController.IsGameRunning)
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
                case ConsoleKey.S:
                    var state = new GameState
                    {
                        Player = player,
                        CurrentRoomName = startRoom.Name,
                        StartTime = gameController.StartTime
                    };
                    GameState.Save(state, saveFilePath);
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
            }

            gameController.CheckForEndGame();
        }

        gameController.EndGame();
    }
}
