using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EscapeRoomMVC.Models.Items;

namespace EscapeRoomMVC.Helpers
{
    public class ItemJsonConverter : JsonConverter<Item>
    {
        public override Item Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected StartObject token");

            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = document.RootElement;

                string typeName = root.GetProperty("Type").GetString();
                int positionX = root.GetProperty("PositionX").GetInt32();
                int positionY = root.GetProperty("PositionY").GetInt32();

                return typeName switch
                {
                    nameof(Bookshelf) => new Bookshelf(positionX, positionY, null),
                    nameof(Chandelier) => new Chandelier(positionX, positionY),
                    nameof(Cobweb) => new Cobweb(positionX, positionY),
                    nameof(Desk) => new Desk(positionX, positionY),
                    nameof(Door) => new Door(positionX, positionY, root.GetProperty("Code").GetString()),
                    nameof(Journal) => new Journal(positionX, positionY),
                    nameof(Key) => new Key(positionX, positionY),
                    nameof(Painting) => new Painting(positionX, positionY),
                    _ => throw new JsonException($"Unknown item type: {typeName}")
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("Type", value.GetType().Name);
            writer.WriteNumber("PositionX", value.PositionX);
            writer.WriteNumber("PositionY", value.PositionY);

            if (value is Door door)
            {
                writer.WriteString("Code", door.Code);
            }

            writer.WriteEndObject();
        }
    }
}
