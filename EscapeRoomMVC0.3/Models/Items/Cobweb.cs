using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Cobweb : Item
    {
        public Cobweb(int positionX, int positionY)
            : base("Pajęczyna", "Gęsta pajęczyna pokrywająca róg pokoju.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            // Pajęczyna może nie mieć innych interakcji
        }
    }
}
