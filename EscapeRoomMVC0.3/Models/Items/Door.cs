using EscapeRoomMVC.Controllers;
using EscapeRoomMVC0._3.Models;

namespace EscapeRoomMVC.Models.Items
{
    public class Door : Item
    {
        public string Code { get; }
        public bool IsOpen { get; private set; }
        private GameController gameController;

        public Door(int positionX, int positionY, string code, GameController controller)
            : base("Drzwi", "Metalowe drzwi z klawiaturą numeryczną. Musisz wpisać kod, aby je otworzyć.", false, positionX, positionY, "Assets/Images/door.jpg")
        {
            AddInteraction("Otwórz");
            Code = code;
            IsOpen = false;
            gameController = controller;
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Otwórz")
            {
                Console.WriteLine("Podaj kod, aby otworzyć drzwi:");
                string inputCode = Console.ReadLine();
                if (inputCode == Code)
                {
                    Console.WriteLine("Drzwi zostały otwarte!");
                    gameController.EndGame();
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
