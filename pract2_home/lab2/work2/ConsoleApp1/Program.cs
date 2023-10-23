using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int[][] myArray = Input();
            Console.WriteLine("Исходный массив:");
            Print2(myArray);


            int[] rez = new int[myArray.Length];
            for (int i = 0; i < myArray.Length; ++i)
            {
                for (int j = 0; j < myArray.Length; j++)
                {
                    if (myArray[i][j] % 2 == 0)
                    {
                        rez[i] = myArray[i][j];
                    }
                }
            }

            Console.WriteLine("Последние четные элементы для строк:");
            Print1(rez);

            Console.ReadLine();
        }

        static int[][] Input()
        {
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[][] a = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                a[i] = new int[n];
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("a[{0},{1}]= ", i, j);
                    a[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return a;
        }

        static void Print1(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write("{0,5} ", a[i]);
        }

        static void Print2(int[][] a)
        {
            for (int i = 0; i < a.Length; ++i, Console.WriteLine())
                for (int j = 0; j < a[i].Length; ++j)
                    Console.Write("{0,5} ", a[i][j]);
        }

    }
}