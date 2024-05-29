using System;

namespace Model
{
    public class User
    {
        public long codUser { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dateRegister { get; set; } = DateTime.Now;
    }

    public class PieceDB
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ColorType Color { get; set; }
        public PieceType Type { get; set; }

    }
}
