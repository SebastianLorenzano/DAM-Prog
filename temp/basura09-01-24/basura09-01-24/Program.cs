namespace basura09_01_24
{
    public class Caso1
    {
        private string _name;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

    public class Caso2
    {
        private string _name;
        public string Name => _name;
    }

    public class Caso3 /* Se crea la variable pero no podes manejarla ni verla*/
    {
        public string Name
        {
            get;
            set;
        }
    }
}