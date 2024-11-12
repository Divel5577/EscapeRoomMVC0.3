using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Chandelier : Item
    {
        public Chandelier(int positionX, int positionY)
            : base("Żyrandol", "Stary, zakurzony żyrandol zwisający z sufitu.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
        }
    }
}
