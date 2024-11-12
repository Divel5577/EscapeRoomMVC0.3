using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Safe : Item
    {
        public bool IsOpen { get; private set; }

        public Safe(int positionX, int positionY)
            : base("Sejf", "Mały sejf ukryty za obrazem.", false, positionX, positionY)
        {
            AddInteraction("Otwórz");
        }

        public void Open(string code)
        {
            if (code == "1234")
            {
                IsOpen = true;
                Console.WriteLine("Sejf został otwarty.");
            }
            else
            {
                Console.WriteLine("Niepoprawny kod.");
            }
        }
    }
}
