namespace TestServer
{
    public class ErrorMessage
    {
        public int error_code { get; set; }
        public string message { get; set; }
    }

    public class Session
    {
        public string token { get; set; } = string.Empty;
    }

    public class Login
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class GameFormat
    {
        public int Id { get; set; } = -1;
        public string name { get; set; } = string.Empty;
    }

    /*
    public class GameFormatRespone
    {
        int errorCode;
        public List<GameFormat> formatList { get; set};
    }*/

}
