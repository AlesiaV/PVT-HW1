using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            // B6-P1/6. 1DReadConsoleMassive
            //ReadConsoleMassive();

            //B6-P2/6. 3DMassiveMaxInRow.
            //MassiveMaxInRow();

            //B6 - P3 / 6. 1DMasiveSort.
           //MassiveSort();

            //B6 - P4 / 6. * Pyatnashki.
            Pyatnashki();

            //B6-P5/6. CutString.
            //CutString();

            //B6-P6/6. ReplaceInPoem.
            //PoemExample();

            Console.ReadKey();
        }

        public static void ReadConsoleMassive()
        {
            int[] array = new int[6];
            int indexNumber = 1;

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Input {indexNumber} element of integer array: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
                ++indexNumber;
            }

            Console.Write("Array: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($" {array[i],2} ");
            }
        }

        public static void MassiveMaxInRow()
        {
            int[,] array2D = new int[3, 3] { { 10, 25, 3 }, { 126, 4, 87 }, { 42, 55, 1 } };
            int maxNumber = 0;
            int indexNumber = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array2D[i, j] > maxNumber)
                    {
                        maxNumber = array2D[i, j];
                    }
                }
                Console.WriteLine($"The MaxNumber of the {indexNumber} row of a 2D-array = {maxNumber}");
                ++indexNumber;
                maxNumber = 0;
            }
        }

        public static void MassiveSort()
        {
            int[] arrayForSort = new int[5];
            Random rnd = new Random();

            for (int i = 0; i < arrayForSort.Length; i++)
            {
                arrayForSort[i] = rnd.Next(100);
            }

            Console.WriteLine("Array for sorting: ");

            foreach (int element in arrayForSort)
            {
                Console.Write($"{element,3}");
            }

            Console.WriteLine("\nArray after sorting: ");
            int temp = 0;

            for (int i = 0; i < arrayForSort.Length; i++)
            {
                for (int sort = 0; sort < arrayForSort.Length - 1; sort++)
                {
                    if (arrayForSort[sort] > arrayForSort[sort + 1])
                    {
                        temp = arrayForSort[sort + 1];
                        arrayForSort[sort + 1] = arrayForSort[sort];
                        arrayForSort[sort] = temp;
                    }
                }
            }

            foreach (var item in arrayForSort)
            {
                Console.Write($"{item,3}");
            }
        }

        public static void Pyatnashki()
        {
            int[,] arr = new int[4, 4];
            int number = 1;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = number++;
                }
            }

            arr[3, 3] = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{arr[i, j],3}");
                }
                Console.Write("\n");
            }

            PlayPyatnashki(arr);
        }

        public static void PlayPyatnashki(int[,] arr)
        {
            int i_Zero = 3;
            int j_Zero = 3;

            while (true)
            {
                Console.Write("\nВведите символ WASD : 'W' - перемещение 0 вверх; 'A' - перемещение 0 влево;" +
                              "'S' - перемещение 0 вниз; 'D' - перемещение 0 вправо: ");
                var move = Console.ReadKey().KeyChar;
                Console.WriteLine();
                var i = i_Zero;
                var j = j_Zero;

                switch (move)
                {
                    case 'A':
                    case 'a':
                        j--;
                        break;
                    case 'S':
                    case 's':
                        i++;
                        break;
                    case 'D':
                    case 'd':
                        j++;
                        break;
                    case 'W':
                    case 'w':
                        i--;
                        break;
                    default:
                        break;
                }

                var tmp = arr[i, j];
                arr[i, j] = arr[i_Zero, j_Zero];
                arr[i_Zero, j_Zero] = tmp;

                i_Zero = i;
                j_Zero = j;

                for (int indexI = 0; indexI < 4; indexI++)
                {
                    for (int indexJ = 0; indexJ < 4; indexJ++)
                    {
                        Console.Write($"{arr[indexI, indexJ],3}");
                    }
                    Console.Write("\n");
                }

            }
        }

        public static void CutString()
        {
            Console.WriteLine("Input a sentence: ");
            string sentence = Console.ReadLine();
            int countSymbols = sentence.Length;
            string newSentence = "";

            if (countSymbols > 13)
            {
                for (int i = 0; i <= 13; i++)
                {
                    newSentence = sentence.Substring(0, 13) + "...";
                }
            }
            else newSentence = sentence;

            Console.WriteLine("New Sentence: ");

            foreach (var symbol in newSentence)
            {
                Console.Write($"{symbol}");
            }
        }


        public static void PoemExample()
        {
            Console.WriteLine("Введите стихотворение в одну строку, разделяя строки символом \";\"");
            string poem = Console.ReadLine();
            string[] result = poem.Split(new string [] { ";" }, StringSplitOptions.None);
            string newPoem = "";

            for (int i = 0; i < result.Length; i++)
            {
                var row = result[i];
                newPoem = row
                        .Replace('о', 'а')
                        .Replace("л", "ль")
                        .Replace("ть", "т");

                Console.WriteLine(newPoem);
            }
        }
    }
}



