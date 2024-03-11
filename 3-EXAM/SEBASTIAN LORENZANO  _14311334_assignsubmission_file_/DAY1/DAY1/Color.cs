namespace DAY1
{
    public class Color
    {
        public double r, g, b, a;

        public Color(double r, double g, double b, double a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        // Javi: MUY BIEN
        public override string ToString()
        {

            return  "(" + r + ", " + g + ", " + b + ", " + a + ")";

        }
    }
}
