using EscapeRoomMVC.Models;
using EscapeRoomMVC.Models.Items;
using EscapeRoomMVC0._3.Models;

namespace EscapeRoomMVC.Helpers
{
    public static class RoomInitializer
    {
        public static void InitializeItems(Room room)
        {
            room.AddItem(new Bookshelf(3, 2, new Key(-1, -1)));
            room.AddItem(new Chandelier(11, 2));
            room.AddItem(new Desk(8, 5));
            room.AddItem(new Door(26, 2, "4392"));
            room.AddItem(new Painting(5, 9));
            room.AddItem(new Cobweb(26, 9   ));
        }
    }
}
