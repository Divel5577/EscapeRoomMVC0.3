namespace EscapeRoomMVC.Models.Items
{
    public class Journal : Item
    {
        public string Content { get; }

        public Journal(int positionX, int positionY)
            : base("Dziennik", "Stary dziennik z pożółkłymi kartkami, leżący na biurku.", true, positionX, positionY)
        {
            AddInteraction("Przeczytaj");
            Content = "Dziennik jest pełen wpisów o tajemniczych wydarzeniach...\n" +
                      "Data: 23 października\n" +
                      "Odkryłem coś niepokojącego za półką w bibliotece...";
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Przeczytaj")
            {
                Console.WriteLine($"Treść dziennika:\n{Content}");
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
