using System;
using System.IO;
using EscapeRoomMVC0._3.Helpers;
using Spectre.Console;

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
        AnsiConsole.MarkupLine("\n[bold yellow]Naciśnij dowolny klawisz, aby wrócić...[/]");
        Console.ReadKey();
    }
}