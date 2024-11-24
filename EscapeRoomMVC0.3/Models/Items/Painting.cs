﻿namespace EscapeRoomMVC.Models.Items
{
    public class Painting : Item
    {
        private bool isKeyholeVisible;

        public Painting(int positionX, int positionY)
            : base("Obraz", "Obraz przedstawiający oko. Wygląda, jakby skrywał coś więcej.", false, positionX, positionY)
        {
            AddInteraction("Oglądaj");
            AddInteraction("Użyj klucza");
            isKeyholeVisible = false;
        }

        public override void OnInteract(string interaction, Inventory inventory)
        {
            if (interaction == "Oglądaj")
            {
                if (isKeyholeVisible)
                {
                    Console.WriteLine("Obraz pokazuje dziurkę na klucz. Wygląda, jakby można było coś tutaj dopasować.");
                }
                else
                {
                    Console.WriteLine("Obraz przedstawia oko. Przyglądając się bliżej, zauważasz subtelne wypukłości na powierzchni.");
                }
            }
            else if (interaction == "Użyj klucza")
            {
                if (inventory.HasItem("Klucz"))
                {
                    Console.WriteLine("Używasz klucza, aby otworzyć obraz. Obraz przesuwa się, odsłaniając ukryty sejf!");
                    isKeyholeVisible = true; // Ustawienie, że klucz został użyty
                }
                else
                {
                    Console.WriteLine("Nie masz klucza, aby coś tutaj zrobić.");
                }
            }
            else
            {
                Console.WriteLine($"Nieznana interakcja: {interaction}");
            }
        }
    }
}
