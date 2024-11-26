Escape Room MVC Gra

Witaj w grze Escape Room MVC – przygodowej grze tekstowej, w której rozwiązujesz zagadki, wchodzisz w interakcje z przedmiotami i próbujesz wydostać się z tajemniczego pokoju! Projekt demonstruje wykorzystanie architektury Model-View-Controller (MVC) do stworzenia modułowej i rozbudowywalnej aplikacji konsolowej.

Funkcje gry
Interaktywna rozgrywka
Poruszaj się po pokoju za pomocą klawiszy strzałek. Wchodź w interakcje z przedmiotami, wybierając opcje z menu. Dodawaj znalezione przedmioty do ekwipunku i używaj ich, aby posuwać grę naprzód.

System ekwipunku
Przeglądaj i używaj zebranych przedmiotów. Nawiguj po menu ekwipunku przy użyciu strzałek.

Zapisywanie i wczytywanie gry
Zapisz swój postęp do pliku i wznów grę z zapisanego miejsca.

Limit czasowy
Śledź czas gry i sprawdź swój całkowity czas gry po jej ukończeniu.

Rozwiązywanie zagadek
Wchodź w interakcje z przedmiotami, takimi jak półki z książkami, obrazy czy sejfy. Używaj przedmiotów, takich jak klucze czy dzienniki, aby odkrywać sekrety i otwierać drzwi.

Rozbudowywalny system przedmiotów
Przedmioty, takie jak drzwi, klucze czy półki z książkami, są zaimplementowane jako klasy dziedziczące po podstawowej klasie Item. Łatwo rozszerz grę, dodając nowe typy przedmiotów.

Integracja z grafiką ASCII
Wyświetlaj grafikę ASCII dla przedmiotów i pokojów, aby wzbogacić wizualne wrażenia.

Struktura projektu
Kontrolery
Zarządzają logiką gry, taką jak ruch gracza, interakcje i stan gry.

GameController: Zarządza stanem gry, akcjami gracza i interakcjami w pokoju.
Modele
Definiują podstawowe struktury danych i logikę.

Player: Śledzi pozycję gracza i ekwipunek.
Room: Reprezentuje pokój gry, jego mapę i przedmioty.
Inventory: Zarządza zebranymi przedmiotami.
Item: Bazowa klasa dla wszystkich interaktywnych obiektów.
Widoki
Obsługują interfejs użytkownika i logikę wyświetlania.

DisplayMap: Renderuje mapę pokoju i pozycję gracza.
InteractionMenu: Wyświetla menu interakcji dla przedmiotów i ekwipunku.
Pomocnicze klasy
Narzędzia do serializacji, niestandardowych konwerterów JSON i innych zadań.

Jak grać
Rozpoczęcie gry
Uruchom aplikację i wybierz opcję „Rozpocznij nową grę” z menu. Poruszaj się po pokoju za pomocą strzałek.

Interakcje z przedmiotami
Stań na przedmiocie, aby wyświetlić opcje interakcji. Wybierz akcje, takie jak „Przesuń półkę” lub „Użyj klucza”.

Zapisywanie i wczytywanie
Zapisz postęp w grze do pliku za pomocą menu głównego. Wczytaj zapisany stan gry, aby kontynuować swoją przygodę.

Ukończenie gry
Rozwiązuj zagadki, znajdź kod i otwórz drzwi, aby uciec. Po udanym ukończeniu gry zobacz swój całkowity czas gry.

Instrukcja instalacji
Wymagania wstępne:

.NET 6 lub nowszy
Zgodny edytor tekstu lub IDE, np. Visual Studio
Uruchamianie gry:

Sklonuj repozytorium na swój komputer lokalny:
bash
Skopiuj kod
git clone [adres repozytorium]
cd EscapeRoomMVC
Zbuduj i uruchom projekt:
arduino
Skopiuj kod
dotnet build
dotnet run
Zapisywanie i wczytywanie:

Zapisane gry są przechowywane jako pliki JSON w katalogu aplikacji.
Upewnij się, że aplikacja ma uprawnienia do zapisu w katalogu.
Dodawanie nowych przedmiotów
Aby dodać nowy przedmiot:

Utwórz nową klasę dziedziczącą po Item.
Zaimplementuj specyficzne interakcje w metodzie OnInteract.
Dodaj nowy przedmiot do pokoju w klasie RoomInitializer.
Przykład:

csharp
Skopiuj kod
public class Lamp : Item
{
    public Lamp(int positionX, int positionY) 
        : base("Lamp", "Mała lampka biurkowa. Nie działa.", false, positionX, positionY)
    {
        AddInteraction("Zbadaj");
    }

    public override void OnInteract(string interaction, Inventory inventory)
    {
        if (interaction == "Zbadaj")
        {
            Console.WriteLine("Lampka jest zakurzona, ale brak w niej żarówki.");
        }
    }
}
Znane problemy
Niektóre interakcje mogą nie odświeżać poprawnie mapy.
Upewnij się, że pliki JSON zapisu gry nie są ręcznie edytowane, aby uniknąć błędów podczas deserializacji.
Autorzy
Patryk Dulkowski
Gracjan Czyżewski










