namespace ejercicios_1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ingrese segundos");
            int segundos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(FormatoHoras(segundos));
            Console.WriteLine("Ingrese el número de términos de Fibonacci:");
            int n = int.Parse(Console.ReadLine());

            ImprimirFibonacciPrimos(n);
        }
        static string FormatoHoras(int totalSegundos)
        {
            int horas = totalSegundos / 3600;
            int minutos = (totalSegundos % 3600) / 60;
            int segundos = totalSegundos % 60;

            return ($"{horas}:{minutos}:{segundos}");
        }
        static void ImprimirFibonacciPrimos(int n)
        {
            int a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                int actual = a;

                if (EsPrimo(actual))
                    Console.WriteLine(actual);

                int siguiente = a + b;
                a = b;
                b = siguiente;
            }
        }

        static bool EsPrimo(int numero)
        {
            if (numero < 2) return false;
            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }
    }
}
