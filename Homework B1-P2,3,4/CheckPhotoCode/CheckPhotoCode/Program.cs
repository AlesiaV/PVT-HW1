using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPhotoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Есть ли среди поданных документов на визу Фотография ? " +
                               "\nЕсли да - введите 1, если нет - введите 0 ");

            int answer1 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (answer1 == 0) { Console.WriteLine("Сделайте новое фото в фотокомнате"); }
            else
            {
                Console.WriteLine("Сделано ли фото более 3-х месяцев назад ? " +
                       "\nЕсли да - введите 1, если нет - введите 0 ");


                int answer2 = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (answer2 == 1) { Console.WriteLine("Сделайте новое фото в фотокомнате"); }
                else
                {
                    Console.WriteLine("Использовалось ли это фото на паспорт ? " +
                             "\nЕсли да - введите 1, если нет - введите 0 ");

                    int answer3 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (answer3 == 1) Console.WriteLine("Сделайте новое фото в фотокомнате");
                    else
                    {
                        Console.WriteLine("Вклеено ли фото? " +
                                       "\nЕсли да - введите 1, если нет - введите 0 ");

                        int answer4 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (answer4 == 0) Console.WriteLine("Вклейте пожалуйста фото и пройдите на оплату");

                        else Console.WriteLine("Пройдите на оплату");
                    }
                }
            } 



            Console.ReadKey();



        }
    }
}
