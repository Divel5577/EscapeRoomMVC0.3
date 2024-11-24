namespace EscapeRoomMVC.Models.Items
{
    public class Desk : Item
    {
        public Desk(int positionX, int positionY)
            : base("biórko", "Stary drewniany stół.", false, positionX, positionY, "Assets/Images/desk.jpg")
        {
            AddInteraction("Przeszukaj");
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Przeszukaj")
            {
                Console.WriteLine("W biurku znalazłeś dziennik. Dodano do ekwipunku.");
                inventory.AddItem(new Journal(PositionX, PositionY));
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
