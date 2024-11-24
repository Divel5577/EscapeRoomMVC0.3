namespace EscapeRoomMVC.Models
{
    public class Player
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Inventory Inventory { get; private set; }

        public Player(int startX, int startY)
        {
            PositionX = startX;
            PositionY = startY;
            Inventory = new Inventory();
        }

        public void Move(int deltaX, int deltaY)
        {
            PositionX += deltaX;
            PositionY += deltaY;
        }
    }
}
