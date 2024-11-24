using EscapeRoomMVC.Models;
using EscapeRoomMVC.Models.Items;

namespace EscapeRoomMVC0._3.Tests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void AddItem_ShouldAddItemToInventory()
        {
            // Arrange
            var inventory = new Inventory();
            var item = new Key(0, 0);

            // Act
            inventory.AddItem(item);

            // Assert
            Assert.IsTrue(inventory.HasItem("Klucz"));
        }

        [TestMethod]
        public void HasItem_ItemExists_ShouldReturnTrue()
        {
            // Arrange
            var inventory = new Inventory();
            var item = new Key(0, 0);
            inventory.AddItem(item);

            // Act
            bool result = inventory.HasItem("Klucz");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasItem_ItemNotExists_ShouldReturnFalse()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            bool result = inventory.HasItem("Klucz");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetItem_ItemExists_ShouldReturnItem()
        {
            // Arrange
            var inventory = new Inventory();
            var item = new Key(0, 0);
            inventory.AddItem(item);

            // Act
            var retrievedItem = inventory.GetItem("Klucz");

            // Assert
            Assert.IsNotNull(retrievedItem);
            Assert.AreEqual("Klucz", retrievedItem.Name);
        }

        [TestMethod]
        public void GetItem_ItemNotExists_ShouldReturnNull()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            var retrievedItem = inventory.GetItem("Klucz");

            // Assert
            Assert.IsNull(retrievedItem);
        }

        [TestMethod]
        public void PerformItemInteraction_ShouldOutputToConsole()
        {
            // Arrange
            var inventory = new Inventory();
            var item = new Key(0, 0);
            inventory.AddItem(item);

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            inventory.PerformItemInteraction(item, "Ogl¹daj");

            // Assert
            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("To ma³y mosiê¿ny klucz."));
        }

        [TestMethod]
        public void PerformItemInteraction_ShouldNotThrowExceptionForUnknownInteraction()
        {
            // Arrange
            var inventory = new Inventory();
            var item = new Key(0, 0);
            inventory.AddItem(item);

            // Act
            inventory.PerformItemInteraction(item, "Nieznana opcja");

            // Assert
            // Brak wyj¹tku jest wystarczaj¹cym dowodem poprawnoœci
        }

        [TestMethod]
        public void AddItem_ShouldNotAddDuplicateItem()
        {
            // Arrange
            var inventory = new Inventory();
            var item = new Key(0, 0);
            inventory.AddItem(item);

            // Act
            inventory.AddItem(item);

            // Assert
            Assert.AreEqual(1, inventory.GetItems().Count);
        }
    }
}