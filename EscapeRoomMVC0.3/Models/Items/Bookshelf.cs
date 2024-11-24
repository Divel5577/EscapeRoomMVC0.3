using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models.Items
{
    public class Bookshelf : Item
    {
        public bool IsMoved { get; private set; }
        public Item ContainedItem { get; private set; }

        public Bookshelf(int positionX, int positionY)
            : base("Półka z książkami", "Stara półka z książkami, wygląda, jakby coś za nią było.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Przesuń"); // Dodanie opcji „Przesuń”
            ContainedItem = new Key(positionX, positionY); // Ustawienie klucza jako ukrytego przedmiotu
            IsMoved = false;
        }

        public void Move()
        {
            IsMoved = true;
        }
    }
}
