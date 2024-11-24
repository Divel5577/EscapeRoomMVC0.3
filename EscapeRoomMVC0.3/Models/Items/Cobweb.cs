namespace EscapeRoomMVC.Models.Items
{
    public class Cobweb : Item
    {
        public Cobweb(int positionX, int positionY)
            : base("Pajęczyna", "Gęsta pajęczyna pokrywająca róg pokoju.", false, positionX, positionY, "Assets/Images/cobweb.jpg")
        {
            AddInteraction("Oglądaj");
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Oglądaj")
            {
                Console.WriteLine("To tylko pajęczyna. Nic tutaj nie znajdziesz.");
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
