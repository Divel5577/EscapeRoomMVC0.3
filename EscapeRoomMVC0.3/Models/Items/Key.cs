namespace EscapeRoomMVC.Models.Items
{
    public class Key : Item
    {
        public Key() : base() { } // Bezparametrowy konstruktor

        public Key(int positionX, int positionY)
            : base("Klucz", "Mały mosiężny klucz. Może pasować do zamka.", true, positionX, positionY, "Assets/Images/key.jpg")
        {
            AddInteraction("Zbierz");
            AddInteraction("Oglądaj");
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Zbierz")
            {
                if (inventory.HasItem("Klucz"))
                {
                    Console.WriteLine("Już masz klucz w swoim ekwipunku.");
                }
                else
                {
                    inventory.AddItem(this);
                    Console.WriteLine("Dodałeś klucz do swojego ekwipunku.");
                }
            }
            else if (interaction == "Oglądaj")
            {
                Console.WriteLine("To mały mosiężny klucz. Może pasować do zamka.");
            }
            else
            {
                Console.WriteLine($"Nieznana interakcja: {interaction}");
            }
        }
    }
}
