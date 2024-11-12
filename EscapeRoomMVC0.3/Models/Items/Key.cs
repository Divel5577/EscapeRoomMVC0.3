using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Key : Item
    {
        public Key(int positionX, int positionY)
            : base("Klucz", "Mały klucz z wygrawerowanym symbolem.", true, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Zbierz");
        }
    }
}
