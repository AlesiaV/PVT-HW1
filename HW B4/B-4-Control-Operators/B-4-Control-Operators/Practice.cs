using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Lesson_4._1
{
    partial class Practice
    {
        //B4-P1/25. If_TimeOfDayGreeting
        public static void B4_P1_25_If_TimeOfDayGreeting()
        {
            double today = DateTime.Now.TimeOfDay.Hours;
            //Console.WriteLine(today);

            if (today >= 3 && today <= 9) Console.WriteLine("Good morning, Alesya!");
            else if (today >= 9 && today <= 15) Console.WriteLine("Good day, Alesya!");
            else if (today >= 15 && today <= 21) Console.WriteLine("Good evening, Alesya!");
            else Console.WriteLine("Good night, Alesya!");
        }

        //B4-P2/25. If_NumbersComparing
        public static void B4_P2_25_If_NumbersComparing()
        {
            Console.WriteLine($"Input number one:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Input number two:");
            int y = Convert.ToInt32(Console.ReadLine());

            if (x == y) Console.WriteLine("Numbers are equal.");
            else if (x > y) Console.WriteLine($"Number {x} more than number {y} on {x - y}");
            else Console.WriteLine($"Number {x} less than number {y} on {y - x}");

        }

        //B4-P3/25. If_PositiveNumbersComparing
        public static void B4_P3_25_If_PositiveNumbersComparing()
        {
            Console.WriteLine($"Input number one:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Input number two:");
            int y = Convert.ToInt32(Console.ReadLine());

            if ((x >= 0) && (y >= 0))
            {
                if (x == y) Console.WriteLine("Numbers are equal.");
                else if (x > y) Console.WriteLine($"Number {x} more than number {y} on {x - y}");
                else Console.WriteLine($"Number {x} less than number {y} on {y - x}");
            }
            else Console.WriteLine("Please, input positive numbers (greater than or equal to zero).");
        }

        //B4-P4/25. If_Akinator5Numbers
        public static void B4_P4_25_If_Akinator5Numbers()
        {
            Console.WriteLine($"Make a number from 1 to 5.");
            Console.WriteLine($"Is it an even number? Input 1 if YES, Input 0 if NO");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                Console.WriteLine($"Is this number 2? Input 1 if YES, Input 0 if NO");
                int answer2 = Convert.ToInt32(Console.ReadLine());
                if (answer2 == 1) Console.WriteLine("I guessed, thanks for the game.");
                else Console.WriteLine("This number is 4, thanks for the game.");
            }
            else
            {
                Console.WriteLine("Is this number greater than 3? Input 1 if YES, Input 0 if NO");
                int answer3 = Convert.ToInt32(Console.ReadLine());
                if (answer3 == 1)
                {
                    Console.WriteLine("This number is 5, thanks for the game.");
                }
                else
                {
                    Console.WriteLine("Is this number 3? Input 1 if YES, Input 0 if NO");
                    int answer5 = Convert.ToInt32(Console.ReadLine());
                    if (answer5 == 1) Console.WriteLine("I guessed, thanks for the game.");
                    else Console.WriteLine("This number is 1, thanks for the game.");
                }
            } 
        }   

        //B4-P5/25. Switch_DayOfWeek
        public static void B4_P5_25_Switch_DayOfWeek()
        {
            var today = DateTime.Today;
            var dayOfWeek = (int)today.DayOfWeek;
            switch (dayOfWeek - 1) {
                case 0:
                    Console.WriteLine("Доброго понедельника, Ольга");
                    break;
                case 1:
                    Console.WriteLine("Доброго вторника, Ольга");
                    break;
                case 2:
                    Console.WriteLine("Доброй среды, Ольга");
                    break;
                case 3:
                    Console.WriteLine("Доброго четверга, Ольга");
                    break;
                case 4:
                    Console.WriteLine("Доброй пятницы, Ольга");
                    break;
                case 5:
                    Console.WriteLine("Доброй субботы, Ольга");
                    break;
                case 6:
                    Console.WriteLine("Доброго воскресенья, Ольга");
                    break;
            }
        }

        //B4-P6/25. Switch_GameNavigation
        public static void B4_P6_25_Switch_GameNavigation()
        {
            Console.WriteLine("Выберите направление движения ирока:\n'W'- Вверх; 'S' - Вниз; 'A' - Влево; 'D' - Вправо." +
                               "\nСмените раскладку клавиатуры на Английскую (EN).");
            LabelStart:
            var buttom = Console.ReadKey();
            switch (buttom.KeyChar)
            {
                case 'W':
                case 'w':
                    Console.WriteLine("\nВерх");
                    break;
                case 'S':
                case 's':
                    Console.WriteLine("\nНиз");
                    break;
                case 'A':
                case 'a':
                    Console.WriteLine("\nЛево");
                    break;
                case 'D':
                case 'd':
                    Console.WriteLine("\nПраво");
                    break;
                default:
                    Console.WriteLine("\nВы Куда?");
                    break;
            }

            goto LabelStart;
        }

        //B4-P7/25. For_10OddEven
        public static void B4_P7_25_For_10OddEven()
        {
            Console.WriteLine("Output numbers from 1 to 10 with the definition of even or odd:\n");
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0) Console.WriteLine($"{i} - even number");
                else Console.WriteLine($"{i} - odd number");
            }
        }

        //B4-P8/25. For_3DevideNumbers
        public static void B4_P8_25_For_3DevideNumbers()
        {
            Console.WriteLine("Output numbers from 30 to 0, which are divided without a balance by 3:");
            for (int i = 30; i >= 0; i--)
            {
                if (i % 3 == 0) Console.Write($"{i} ");
            }
        }

        //B4-P9/25. For_Matrix10x10
        public static void B4_P9_25_For_Matrix10x10()
        {
            char [,] array = new char [10, 10];
            Console.WriteLine("Matrix10x10\n");
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    array[i, j] = 'A';
                }
            }
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        //B4-P10/25. For_HelloWorld
        public static void B4_P10_25_For_HelloWorld()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Hello, world!");
            }
        }


        //B4_P11/25. For_Afrochildren
        public static void B4_P11_25_For_Afrochildren()
        {
            for (int i = 10; i >= 0; i--)
            {
                if (i == 10)
                {
                    Console.WriteLine("Десять негритят отправились обедать ");
                }
                if (i == 9)
                {
                    Console.WriteLine("Один поперхнулся, их осталось девять.");
                    Console.WriteLine("Девять негритят, поев, клевали носом");
                }
                if (i == 8)
                {
                    Console.WriteLine("Один не смог проснуться, их осталось восемь.");
                    Console.WriteLine("Восемь негритят в Девон ушли потом,");
                }
                if (i == 7)
                {
                    Console.WriteLine("Один не возвратился, остались всемером. ");
                    Console.WriteLine("Семь негритят дрова рубили вместе,");
                }
                if (i == 6)
                {
                    Console.WriteLine("Зарубил один себя - и осталось шесть их.");
                    Console.WriteLine("Шесть негритят пошли на пасеку гулять,");
                }
                if (i == 5)
                {
                    Console.WriteLine("Одного ужалил шмель, их осталось пять.");
                    Console.WriteLine("Пять негритят судейство учинили,");
                }
                if (i == 4)
                {
                    Console.WriteLine("Засудили одного, осталось их четыре.");
                    Console.WriteLine("Четыре негритенка пошли купаться в море,");
                }
                if (i == 3)
                {
                    Console.WriteLine("Один попался на приманку, их осталось трое. ");
                    Console.WriteLine("Трое негритят в зверинце оказались,");
                }
                if (i == 2)
                {
                    Console.WriteLine("Одного схватил медведь, и вдвоем остались.");
                    Console.WriteLine("Двое негритят легли на солнцепеке,");
                }
                if (i == 1)
                {
                    Console.WriteLine("Один сгорел - и вот один, несчастный, одинокий.");
                    Console.WriteLine("Последний негритенок поглядел устало");
                }
                if (i == 0)
                {
                    Console.WriteLine("Он пошел повесился, и никого не стало.");

                }
            }

        }


        //B4-P12/25. For_Minus10OddEven
        public static void B4_P12_25_For_Minus10OddEven()
        {
            Console.WriteLine("Output numbers from 0 to -10 with the definition of even or odd:\n");
            for (int i = 0; i >= -10; i--)
            {
                if (i==0) Console.WriteLine($"{i} - ZERO");
                else if (i % 2 == 0) Console.WriteLine($"{i} - even number");
                else Console.WriteLine($"{i} - odd number");
            }
        }

        //B4-P13/25 For_LettersCount
        public static void B4_P13_25_For_LettersCount()
        {
            Console.Write("Input a word\n");
            string word = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i< word.Length; i++)
            {
                if (word[i] == 'а') counter += 1;
            }
            Console.WriteLine($"In the word \"{word}\" {counter} letters 'а'.");
        }

        //B4-P14/25 *For_AlphabetBack
        public static void B4_P14_25_For_AlphabetBack()
        {
            Console.Write("English alphabet in reverse order:\n");
            string arr = "";
            for (char i = 'A'; i <= 'Z'; i++)
            {
                arr += i;
            }
            char[] newArr = arr.ToCharArray();
            Array.Reverse(newArr);
            Console.WriteLine(newArr);
        }

        //B4-P15/25 While_OddEventNumber
        public static void B4_P15_25_While_OddEventNumber()
        {
            Console.WriteLine("Enter the number-range of 'X' to display even numbers from 1 to X:");
            int lastNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int firstNumber = 1;
            while (firstNumber <= lastNumber) 
            {
                if (firstNumber % 2 == 0) Console.Write($"{firstNumber} ");
                firstNumber++;
            }
        }


        //B4-P16/25 DoWhile_OddEventNumber
        public static void B4_P16_25_DoWhile_OddEventNumber()
        {
            Console.WriteLine("Enter the number-range of 'X' to display odd numbers from 1 to X:");
            int lastNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int firstNumber = 1;
            do
            {
                if (firstNumber % 2 != 0) Console.Write($"{firstNumber} ");
                firstNumber++;
            } while (firstNumber <= lastNumber);
        }

        //B4-P17/25 While_HelloWorld
        public static void B4_P17_25_While_HelloWorld()
        {
            int counter = 0;
            while (counter!=6)
            {
                Console.WriteLine("Hello, world!");
                counter++;
            }
        }

        //B4-P18/25 While_Multiplier
        public static void B4_P18_25_While_Multiplier()
        {
            Console.WriteLine("Enter a number for exponentiation");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter degree");
            int degree = Convert.ToInt32(Console.ReadLine());
            int counter = 1;
            int result = 1;
            while (counter <= degree)
            {
                result *= number;
                counter++;
            }
            Console.WriteLine($"Number {number} in degree {degree} = {result}");
        }

        //B4-P19/25 While_SolveNumberAdding
        public static void B4_P19_25_While_SolveNumberAdding()
        {
            Console.WriteLine("Solve equation \"2 + 2\"");
            //Console.WriteLine("Enter your result:");
            //int result = Convert.ToInt32(Console.ReadLine());
            bool varriable = true;
            while (varriable)
            {
                Console.WriteLine("Enter your result:");
                int result = Convert.ToInt32(Console.ReadLine());
                if (result == 4)
                {
                    varriable = false;
                    Console.WriteLine("You are right!");
                }
            }
        }


        //B4-P20/25 While_DiceGame
        public static void B4_P20_25_While_DiceGame()
        {
            int moves = 25;
            int ways = 0;
            while (ways <= moves)
            {
                Console.WriteLine("Enter a number from 1 to 6:");
                int number = Convert.ToInt32(Console.ReadLine());
                ways += number;

                if (ways <= moves) Console.WriteLine($"You are on {ways} cell.");
                else Console.WriteLine("Game over.");
            }
        }

        //B4-P21/25 *While_DiceGameMultiplePlayers
        public static void dB4_P21_25_While_DiceGameMultiplePlayers()
        {
            Console.WriteLine("First player\nInput your name:");
            string firstPl = Console.ReadLine();
            Console.WriteLine("Second player\nInput your name:");
            string secondPl = Console.ReadLine();
            Console.WriteLine();
            int moves = 25;
            int ways1 = 0;
            int ways2 = 0;
            while ((ways1 <= moves) && (ways2 <= moves))
            {
                Console.Write($"{firstPl}, enter a number from 1 to 6:");
                int number1 = Convert.ToInt32(Console.ReadLine());
                ways1 += number1;

                Console.Write($"{secondPl}, enter a number from 1 to 6:");
                int number2 = Convert.ToInt32(Console.ReadLine());
                ways2 += number2;
                
                if ((ways1 < moves) && (ways2 < moves))
                {
                    Console.WriteLine($"{firstPl}, you are on {ways1} cell.");
                    Console.WriteLine($"{secondPl}, you are on {ways2} cell.\n");
                }
                else if (ways1 >= moves)
                {
                    Console.WriteLine($"{firstPl}, you are won!!! Game over."); break;
                }
                else
                {
                    Console.WriteLine($"{secondPl}, you are won!!! Game over."); break;
                }
            }
        }

        //B4-P23/25 IfElse_Calcultor
        public static void B4_P23_25_IfElse_Calcultor()
        {
            Console.WriteLine("Введите 1-ое число:");
            double firstNm = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите 2-ое число:");
            double secondNm = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите арифметическую операцию (+, -, /, * ):");
            char operation = Convert.ToChar(Console.ReadLine());

            if (operation=='+')
                Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm + secondNm}.");
            else if (operation == '-')
                Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm - secondNm}.");
            else if (operation == '*')
                Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm * secondNm}.");
            else if (operation == '/')
                Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm / secondNm}.");
            else Console.WriteLine("Данные введены некорректно.");
        }


        //B4-P24_25 Switch_Calculator
        public static void B4_P24_25_Switch_Calculator()
        {
            Console.WriteLine("Введите 1-ое число:");
            double firstNm = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите 2-ое число:");
            double secondNm = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите арифметическую операцию (+, -, /, * ):");
            char operation = Convert.ToChar(Console.ReadLine());

            switch (operation)
            {
                case '+': Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm + secondNm}.");
                    break;
                case '-': Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm - secondNm}.");
                    break;
                case '*': Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm * secondNm}.");
                    break;
                case '/': Console.WriteLine($"{firstNm} {operation} {secondNm} = {firstNm / secondNm}.");
                    break;
                default:
                    Console.WriteLine("Данные введены некорректно.");
                    break;
            }
        }

        //B4-P25/25 Cycle_WordRevercse
        public static void B4_P25_25_Cycle_WordRevercse()
        {
            Console.WriteLine("Enter the word:");
            string word = Console.ReadLine();
            char[] newWord = word.ToCharArray();
            Array.Reverse(newWord);
            Console.WriteLine(newWord);
        }
    }
}
