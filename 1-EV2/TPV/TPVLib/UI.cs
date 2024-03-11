
namespace TPVLib
{
    public class UI
    {

        public static void ShowMainMenu(ITPV tpv)
        {
            Console.WriteLine("1- Products");
            Console.WriteLine("2- Tickets");
            Console.WriteLine("3- Summary");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("9- Save and Exit");

        }

        public static void ShowProductsMenu(ITPV tpv)
        {
            Console.WriteLine("1-Add Product");
            Console.WriteLine("2-Modify Product");
            Console.WriteLine("3-Delete Product");
            Console.WriteLine("");
            Console.WriteLine("5- Go Back to Main Menu");
            Console.WriteLine("6- Go to Tickets");
            Console.WriteLine("7- Go to Summary");
            Console.WriteLine("");
            Console.WriteLine("9- Save and Exit");
        }

        public static void ShowTicketsMenu(ITPV tpv)
        {
            Console.WriteLine("1- Products");
            Console.WriteLine("1-Add Ticket");
            Console.WriteLine("2-Change Ticket");
            Console.WriteLine("3-Delete Ticket");
            Console.WriteLine("");
            Console.WriteLine("5- Go to Products");
            Console.WriteLine("6- Go Back to Main Menu");
            Console.WriteLine("7- Summary");
            Console.WriteLine("");
            Console.WriteLine("9- Save and Exit");
        }

    }
}
