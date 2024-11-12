using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Journal : Item
    {
        public Journal(int positionX, int positionY)
            : base("Dziennik", "Stary dziennik z pożółkłymi kartkami, leżący na biurku.", true, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Zbierz");
        }
    }
}
