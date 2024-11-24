using System;

namespace EscapeRoomMVC.Views
{
    public class MainMenu
    {
        private string[] options = { "Rozpocznij nową grę", "Wczytaj zapis", "Wyjdź" };
        private int selectedIndex = 0;

        public int Display()
        {
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Escape Room ===");
                Console.WriteLine("Wybierz opcję:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {options[i]}"); // Zaznaczone
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                }
            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
