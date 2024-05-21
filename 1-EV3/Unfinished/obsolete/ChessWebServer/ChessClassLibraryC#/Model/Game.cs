using System;

namespace Model
{
    public class Game
    {
        public int Id { get; set; }
        public int PlayerWhiteId { get; set; }
        public int PlayerBlackId { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
        public string Resultado { get; set; }
    }
}
