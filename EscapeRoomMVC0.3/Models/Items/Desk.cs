namespace EscapeRoomMVC.Models.Items
{
    public class Desk : Item
    {
        public Desk(int positionX, int positionY)
            : base("Biurko", "Stare drewniane biurko. Wygląda, jakby miało coś w środku.", false, positionX, positionY)
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
