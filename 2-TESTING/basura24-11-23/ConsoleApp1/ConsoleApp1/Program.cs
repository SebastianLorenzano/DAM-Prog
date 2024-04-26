using UDK;

namespace ConsoleApp1
{
    public class Program
    {
        /*
        public static rgba_f64 GetMedia(EditableImageHighPrecission source, int x, int y)
        {
            rgba_f64 result = new rgba_f64();

            for 


            return result;
        }
        public static void Filter(string fromPath, string toPath)
        {
            
            EditableImageHighPrecission source = new EditableImageHighPrecission(fromPath);
            EditableImageHighPrecission destination = new EditableImageHighPrecission(source.Width, source.Height);

            for (int y = 1; y < destination.Height - 1; y++)
            {
                for (int x = 1; x < destination.Width - 1; x++)
                {
                    destination[x, y] = Program.GetMedia(source, x, y);
                    //rgba_f64 color = source[x, y];
                    // 1 double media = (color.r + color.g + color.b) / 3;
                    //1 color.r = media;
                    //1 color.g = media;
                    //1 color.b = media;
                    ////destination[x, y] = color;
                    ////hsla_f64 hsl = color.ToHSL();
                    ////hsl.h += 0.9;
                    ////if (hsl.h > 1)
                    ////    hsl.h -= 1;
                    ////destination[x, y] = hsl.ToRGBA();
                    ///



                }
            }

            destination.SaveToFile(toPath);
        }*/


        static void Main(string[] args)
        {
            //Filter("C:\\Users\\seblor3\\Downloads\\ii3.png", "C:\\Users\\seblor3\\Downloads\\imagen3.3.png");

            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));


        }

    }
    }