using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Painting : Item
    {
        public Painting(int positionX, int positionY)
            : base("Obraz oka", "Tajemniczy obraz przedstawiający oko, które zdaje się cię obserwować.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Przesuń");
        }
    }
}
