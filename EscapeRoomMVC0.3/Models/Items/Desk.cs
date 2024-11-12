using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Desk : Item
    {
        public Desk(int positionX, int positionY)
            : base("Biurko", "Drewniane biurko z dziennikiem na wierzchu.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Przeszukaj");
        }
    }
}
