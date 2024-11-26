using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoomMVC0._3.Helpers;
using Spectre.Console;

namespace EscapeRoomMVC0._3.Views
{
    public static class AsciiPopup
    {
        public static void Show(string imagePath)
        {
            // Konwersja obrazu na ASCII
            string asciiArt = AsciiArtConverter.ConvertImageToAscii(imagePath);

            // Wyświetlanie ASCII w popupie
            AnsiConsole.Clear();
            var panel = new Panel(asciiArt)
                .BorderColor(Color.Blue)
                .Header("Obraz obiektu", Justify.Center);

            AnsiConsole.Write(panel);

            // Powrót do gry
            AnsiConsole.MarkupLine("\n[bold yellow]Naciśnij dowolny klawisz, aby kontynuować...[/]");
            Console.ReadKey();
        }
    }
}

