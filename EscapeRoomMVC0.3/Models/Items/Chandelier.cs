namespace EscapeRoomMVC.Models.Items
{
    public class Chandelier : Item
    {
        public Chandelier() : base() { }

        public Chandelier(int positionX, int positionY)
            : base("Żyrandol", "Stary, zakurzony żyrandol zwisający z sufitu.", false, positionX, positionY, "Assets/Images/chandelier.jpg")
        {
            AddInteraction("Oglądaj");
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Oglądaj")
            {
                Console.WriteLine("Żyrandol wygląda na stary i zakurzony, ale nic więcej.");
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
