namespace day2
{
    internal class Program
    {
        // Javi: 
        // Ejercicio 1: 10
        // Ejercicio 2: 10
        // Ejercicio 3: 9
        // Ejercicio 4: 10
        // Ejercicio 5: 6
        // Ejercicio 6: 9
        // Ejercicio 7: 8

        static void Main(string[] args)
        {
            Circle c = new Circle(new Point2D() { X = 10.0, Y = 10.0}, 10.0, "", new Color());
            var center = c.Center;

            Console.WriteLine("Hello, World!");
        }
    }
}
