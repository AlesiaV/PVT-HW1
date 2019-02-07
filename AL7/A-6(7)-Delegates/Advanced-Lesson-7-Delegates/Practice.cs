using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public class Practice
    {
        /// <summary>
        /// L7.P1. Переписать консольный калькулятор с использованием делегатов. 
        /// Используйте switch/case, чтоб определить какую математическую функцию.
        /// </summary>
        public static void L7P1_Calculator()
        {
            int number1 = 100;
            int number2 = 200;
            //OperationDel operationDel = null;
            Func<int, int, int> operationDel = null;

            switch (Console.ReadKey().KeyChar)
            {
                case '+':
                    operationDel = Sum;
                    break;
                case '-':
                    operationDel = Substruction;
                    break;
                default:
                    break;
            }

            int result = operationDel(number1, number2);
            Console.WriteLine($"\nResult: {result}");
        }
        //delegate int OperationDel(int a, int b);

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Substruction(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// L7.P2. Создать расширяющий метод для коллекции строк.
        /// Метод должен принимать делегат форматирующей функции для строки.
        /// Метод должен проходить по всем элементам коллекции и применять данную форматирующую функцию к каждому элементу.
        /// Реализовать следующие форматирующие функции:
        /// Перевод строки в заглавные буквы.
        /// Замена пробелов на подчеркивание.
        /// Продемонстрировать работу расширяющего метода.
        /// </summary>
        public static void L7P2_StringFormater()
        {
            List<string> strList = new List<string>
            {
                "Hello world!",
                "Good luck",
                "How are you?"
            };

            strList.StrExtension(ToUpper);
            ShowList(strList);

            strList.StrExtension(Replace);
            ShowList(strList);

            strList.StrExtension(Reverse);
            ShowList(strList);
        }

        public static void ShowList(List<string> strList)
        {
            foreach (var item in strList)
            {
                Console.WriteLine($"*{item}");
            }
            Console.WriteLine();
        }

        public static string ToUpper(string str) => str.ToUpper();
        public static string Replace(string str) => str.Replace(' ', '_');
        public static string Reverse(string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());
        }

    }
    public static class StringExtension
    {
        public static List<string> StrExtension(this List<string> strList, Func<string, string> funcStr)
        {
            for (int i = 0; i < strList.Count; i++)
            {
                strList[i] = funcStr(strList[i]);
            }
            return strList;
        }
    }
}
