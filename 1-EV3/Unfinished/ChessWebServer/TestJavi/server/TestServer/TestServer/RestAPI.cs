namespace TestServer
{
    public class RestAPI
    {
        public static List<GameFormat> GetAllGameFormats()
        {
            List<GameFormat> ret = new();
            {
                // Conexion a la base de datos para extraer la informacion
                // try catch y demas
                ret.Add(new GameFormat() { Id = 1, name = "Juego1" });
                ret.Add(new GameFormat() { Id = 2, name = "Juego2" });
                ret.Add(new GameFormat() { Id = 3, name = "Juego3" });
                ret.Add(new GameFormat() { Id = 4, name = "Juego4" });
                ret.Add(new GameFormat() { Id = 5, name = "Juego5" });
                ret.Add(new GameFormat() { Id = 6, name = "Juego6" });
            }
            return ret;
        }
    }
}
