using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Model
{
    public class GameDB
    {
        public long codGame { get; set; }
        public long codUserWhites { get; set; }
        public long codUserBlacks { get; set; }
        public string gameJson => JsonSerializer.Serialize(Board);
        [JsonIgnore] public Board Board { get; set; }
    }
}
