namespace basura12_12_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher t = new("Juan", 1.0);

            Teacher t1 = new()
            {
                _name = "Juan",
                _gender = GenderType.OTHER
            }
                ;

        }
    }
}