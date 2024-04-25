namespace Integral
{

    public class Integral
    {
        public delegate double MathFunction(double x);

        public static double CalculateArea(MathFunction f, double x0, double x1, double dx = 0.000001)
        {
            double result = 0;
            double x = x0;

            while (x <= x1)
            {
                double y = f(x);
                result += y * dx;
                x += dx;
            }
            return result;
        }

        static void Main(string[] args)
        {
            double integral = CalculateArea(x =>
            {
                return 2 * (x * x * x) + x;
            }, 0.0, 5.0);

            Console.WriteLine(integral);
        }


    }




    internal class Program
    {

    }
}
