
namespace Model
{
    public class AppModel
    {
        
        private static AppModel _app = new();
        public static AppModel Instance => _app;
        public Database Database => Database.Instance;


        private AppModel() 
        {
            
        }
    }
}
