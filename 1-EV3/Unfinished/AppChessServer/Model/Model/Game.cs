using System;

namespace Model
{
    public class GameDB
    {
        public long codGame { get; set; }
        public long codUserWhites { get; set; }
        public long codUserBlacks { get; set; }
        public string gameJson {  get; set; } = string.Empty;
    }
}
