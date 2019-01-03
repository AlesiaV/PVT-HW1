using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            //B7-P1/5. ArrayListPoemSort.
            //ArrayListPoemSort();

            //B7-P2/5. ArrayListOfSongsSort.
            //ArrayListOfSongsSort();

            //B7-P3/5. GenericListOfSongsSort
            //GenericListOfSongsSort();

            //B7-P4/5. GenericListOfNeighborSearch
            //GenericListOfNeighborSearch();

            //B7-P5/5. DictionaryOfNeighborSearch
            //DictionaryOfNeighborSearch();
            
            Console.ReadLine();
        }

        public static void ArrayListPoemSort()
        {
            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите {i + 1} строку стихотворения: ");
                arrayList.Add(Console.ReadLine());
            }

            arrayList.Sort();
            arrayList.RemoveAt(4);
            arrayList.ToArray();

            Console.WriteLine("Вывод массива объектов: ");

            foreach (var item in arrayList)
            {
                Console.WriteLine($"{item}");
            }
        }

        public static void ArrayListOfSongsSort()
        {
            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите {i + 1} строку стихотворения: ");
                arrayList.Add(new Song(Console.ReadLine()));
            }

            //arrayList.Sort();
            arrayList.RemoveAt(4);
            arrayList.ToArray();

            Console.WriteLine("Вывод массива объектов: ");

            foreach (var item in arrayList)
            {
                Console.WriteLine($"{item}"); //ошибка вывода, вместо введенной строки выводит Homework7.Song
            }
        }

        public static void GenericListOfSongsSort()
        {
            List<Song> arrayList = new List<Song>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите {i + 1} строку стихотворения: ");
                arrayList.Add(new Song(Console.ReadLine()));
            }

            //arrayList.Sort();
            arrayList.RemoveAt(4);
            arrayList.ToArray();

            Console.WriteLine("Вывод массива объектов: ");

            foreach (var Lyrics in arrayList)
            {
                Console.WriteLine($"{Lyrics}");
            }
        }

        public static void GenericListOfNeighborSearch()
        {
            List<Neighbor> floorNeighbors = new List<Neighbor>();

            //floorNeighbors.Add(new Neighbor("Иванов", "108", 2567489));
            //floorNeighbors.Add(new Neighbor("Семенов", "110", 2563356));
            //floorNeighbors.Add(new Neighbor("Петров", "111", 2560132));

            Console.WriteLine("Введите номер квартиры соседа вашего этажа (№108/110/111): ");
            string flat = Console.ReadLine();
            Console.WriteLine($"\nДанные соседа по номеру квартиры {flat}:\n{ floorNeighbors.Find(x => x.FlatNumber.Contains(flat))}");
        }

        public static void DictionaryOfNeighborSearch()
        {
            Dictionary<int, string> floorNeighbors = new Dictionary<int, string>();

            floorNeighbors.Add(108, "Иванов, тел.2567489");
            floorNeighbors.Add(110, "Семенов, тел.2563356");
            floorNeighbors.Add(111, "Петров,тел.2560132");

            Console.WriteLine("Введите номер квартиры соседа вашего этажа (№108/110/111): ");
            int flat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nДанные соседа по номеру квартиры {flat}:\n{ floorNeighbors[flat]}");
        }
    }
}
