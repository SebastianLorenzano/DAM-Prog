using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Model
{
    public class PieceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Piece);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string type = jo["Type"].Value<string>();

            Piece piece;
            switch (type)
            {
                case "Pawn":
                    piece = new Pawn();
                    break;
                case "Rook":
                    piece = new Rook();
                    break;
                default:
                    throw new Exception($"Unknown piece type: {type}");
            }

            serializer.Populate(jo.CreateReader(), piece);
            return piece;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
