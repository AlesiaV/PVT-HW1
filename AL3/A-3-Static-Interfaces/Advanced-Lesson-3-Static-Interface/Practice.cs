using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Practice
    {
        /// <summary>
        /// AL3-P1/3. Создать класс UniqueItem c числовым полем Id. 
        /// Каждый раз, когда создается новый экземпляр данного класса, 
        /// его идентификатор должен увеличиваться на 1 относительно последнего созданного. 
        /// Приложение должно поддерживать возможность начать идентификаторы с любого числа. 
        /// </summary>
        public static void AL3_P1_3()
        {

            for (int i = 0; i < 50; i++)
            {
                PracticeID a = new PracticeID();
            }
            Console.WriteLine(PracticeID.id);
        }

        /// <summary>
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
        /// </summary>
        public static void AL3_P2_3()
        {

        }


        /// <summary>
        /// AL3-P3/3. Создайте обобщенный метод GuessType<T>(T item), 
        /// который будет принимать переменную обобщенного типа и выводить на консоль, 
        /// что это за тип был передан.
        /// </summary>
        public static void AL3_P3_3()
        {
            GuessType("Hello");
            GuessType(520);
            GuessType(42245.00);
            GuessType(DateTime.Now);
            GuessType("Привет31");
        }

        public static void GuessType<T>(T item)
        {
            switch (item)
            {
                //Вы передали строку длинной 5 символов.
                case string str when str.Length == 5:
                    Console.WriteLine($"You have passed a string of 5 characters: {str}"); 
                    break;
                //Вы передали положительное целое число.
                case int number when number > 0:
                    Console.WriteLine($"You passed a positive integer: {number}"); 
                    break;
                //Вы передали вещественное число с 5 значимыми цифрами.
                case double number when number.ToString().Where(x => x <= '9' && x >= '0').Count()==5:
                    Console.WriteLine($"You passed a real number with 5 significant digits: {number}");
                    break;
                //Вы передали время.
                case DateTime dateTime:
                    Console.WriteLine($"You passed the time: {dateTime}");
                    break;
                //Понятия не имею, что вы передали.
                default:
                    Console.WriteLine($"I have no idea what you conveyed: {item}");
                    break;
            }
        }

    }

    public class PracticeID
    {
        public static int id { get; private set; }
        public string name;

        public PracticeID()
        {
            id++;
        }

        static PracticeID()
        {
            id = 1000;
        }

    }
}
