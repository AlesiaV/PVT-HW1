using System;

namespace B_3_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lesson.Examples();

            /*Console.WriteLine("Введите 1-ое число:");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2-ое число:");
            int secondNumber = Convert.ToInt32(Console.ReadLine());*/

            //Practice.B3_P1_9_NumbersAddition(firstNumber,secondNumber);

            /*Console.WriteLine("Введите Ваш результат вычисления:");
            int result = Convert.ToInt32(Console.ReadLine());*/

            //Practice.B3_P2_9_CheckResultAddition(firstNumber, secondNumber, result);

            //Practice.B3_P3_9_CheckResultAdditionWithTips(firstNumber, secondNumber, result);

            /*Console.WriteLine("Введите оператор '+' или '-' ");
            char operatorr = Convert.ToChar(Console.ReadLine());*/

            /*Console.WriteLine("Введите Ваш результат вычисления:");
            int result = Convert.ToInt32(Console.ReadLine());*/

            //Practice.B3_P4_9_CheckResultWithOperator(firstNumber, secondNumber, operatorr, result);

            //Practice.B3_P5_9_CheckResultWithAttemps(firstNumber, secondNumber, operatorr);

            /*int [] arrayNumbers = new int [5] ;
            int count = 1;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                Console.WriteLine($"Введите {count++}-е число:");
                arrayNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }*/

            //Practice.B3_P6_9_FiveNumbersAddition(arrayNumbers);

            //Practice.B3_P7_9_NumbersResultWithInfoIfCorrect(arrayNumbers);

            /*Console.WriteLine("Введите радиус круга:");
            float radius = Convert.ToInt32(Console.ReadLine());
            Practice.B3_P8_9_CircleArea(radius);*/

            Console.WriteLine("Введите сумму кредита:");
            float creditSum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите проценты кредита:");
            float creditPercent = Convert.ToInt32(Console.ReadLine());
            Practice.B3_P9_9_CreaditCalculator(creditSum, creditPercent);

            //Lesson.Examples();

            Console.ReadLine();
        }
    }
}
