Escape Room MVC Game
Welcome to the Escape Room MVC Game, a text-based adventure game where you solve puzzles, interact with objects, and try to escape a mysterious room! This project demonstrates the use of the Model-View-Controller (MVC) architecture to create a modular and extendable console application.

Features
Interactive Gameplay

Move around the room using arrow keys.
Interact with objects by selecting options from a menu.
Add collected items to your inventory and use them to progress.
Inventory System

View and interact with collected items.
Navigate the inventory menu using arrow keys.
Game Save & Load

Save your progress to a file.
Load a saved game to continue your journey.
Timed Gameplay

Track the duration of your game.
View your total playtime upon completing the game.
Puzzle Solving

Solve puzzles by interacting with various objects like bookshelves, paintings, and safes.
Use items like keys and journals to uncover secrets and unlock doors.
Extensible Object System

Items like Doors, Keys, and Bookshelves are implemented as classes inheriting from a base Item class.
Easily extend the game by adding new item types.
ASCII Art Integration

Display ASCII art for objects and rooms to enhance the visual experience.
Project Structure
Controllers
Handles the game's core logic, such as player movement, interaction management, and game state control.

GameController: Manages the game's state, player actions, and room interactions.
Models
Defines the core data structures and logic.

Player: Tracks player position and inventory.
Room: Represents the game room, its map, and items.
Inventory: Manages the player's collected items.
Item: Base class for all interactable objects.
Views
Handles the user interface and display logic.

DisplayMap: Renders the room map and player position.
InteractionMenu: Displays interactive menus for items and inventory.
Helpers
Utility classes for serialization, custom JSON converters, and other tasks.

How to Play
Start the Game

Run the application and select "Start New Game" from the menu.
Navigate the room using arrow keys.
Interact with Objects

Step on an object to view interaction options.
Use the menu to perform actions like "Move Bookshelf" or "Use Key."
Save and Load

Save your game progress to a file using the main menu.
Load a saved game to resume your adventure.
Complete the Game

Solve puzzles, find the code, and unlock the door to escape.
View your total playtime upon successful escape.
Setup Instructions
Prerequisites
.NET 6 or later
A compatible text editor or IDE, such as Visual Studio.
Running the Game
Clone the repository to your local machine:
git clone <repository-url>
cd EscapeRoomMVC
Build and run the project:
dotnet build
dotnet run
Saving and Loading
Saved games are stored as JSON files in the application directory.
Ensure that the application has write permissions for the directory.
Adding New Items
To extend the game with new items:

Create a new class inheriting from Item.
Implement specific interactions in the OnInteract method.
Add the new item to the room in the RoomInitializer class.
Example:
public class Lamp : Item
{
    public Lamp(int positionX, int positionY)
        : base("Lamp", "A small desk lamp. It doesn't seem to work.", false, positionX, positionY)
    {
        AddInteraction("Inspect");
    }

    public override void OnInteract(string interaction, Inventory inventory)
    {
        if (interaction == "Inspect")
        {
            Console.WriteLine("The lamp is dusty but has no bulb.");
        }
    }
}
Known Issues
Some interactions may not correctly refresh the map.
Ensure JSON save files are not manually edited to avoid deserialization errors.
Contributors
Patryk Dulkowski
Gracjan Czyżewski
