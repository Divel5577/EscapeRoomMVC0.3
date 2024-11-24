using EscapeRoomMVC0._3.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomMVC0._3.Models
{
    public class Inventory
    {
        public List<Item> items;
        private Player player;

        public Inventory()
        {
            items = new List<Item>();
            this.player = player;
        }

        public void AddItem(Item item)
        {
            if (item.IsCollectible)
            {
                items.Add(item);
                Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
            }
            else
            {
                Console.WriteLine($"{item.Name} nie można dodać do ekwipunku.");
            }
        }
        public bool ContainsItem(string itemName)
        {
            return items.Any(i => i.Name == itemName);
        }

        public void RemoveItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"{itemName} został usunięty z ekwipunku.");
            }
        }

        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(i => i.Name == itemName);
        }
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Twój ekwipunek jest pusty.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }
        public void InteractWithItem(Item item)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"Interakcje dla przedmiotu: {item.Name}");

                // Wyświetl dostępne interakcje dla przedmiotu
                for (int i = 0; i < item.Interactions.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {item.Interactions[i]}"); // Zaznaczona interakcja
                    }
                    else
                    {
                        Console.WriteLine($"  {item.Interactions[i]}");
                    }
                }
                Console.WriteLine("  Wróć"); // Dodanie opcji "Wróć"

                key = Console.ReadKey().Key;

                // Obsługa nawigacji strzałkami
                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? item.Interactions.Count : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == item.Interactions.Count) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    // Sprawdzenie, czy wybrano "Wróć"
                    if (selectedIndex == item.Interactions.Count)
                    {
                        Console.WriteLine("Wracasz z powrotem.");
                        return; // Wyjście z metody, jeśli wybrano "Wróć"
                    }
                    PerformItemInteraction(item, item.Interactions[selectedIndex]);
                }

            } while (key != ConsoleKey.Escape);
        }
        private void PerformItemInteraction(Item item, string interaction)
        {
            Console.Clear();

            if (item == null)
            {
                Console.WriteLine("Błąd: Przedmiot nie istnieje.");
                Console.WriteLine("\nNaciśnij Enter, aby wrócić...");
                Console.ReadLine();
                return;
            }

            switch (interaction)
            {
                case "Oglądaj":
                    Console.WriteLine(item.Description);
                    break;
                case "Przeszukaj":
                    if (item.ContainedItem != null)
                    {
                        Console.WriteLine($"Przeszukujesz {item.Name} i znajdujesz {item.ContainedItem.Name}.");
                        InteractWithItem(item.ContainedItem);
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} nie zawiera niczego wartościowego.");
                    }
                    break;
                case "Przesuń":
                    if (item is Bookshelf bookshelf)
                    {
                        if (!bookshelf.IsMoved)
                        {
                            bookshelf.Move();
                            Console.WriteLine($"Przesuwasz {item.Name} i znajdujesz ukryty przedmiot: {bookshelf.ContainedItem.Name}.");
                            AddItem(bookshelf.ContainedItem);
                        }
                        else
                        {
                            Console.WriteLine($"{item.Name} została już przesunięta.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} nie można przesunąć.");
                    }
                    break;
                case "Zbierz":
                    if (!items.Contains(item))
                    {
                        AddItem(item);
                        Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} już znajduje się w ekwipunku.");
                    }
                    break;
                case "Użyj klucza":
                    if (item is Painting painting)
                    {
                        if (!painting.IsUnlocked)
                        {
                            // Sprawdzamy, czy gracz posiada klucz w ekwipunku
                            var key = items.FirstOrDefault(i => i is Key);
                            if (key != null)
                            {
                                painting.Unlock();
                                Console.WriteLine($"Użyłeś klucza na {item.Name}. Obraz się otwiera, ukazując kod: {painting.HiddenCode}");
                            }
                            else
                            {
                                Console.WriteLine("Nie masz klucza, aby otworzyć ten obraz.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{item.Name} już jest odblokowany i ukazuje kod: {painting.HiddenCode}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} nie można otworzyć kluczem.");
                    }
                    break;
                case "Użyj":
                    Console.WriteLine($"Używasz {item.Name}.");
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
            Console.WriteLine("\nNaciśnij Enter, aby wrócić...");
            Console.ReadLine();
        }


        public void ShowInventory()
        {
            if (items.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Twój ekwipunek jest pusty.");
                Console.WriteLine("\nNaciśnij Enter, aby wrócić...");
                Console.ReadLine();
                return;
            }

            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("Ekwipunek:");

                for (int i = 0; i < items.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {items[i].Name}"); // Zaznaczony przedmiot
                    }
                    else
                    {
                        Console.WriteLine($"  {items[i].Name}");
                    }
                }

                Console.WriteLine("\nUżyj strzałek do wyboru przedmiotu, Enter aby wybrać, Esc aby wyjść.");

                key = Console.ReadKey().Key;

                // Obsługa nawigacji strzałkami
                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? items.Count - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == items.Count - 1) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    InteractWithItem(items[selectedIndex]); // Użycie metody interakcji dla wybranego przedmiotu
                }

            } while (key != ConsoleKey.Escape);
        }

        public bool ShowInventoryMenu()
        {
            if (items.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Twój ekwipunek jest pusty.");
                Console.WriteLine("\nNaciśnij Enter, aby wrócić...");
                Console.ReadLine();
                return true; // Powrót do mapy po zamknięciu ekwipunku
            }

            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("Ekwipunek:");

                for (int i = 0; i < items.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {items[i].Name}");
                    }
                    else
                    {
                        Console.WriteLine($"  {items[i].Name}");
                    }
                }

                // Dodanie opcji „Wyjdź” jako ostatniej opcji w menu
                if (selectedIndex == items.Count)
                {
                    Console.WriteLine("> Wyjdź");
                }
                else
                {
                    Console.WriteLine("  Wyjdź");
                }

                Console.WriteLine("\nUżyj strzałek do wyboru przedmiotu, Enter aby wybrać.");

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? items.Count : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == items.Count) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == items.Count) // Jeśli wybrano „Wyjdź”
                    {
                        return true; // Powrót do mapy
                    }
                    DisplayItemOptions(items[selectedIndex]);
                }

            } while (true);
        }

        private void DisplayItemOptions(Item item)
        {
            int selectedIndex = 0;
            ConsoleKey key;
            List<string> options = GetItemOptions(item);

            do
            {
                Console.Clear();
                Console.WriteLine($"Opcje dla przedmiotu: {item.Name}");

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine($"> {options[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                Console.WriteLine("\nUżyj strzałek do wyboru opcji, Enter aby wybrać, Esc aby wrócić.");

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Count - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Count - 1) ? 0 : selectedIndex + 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    PerformItemOption(item, options[selectedIndex]);
                }

            } while (key != ConsoleKey.Escape);
        }

        private List<string> GetItemOptions(Item item)
        {
            List<string> options = new List<string>();

            if (item is Journal)
            {
                if (items.Contains(item)) // Jeśli dziennik jest w ekwipunku
                {
                    options.Add("Przeczytaj");
                }
                else
                {
                    options.Add("Zbierz");
                }
            }
            else if (item is Painting painting)
            {
                options.Add("Oglądaj");
                options.Add("Użyj klucza"); // Dodajemy opcję „Użyj klucza” dla obrazu
            }
            else
            {
                options.Add("Oglądaj");
                if (item.IsCollectible)
                {
                    options.Add("Użyj");
                }
            }

            return options;
        }

        private void PerformItemOption(Item item, string option)
        {
            Console.Clear();
            switch (option)
            {
                case "Przeczytaj":
                    if (item is Journal journal)
                    {
                        Console.WriteLine(journal.JournalContent); // Wyświetlenie treści dziennika
                    }
                    else
                    {
                        Console.WriteLine("Nie można przeczytać tego przedmiotu.");
                    }
                    break;
                case "Oglądaj":
                    Console.WriteLine(item.Description);
                    break;
                case "Zbierz":
                    if (!items.Contains(item)) // Jeśli przedmiot nie jest jeszcze w ekwipunku
                    {
                        AddItem(item);
                        Console.WriteLine($"{item.Name} został dodany do ekwipunku.");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} już znajduje się w ekwipunku.");
                    }
                    break;
                case "Użyj":
                    Console.WriteLine($"Używasz {item.Name}.");
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
            Console.WriteLine("\nNaciśnij Enter, aby wrócić...");
            Console.ReadLine();
        }

    }

}
