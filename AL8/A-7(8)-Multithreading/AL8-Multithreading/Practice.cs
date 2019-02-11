using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Lesson_6_Multithreading
{
    class Practice
    {
        /// <summary>
        /// LA8.P1/5. Написать консольные часы, которые можно останавливать и запускать с 
        /// консоли без перезапуска приложения.
        /// </summary>
        public static void LA8_P1_5()
        {
            var timeThread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine(DateTime.Now);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            });
            timeThread.Start();
            while (true)
            {
                var key = Console.ReadKey().KeyChar;
                if (key == '1')
                {
                    timeThread.Suspend();
                }

                if (key == '2')
                {
                    timeThread.Resume();
                }

            }
            //while(true)
            //{
            //    Console.WriteLine(DateTime.Now);
            //    System.Threading.Thread.Sleep(1000);
            //    Console.Clear();
            //}
        }

        /// <summary>
        /// LA8.P2/5. Написать консольное приложение, которое “делает массовую рассылку”. 
        /// </summary>
        public static void LA8_P2_5()
        {
            for (int i = 0; i <= 50; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                //var thread = new Thread(() =>
                {
                    using (StreamWriter adapter = new StreamWriter($@"D:\BulkMailings\{i}.txt", true))
                    {
                        adapter.WriteLine("\nHello World! :)");
                    }
                });
                //thread.Start();
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Написать код, который в цикле (10 итераций) эмулирует посещение 
        /// сайта увеличивая на единицу количество посещений для каждой из страниц.  
        /// </summary>
        public static void LA8_P3_5()
        {
        }

        /// <summary>
        /// LA8.P4/5. Отредактировать приложение по “рассылке” “писем”. 
        /// Сохранять все “тела” “писем” в один файл. Использовать блокировку потоков, чтобы избежать проблем синхронизации.  
        /// </summary>
        public static void LA8_P4_5()
        {
            var obj = new Object();

            for (int i = 0; i <= 50; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    lock (obj)
                    {
                        using (StreamWriter adapter = new StreamWriter($@"D:\BulkMailings\{i}.txt", true))
                        {
                            adapter.WriteLine("\nHello World! :)");
                        }
                    }
                });
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// LA8.P5/5. Асинхронная “отсылка” “письма” с блокировкой вызывающего потока 
        /// и информировании об окончании рассылки (вывод на консоль информации 
        /// удачно ли завершилась отсылка). 
        /// </summary>
        public async static void LA8_P5_5()
        {
            string mail = "Hello World! :)";
            bool information = await SmptServer.SendEmail(mail);

            Console.WriteLine($"SendEmail: {information}");
        }
    }
}

