using EscapeRoomMVC.Models;
using EscapeRoomMVC.Models.Items;

namespace EscapeRoomMVC0._3.Tests
{
    [TestClass]
    public class RoomTests
    {
        private const string TestMapFile = "test_map.txt";
        private const string TestLegendFile = "test_legend.txt";

        [TestInitialize]
        public void Setup()
        {
            // Przygotowanie pliku mapy
            File.WriteAllText(TestMapFile, "#####\n#...#\n#####");
            // Przygotowanie pliku legendy
            File.WriteAllText(TestLegendFile, "# - Ściana\n. - Przejście");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Usunięcie plików testowych
            if (File.Exists(TestMapFile)) File.Delete(TestMapFile);
            if (File.Exists(TestLegendFile)) File.Delete(TestLegendFile);
        }

        [TestMethod]
        public void LoadMapFromFile_MapFileExists_ShouldLoadMap()
        {
            // Arrange
            var room = new Room("TestRoom", TestMapFile, TestLegendFile);

            // Act
            var mapContent = room.AsciiMap;

            // Assert
            Assert.AreEqual("#####\n#...#\n#####", mapContent);
        }

        [TestMethod]
        public void LoadMapFromFile_MapFileNotExists_ShouldSetDefaultMessage()
        {
            // Arrange
            var room = new Room("TestRoom", "nonexistent_map.txt", TestLegendFile);

            // Act
            var mapContent = room.AsciiMap;

            // Assert
            Assert.AreEqual("Mapa nie jest dostępna.", mapContent);
        }

        [TestMethod]
        public void LoadLegendFromFile_LegendFileExists_ShouldLoadLegend()
        {
            // Arrange
            var room = new Room("TestRoom", TestMapFile, TestLegendFile);

            // Act
            var legendContent = room.Legend;

            // Assert
            Assert.AreEqual("# - Ściana\n. - Przejście", legendContent);
        }

        [TestMethod]
        public void LoadLegendFromFile_LegendFileNotExists_ShouldSetDefaultMessage()
        {
            // Arrange
            var room = new Room("TestRoom", TestMapFile, "nonexistent_legend.txt");

            // Act
            var legendContent = room.Legend;

            // Assert
            Assert.AreEqual("Legenda nie jest dostępna.", legendContent);
        }

        [TestMethod]
        public void AddItem_ShouldAddItemToRoom()
        {
            // Arrange
            var room = new Room("TestRoom", TestMapFile, TestLegendFile);
            var item = new Key(1, 1);

            // Act
            room.AddItem(item);

            // Assert
            Assert.AreEqual(1, room.Items.Count);
            Assert.AreEqual(item, room.Items[0]);
        }
    }
}
