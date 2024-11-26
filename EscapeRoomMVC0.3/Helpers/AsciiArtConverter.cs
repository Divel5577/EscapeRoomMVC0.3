using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing; 

namespace EscapeRoomMVC0._3.Helpers
{
    public static class AsciiArtConverter
    {
        public static string ConvertImageToAscii(string imagePath, int width = 50)
        {
            using var image = Image.Load<Rgba32>(imagePath);

            // Skalowanie obrazu do żądanej szerokości (utrzymując proporcje)
            var aspectRatio = (double)image.Height / image.Width;
            int height = (int)(width * aspectRatio);

            // Skalowanie obrazu
            image.Mutate(x => x.Resize(width, height));

            var asciiBuilder = new StringBuilder();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image[x, y];
                    int gray = (pixel.R + pixel.G + pixel.B) / 3; // Konwersja do skali szarości
                    asciiBuilder.Append(GetAsciiChar(gray));
                }
                asciiBuilder.AppendLine();
            }

            return asciiBuilder.ToString();
        }

        private static char GetAsciiChar(int gray)
        {
            const string chars = "@%#*+=-:. "; // Mapowanie jasności na znaki ASCII
            return chars[gray * chars.Length / 256];
        }
    }
}
