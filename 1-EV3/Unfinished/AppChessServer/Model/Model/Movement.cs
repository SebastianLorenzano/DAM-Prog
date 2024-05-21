using System;

namespace Model
{
    public class Movement
    {
        public int Id { get; set; } // Should I work with an Id or with a pk gameId MovementNumber??
        public int gameId { get; set; }
        public int MovementNumber { get; set; }
        //public int JugadorId { get; set; } // Doesn't seem necessary
        public string MovimientoTexto { get; set; }
        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;
    }
}
