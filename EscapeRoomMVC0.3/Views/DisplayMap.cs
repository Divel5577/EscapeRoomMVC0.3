using EscapeRoomMVC.Models;

namespace EscapeRoomMVC.Views
{
    public static class DisplayMap
    {
        public static void Update(Room room, Player player)
        {
            var mapLines = room.AsciiMap.Split('\n');
            // Odśwież poprzednią pozycję gracza
            Console.SetCursorPosition(player.LastPositionX, player.LastPositionY + 1);
            Console.Write(mapLines[player.LastPositionY][player.LastPositionX]);

            // Odśwież nową pozycję gracza
            Console.SetCursorPosition(player.PositionX, player.PositionY + 1);
            Console.Write('@');
        }

        public static void Show(Room room, Player player)
        {
            Console.Clear();
            Console.WriteLine("Pokój: " + room.Name);

            var mapLines = room.AsciiMap.Split('\n');
            for (int y = 0; y < mapLines.Length; y++)
            {
                Console.WriteLine(mapLines[y]);
            }

            // Rysujemy gracza w jego początkowej pozycji
            Console.SetCursorPosition(player.PositionX, player.PositionY + 1);
            Console.Write('@');
            Console.SetCursorPosition(0, mapLines.Length + 2);
            Console.WriteLine("\nLegenda:");
            Console.WriteLine(room.Legend);
            Console.WriteLine("\nNaciśnij strzałki, aby się poruszać lub I, aby otworzyć ekwipunek.");
        }

    }
}
