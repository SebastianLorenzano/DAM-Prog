using System.Drawing;

namespace DAY1
{
    public class CanvasConsole : ICanvas
    {
        public int Width { get; set; }


        public int Height { get; set; }

        public Color CurrentColor { get; set; }


        public CanvasConsole() 
        {
            CurrentColor = new Color(0, 0, 0, 0);
        }

        public void DrawCircle(Rect2D rect)
        {
            if (rect.IsValid())
                Console.WriteLine("Pintando un círculo de color " + CurrentColor.ToString() + " en el rectangulo " + rect.ToString());
        }

        public void DrawPolygon(Point2D[] points)
        {
            string pointsToString = "(";
            for (int i = 0; i < points.Length; i++) 
            { 
                if (points[i] == null)
                {
                    Console.WriteLine("Uno de los puntos del Polinomio es nulo. No se ha podido dibujar el Polinomio.");
                    return;
                }
                pointsToString += " " + points[i].ToString() + "";
            }
            pointsToString += ")";
            Console.WriteLine("Pintando un polinomio de color " + CurrentColor.ToString() + " con los puntos " + pointsToString);

        }

        public void DrawRectangle(Rect2D rect)
        {
            if (rect.IsValid())
                Console.WriteLine("Pintando un rectangulo de color " + CurrentColor.ToString() + " en las coordenadas " + rect.ToString());
        }
        public void SetColor(Color color)
        {
            if (color != null)
                CurrentColor = color;
        }
    }
}
