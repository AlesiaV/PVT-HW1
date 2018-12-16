using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_3_Operators
{
    public partial class Practice
    {
        /// <summary>
        /// B3-P1/5. NumbersAddition. Напишите алгоритм, который складывает два числа.
        /// </summary>
        public static void B3_P1_9_NumbersAddition(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;
            Console.WriteLine($"Сумма чисел {firstNum} и {secondNum} равна {result}.");
        }

        /// <summary>
        /// B3-P2/9. CheckResultAddition. Изменить предыдущий алгоритм. 
        /// Пускай он теперь не выводит ответ сам. 
        /// А запрашивает ответ и потом проверяет его на правильность.
        /// </summary>
        public static void B3_P2_9_CheckResultAddition(int firstNum, int secondNum, int result)
        {
            int resultSum = firstNum + secondNum;
            Console.WriteLine(resultSum == result ? "Правильно": "Неправильно");
        }

        /// <summary>
        /// B3-P3/9. CheckResultAdditionWithTips. Изменить предыдущий алгоритм. 
        /// Пускай он теперь выводит не только информацию правильно или не правильно, 
        /// но и дополнительно, 	ожидается число больше или меньше указанного.
        /// </summary>
        public static void B3_P3_9_CheckResultAdditionWithTips(int firstNum, int secondNum, int result)
        {
            int resultSum = firstNum + secondNum;

            if (resultSum == result)
            {
                Console.WriteLine("Правильно");
            }

            else
            {
                if (!(resultSum == result))
                {
                    if (resultSum < result) Console.WriteLine("Неправильно. Ожидается число меньше указанного.");
                    else Console.WriteLine("Неправильно. Ожидается число больше указанного.");
                }
            };

        }

        /// <summary>
        /// B3-P4/9. CheckResultWithOperator. Изменить предыдущий алгоритм. 
        /// Пускай алгоритм теперь запрашивает оператор (+ или -).
        /// </summary>
        public static void B3_P4_9_CheckResultWithOperator(int firstNum, int secondNum, char operatorr, int result)
        {
            int resultExpression;

            if (operatorr=='+') resultExpression = firstNum + secondNum;
            else resultExpression = firstNum - secondNum;

            if (resultExpression == result)
            {
                Console.WriteLine("Правильно");
            }

            else
            {
                 if (resultExpression < result) Console.WriteLine("Неправильно. Ожидается число меньше указанного.");
                 else Console.WriteLine("Неправильно. Ожидается число больше указанного.");
            };
        }

        /// <summary>
        /// B3-P5/9. CheckResultWithAttemps. Изменить предыдущий алгоритм. 
        /// Пускай у пользователя будет 3 попытки чтобы решить эту задачу правильно
        /// </summary>
        public static void B3_P5_9_CheckResultWithAttemps(int firstNum, int secondNum, char operatorr)
        {
            int resultExpression;
            if (operatorr == '+') resultExpression = firstNum + secondNum;
            else resultExpression = firstNum - secondNum;

            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine("Введите Ваш результат вычисления:");
                int result = Convert.ToInt32(Console.ReadLine());

                if (resultExpression == result)
                {
                    Console.WriteLine("Правильно"); break;
                }

                else
                {
                    if (resultExpression < result) Console.WriteLine("Неправильно. Ожидается число меньше указанного.\n");
                    else Console.WriteLine("Неправильно. Ожидается число больше указанного.\n");
                };
            }
            
        }

        /// <summary>
        /// B3-P6/9. FiveNumbersAddition. Изменить предыдущий алгоритм. 
        /// Пускай алгоритм складывает пять чисел вместо двух.
        /// </summary>
        public static void B3_P6_9_FiveNumbersAddition(int [] arrNum)
        {
            int resultSum=0;
            for (int i = 0; i <5; i++)
            {
                resultSum += arrNum[i];
            }
           
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine("Введите Ваш результат вычисления:");
                int result = Convert.ToInt32(Console.ReadLine());

                if (resultSum == result)
                {
                    Console.WriteLine("Правильно"); break;
                }

                else
                {
                    if (resultSum < result) Console.WriteLine("Неправильно. Ожидается число меньше указанного.\n");
                    else Console.WriteLine("Неправильно. Ожидается число больше указанного.\n");
                };
            }
        }

        /// <summary>
        /// B3-P7/9. NumbersResultWithInfoIfCorrect. Изменить предыдущий алгоритм. 
        /// В конце алгоритма выводить информацию была ли задача решена правильно.
        /// </summary>
        public static void B3_P7_9_NumbersResultWithInfoIfCorrect(int[] arrNum)
        {
            int resultSum = 0;
            for (int i = 0; i < 5; i++)
            {
                resultSum += arrNum[i];
            }

            bool answer = false;

            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine("Введите Ваш результат вычисления:");
                int result = Convert.ToInt32(Console.ReadLine());

                if (resultSum == result)
                {
                    Console.WriteLine("Правильно"); answer = true; break;
                }

                else
                {
                    if (resultSum < result) Console.WriteLine("Неправильно. Ожидается число меньше указанного.\n");
                    else Console.WriteLine("Неправильно. Ожидается число больше указанного.\n");
                };
            }

            if (answer == true) { Console.WriteLine("Задача была решена правильно."); }
            else Console.WriteLine("Задача не была решена.");
        }

        /// <summary>
        /// B3-P8/9. CircleArea. Написать алгоритм, рассчитывающий площадь круга по заданному радиусу. 
        /// </summary>
        public static void B3_P8_9_CircleArea(float radius)
        {   
            const double numberP = 3.1415926535;
            double squareCircle = numberP * Math.Pow(radius, 2);
            Console.WriteLine($"Площадь круга с радиусом {radius} равна {squareCircle}.");
        }

        /// <summary>
        /// B3-P9/9. CreaditCalculator.Написать программу - калькулятор кредита на 1 год.
        /// </summary>
        public static void B3_P9_9_CreaditCalculator(float creditSum, float creditPercent)
        {
            float creditSumNew = creditSum;
            int month = 12;
            float[] arrPayments = new float[month];
            float mainDebt = creditSum / month;

            for (int i = 0; i < arrPayments.Length; i++)
            {
                float sumPercentBank = ((creditSumNew * creditPercent) / 100) / month;
                arrPayments[i] = mainDebt + sumPercentBank;
                creditSumNew -= mainDebt;
            }

            float sumPayments = 0;
            int count = 1;
            for (int i = 0; i < arrPayments.Length; i++)
            {
                
                Console.WriteLine($"{count++} месяц сумма платежа составит: {arrPayments[i]}");
                sumPayments += arrPayments[i];
            }

            Console.WriteLine($"\nОбщая сумма выплат составит {sumPayments}");
        }
    }
}
