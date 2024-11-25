using EscapeRoomMVC.Models;
using System;
using System.IO;
using System.Text.Json;

namespace EscapeRoomMVC.Helpers
{
    public class GameState
    {
        public required Player Player { get; set; }
        public required string CurrentRoomName { get; set; }
        public DateTime StartTime { get; set; }

        public static void Save(GameState state, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    WriteIndented = true,
                    Converters = { new ItemJsonConverter() } // Dodanie konwertera
                };

                string json = JsonSerializer.Serialize(state, options);

                File.WriteAllText(filePath, json);
                Console.WriteLine($"Stan gry został zapisany w: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisywania stanu gry: {ex.Message}");
            }
        }
    


        public static GameState Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Plik zapisu nie istnieje: {filePath}");
                    return null;
                }

                string json = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    WriteIndented = true,
                    Converters = { new ItemJsonConverter() } // Dodanie konwertera
                };

                var state = JsonSerializer.Deserialize<GameState>(json, options);

                Console.WriteLine($"Stan gry został wczytany z: {filePath}");
                return state;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wczytywania stanu gry: {ex.Message}");
                return null;
            }
        }
    }
}
