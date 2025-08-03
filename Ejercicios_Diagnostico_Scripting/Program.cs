using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool correcto = false;
            int[] chanse = new int[4];

            while (!correcto)
            {
                Console.WriteLine("Ingrese numero de chance (4 digitos)");

                string num = Console.ReadLine();

                if (num.Length == 4)
                {

                    char[] nums = num.ToCharArray();
                    Console.WriteLine(nums);
                    try
                    {
                        for (int i = 0; i < num.Length; i++)
                        {
                            chanse[i] = nums[i] - '0';
                            Console.WriteLine(chanse[i]);
                            correcto = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error");

                    }
                }


            }
            int apuesta = 0;
            correcto = false;
            while (!correcto)
            {

                try
                {
                    Console.WriteLine("igrese valor de la apuesta");
                    apuesta = Convert.ToInt32(Console.ReadLine());
                    correcto = true;
                }
                catch
                {

                }
            }
            Console.WriteLine(apuesta);


            Random random = new Random();
            int[] numGanador = new int[4];
            for (int i = 0; i < numGanador.Length; i++)
            {
                numGanador[i] = random.Next(0, 9);
            }
            Console.WriteLine("el numero ganador es" + numGanador[0] + numGanador[1] + numGanador[2] + numGanador[3]);
            int resultado = revisarApuesta(numGanador, chanse, apuesta);
            if (resultado == 0)
                Console.WriteLine("No es ganador");
            else Console.WriteLine("su premio es de: " + resultado);
        }

        static int revisarApuesta(int[] ganador, int[] balota, int apuesta)
        {
            bool[] coins = new bool[]{ false, false, false, false };
            int mult = 0;
            for (int i = 0; i < ganador.Length; i++)
            {
                if (ganador[i] == balota[i])
                    coins[i]=true;
            }
            if (coins[3] == true)
            {
                mult = 5;
                if (coins[2] == true)
                {
                    mult = 50;
                    if (coins[1] == true)
                    {
                        mult = 400;
                        if (coins[0] == true)
                        {
                            mult = 4500;
                        }

                    }

                }
            }
            if (mult < 200)
            {
                int count = 0;
                for (int i = 0; i < ganador.Length; i++)
                {
                    for(int j = 0; j < balota.Length; j++)
                    {
                        if (balota[j] == ganador[i])
                        {
                            count++;
                            balota[j] = 11;
                        }
                    }
                }
                if (count == 4)
                    mult = 200;
            }
            return apuesta*mult;
        }
    }
}