using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Painting : Item
    {
        public bool IsUnlocked { get; private set; }
        public string HiddenCode { get; private set; }

        public Painting(int positionX, int positionY)
            : base("Obraz", "Tajemniczy obraz z dziurką na klucz w środku, który wygląda, jakby coś ukrywał za sobą.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Użyj klucza");
            HiddenCode = "4392"; // Przykładowy kod do drzwi
            IsUnlocked = false;
        }

        public void Unlock()
        {
            IsUnlocked = true;
        }
    }
}
