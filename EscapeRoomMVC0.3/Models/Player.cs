namespace EscapeRoomMVC.Models
{
    public class Player
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int LastPositionX { get; set; } // Nowe pole
        public int LastPositionY { get; set; } // Nowe pole
        public Inventory Inventory { get; set; }
        public Player()
        {
            Inventory = new Inventory(); // Inicjalizacja Inventory
        }
        public Player(int startX, int startY)
        {
            PositionX = startX;
            PositionY = startY;
            LastPositionX = startX;
            LastPositionY = startY;
            Inventory = new Inventory();
        }

        public void Move(int deltaX, int deltaY)
        {
            LastPositionX = PositionX;
            LastPositionY = PositionY;
            PositionX += deltaX;
            PositionY += deltaY;
        }
    }


}
