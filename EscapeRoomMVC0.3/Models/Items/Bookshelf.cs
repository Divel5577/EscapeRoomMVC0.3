namespace EscapeRoomMVC.Models.Items
{
    public class Bookshelf : Item
    {
        public bool IsMoved { get; private set; }
        public Item HiddenItem { get; }

        public Bookshelf(int positionX, int positionY, Item hiddenItem)
            : base("Biblioteczka", "Wygląda, jakby można ją było przesunąć.", false, positionX, positionY, "Assets/Images/bookshelf.jpg")
        {
            AddInteraction("Przesuń");
            IsMoved = false;
            HiddenItem = hiddenItem;
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Przesuń" && !IsMoved)
            {
                IsMoved = true;
                Console.WriteLine("Przesunąłeś biblioteczkę i odkryłeś ukryty przedmiot!");
                inventory.AddItem(HiddenItem);
            }
            else if (interaction == "Przesuń" && IsMoved)
            {
                Console.WriteLine("biblioteczka już została przesunięta.");
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
