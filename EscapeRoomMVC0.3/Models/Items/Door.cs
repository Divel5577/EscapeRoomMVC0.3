using System;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Door : Item
    {
        public string Code { get; }
        public bool IsOpen { get; private set; }

        public Door(int positionX, int positionY, string code)
            : base("Drzwi", "Duże metalowe drzwi z zamkiem na klawiaturę. Musisz wpisać kod, aby je otworzyć.", false, positionX, positionY)
        {
            AddInteraction("Otwórz");
            Code = code;
            IsOpen = false;
        }

        public bool TryOpen(string inputCode)
        {
            if (inputCode == Code)
            {
                IsOpen = true;
                return true;
            }
            return false;
        }
    }
}
