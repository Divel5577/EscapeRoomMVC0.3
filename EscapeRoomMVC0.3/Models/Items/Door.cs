using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Door : Item
    {
        public Door(int positionX, int positionY)
            : base("Drzwi", "Duże metalowe drzwi z zamkiem na klawiaturę.", false, positionX, positionY)
        {
            AddInteraction("Otwórz");
        }
    }
}
