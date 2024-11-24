namespace EscapeRoomMVC.Models.Items
{
    public class Door : Item
    {
        public string Code { get; }
        public bool IsOpen { get; private set; }

        public Door(int positionX, int positionY, string code)
            : base("Drzwi", "Metalowe drzwi z klawiaturą numeryczną.", false, positionX, positionY, "Assets/Images/door.jpg")
        {
            AddInteraction("Otwórz");
            Code = code;
            IsOpen = false;
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Otwórz")
            {
                Console.WriteLine("Podaj kod, aby otworzyć drzwi:");
                string inputCode = Console.ReadLine();
                if (inputCode == Code)
                {
                    IsOpen = true;
                    Console.WriteLine("Drzwi zostały otwarte! Gratulacje, udało Ci się uciec!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Kod niepoprawny. Spróbuj ponownie.");
                }
            }
            else
            {
                base.OnInteract(interaction, inventory);
            }
        }
    }
}
