using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Bookshelf : Item
    {
        public Bookshelf(int positionX, int positionY)
            : base("Półka z książkami", "Stara półka pełna książek.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Przesuń");
        }
    }
}
