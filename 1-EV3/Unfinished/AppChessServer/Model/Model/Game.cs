using System;

namespace Model
{
    public class GameDB
    {
        public int codGame { get; set; }
        public int codUserWhites { get; set; }
        public int codUserBlacks { get; set; }
        public string gameJson {  get; set; } = string.Empty;
    }
}
