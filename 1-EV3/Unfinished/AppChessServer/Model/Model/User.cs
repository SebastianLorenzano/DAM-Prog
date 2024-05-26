using System;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateRegister { get; set; } = DateTime.Now;
    }

    public class PieceDB
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ColorType Color { get; set; }
        public PieceType Type { get; set; }

    }
}
