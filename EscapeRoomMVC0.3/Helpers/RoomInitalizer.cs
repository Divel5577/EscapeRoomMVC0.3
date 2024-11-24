using EscapeRoomMVC0._3.Models;
using EscapeRoomMVC0._3.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Helpers
{
    public static class RoomInitializer
    {
        public static void InitializeItems(Room room)
        {
            // Drzwi
            var drzwi = new Door(26, 2, "4392");
            room.AddItem(drzwi);

            // Półka z książkami
            var bookshelf = new Bookshelf(3, 2);
            room.AddItem(bookshelf);

            // Biurko
            var desk = new Desk(8, 5);
            room.AddItem(desk);

            // Żyrandol
            var chandelier = new Chandelier(11, 2); // Pozycja nad sufitem
            room.AddItem(chandelier);

            // Obraz oka
            var painting = new Painting(5, 9);
            room.AddItem(painting);

            // Pajęczyna
            var cobweb = new Cobweb(26, 9);
            room.AddItem(cobweb);

            // Dziennik na biurku (ta sama pozycja co biurko)
            var journal = new Journal(8, 5);  //5, 16
            room.AddItem(journal);

            // Sejf ukryty za obrazem (ta sama pozycja co obraz)
            var safe = new Safe(5, 9);
            room.AddItem(safe);

            // Klucz w sejfie (na razie poza mapą, dodamy go po otwarciu sejfu)
            var key = new Key(-1, -1); // Pozycja poza mapą, klucz nie jest jeszcze dostępny
            room.HiddenItems.Add(key); // Zakładamy, że `Room` ma listę ukrytych przedmiotów
        }
    }

}
