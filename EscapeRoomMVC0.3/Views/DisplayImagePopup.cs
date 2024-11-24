using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoomMVC0._3.Helpers;
using Spectre.Console;

namespace EscapeRoomMVC0._3.Views
{
    public static class DisplayImagePopup
    {
        public static void Show(string imageName, string description)
        {
            string imagePath = $"Assets/Images/{imageName}";

            // Konwersja obrazu na ASCII
            string asciiArt = AsciiArtConverter.ConvertImageToAscii(imagePath);

            // Wyświetlanie w oknie Spectre.Console
            var panel = new Panel(asciiArt)
                .BorderColor(Color.Blue)
                .Header($"[bold yellow]{imageName}[/]", Justify.Center);

            AnsiConsole.Clear();
            AnsiConsole.Write(panel);

            // Dodanie opisu i opcji interakcji
            AnsiConsole.MarkupLine($"\n[bold green]Opis:[/] {description}");
            AnsiConsole.MarkupLine("[bold]1.[/] Powrót\n[bold]2.[/] Dalsza interakcja");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.D2);

            if (key.Key == ConsoleKey.D2)
            {
                AnsiConsole.MarkupLine("[bold yellow]Wchodzisz w dalszą interakcję z obiektem![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Wracasz do mapy...[/]");
            }
        }
    }
}
