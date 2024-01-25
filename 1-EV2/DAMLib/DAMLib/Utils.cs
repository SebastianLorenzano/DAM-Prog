
namespace DAMLib
{
    public class Utils
    {
        public static void Swap<T>(ref T a,ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }


        public static bool CuadraticFormula(double a, double b, double c,
                                            out double x1, out double x2)
        {
            x1 = double.NaN;
            x2 = double.NaN;
            if (a == 0)
                return false;
            double r = b * b - 4 * a * c;
            if (r < 0)
                return false;
            double root = Math.Sqrt(r);
            double denom = 1.0 / (2 * a);
            x1 = (-b + root) * denom;
            x2 = (-b - root) * denom;
            return x1 != double.NaN || x2 != double.NaN;
        }


        public static (double x1, double x2, bool exists) CuadraticFormulaWithTuple(double a, double b, double c)
        {
            double x1, x2;
            bool exists = CuadraticFormula(a, b, c, out x1, out x2);
            return (x1, x2, exists);

        }

    }
}
