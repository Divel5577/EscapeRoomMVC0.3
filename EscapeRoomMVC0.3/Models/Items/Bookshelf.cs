namespace EscapeRoomMVC.Models.Items
{
    public class Bookshelf : Item
    {
        public bool IsMoved { get; private set; }
        public Item HiddenItem { get; }

        public Bookshelf(int positionX, int positionY, Item hiddenItem)
            : base("Półka", "Wygląda, jakby można ją było przesunąć.", false, positionX, positionY)
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
                Console.WriteLine("Przesunąłeś półkę i odkryłeś ukryty przedmiot!");
                inventory.AddItem(HiddenItem);
            }
            else if (interaction == "Przesuń" && IsMoved)
            {
                Console.WriteLine("Półka już została przesunięta.");
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
