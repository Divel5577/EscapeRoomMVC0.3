using EscapeRoomMVC.Models;

namespace EscapeRoomMVC.Views
{
    public static class DisplayMap
    {
        public static void Show(Room room, Player player)
        {
            Console.Clear();
            Console.WriteLine("Pokój: " + room.Name);

            var mapLines = room.AsciiMap.Split('\n');
            for (int y = 0; y < mapLines.Length; y++)
            {
                for (int x = 0; x < mapLines[y].Length; x++)
                {
                    if (x == player.PositionX && y == player.PositionY)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        Console.Write(mapLines[y][x]);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nLegenda:");
            Console.WriteLine(room.Legend);

            Console.WriteLine("\nNaciśnij strzałki, aby się poruszać lub I, aby otworzyć ekwipunek.");
        }
    }
}
