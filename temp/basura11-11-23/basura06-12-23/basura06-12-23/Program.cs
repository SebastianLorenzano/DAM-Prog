namespace basura06_12_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgendaTelefonos agendaTelefonos = new AgendaTelefonos();
            var pepe = agendaTelefonos.GetContactos();
            pepe.Clear();
            Console.WriteLine("Pepe estuvo aqui");
        }
    }
}