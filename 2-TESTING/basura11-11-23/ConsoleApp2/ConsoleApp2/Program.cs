
namespace JuegoDeCombate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido al juego de combate!");

            int saludJugador = 100;
            int saludEnemigo = 80;
            bool jugadorActivo = true;

            while (saludJugador > 0 && saludEnemigo > 0)
            {
                Console.WriteLine("====================");
                Console.WriteLine($"Salud del jugador: {saludJugador}");
                Console.WriteLine($"Salud del enemigo: {saludEnemigo}");
                Console.WriteLine("====================");

                if (jugadorActivo)
                {
                    Console.WriteLine("¡Es tu turno!");
                    Console.WriteLine("Selecciona una acción:");
                    Console.WriteLine("1. Atacar");
                    Console.WriteLine("2. Defender");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion == 1)
                    {
                        Random random = new Random();
                        int ataque = random.Next(10, 20);
                        saludEnemigo -= ataque;
                        Console.WriteLine($"Has causado {ataque} puntos de daño al enemigo.");
                    }
                    else if (opcion == 2)
                    {
                        Console.WriteLine("Te has defendido. ¡Te has preparado para el próximo ataque!");
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Pierdes el turno.");
                    }
                }
                else
                {
                    Random random = new Random();
                    int ataqueEnemigo = random.Next(5, 15);
                    saludJugador -= ataqueEnemigo;
                    Console.WriteLine($"El enemigo te ha causado {ataqueEnemigo} puntos de daño.");
                }

                jugadorActivo = !jugadorActivo;
            }

            Console.WriteLine("====================");
            if (saludJugador <= 0)
            {
                Console.WriteLine("¡Has perdido! El enemigo te ha derrotado.");
            }
            else
            {
                Console.WriteLine("¡Felicidades! Has derrotado al enemigo.");
            }
            Console.WriteLine("====================");

            Console.WriteLine("¡Gracias por jugar!");
        }
    }
}