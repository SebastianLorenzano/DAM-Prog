using System;

namespace Model
{
    public class GameDB
    {
        public int Id { get; set; }
        public int PlayerWhiteId { get; set; }
        public int PlayerBlackId { get; set; }
        public string Board {  get; set; } = string.Empty;
    }
}
