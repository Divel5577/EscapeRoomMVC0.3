using EscapeRoomMVC.Models.Items;
using System.IO;

namespace EscapeRoomMVC.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string AsciiMap { get; private set; }
        public string Legend { get; private set; }
        public List<Item> Items { get; private set; }
        public Dictionary<string, Room> Exits { get; private set; }

        public Room(string name, string mapFilePath, string legendFilePath)
        {
            Name = name;
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();
            LoadMapFromFile(mapFilePath);
            LoadLegendFromFile(legendFilePath);
        }

        private void LoadMapFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                AsciiMap = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("Błąd: Plik mapy nie został znaleziony.");
                AsciiMap = "Mapa nie jest dostępna.";
            }
        }

        private void LoadLegendFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                Legend = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("Błąd: Plik legendy nie został znaleziony.");
                Legend = "Legenda nie jest dostępna.";
            }
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Room GetExit(string direction)
        {
            return Exits.ContainsKey(direction) ? Exits[direction] : null;
        }
    }
}
