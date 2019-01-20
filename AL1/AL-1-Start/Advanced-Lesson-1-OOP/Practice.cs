using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_1_OOP
{
    public class Practice
    {
        /// <summary>
        /// A.L1.P1. Вывести матрицу (двумерный массив) отображающую площадь круга, 
        /// квадрата, равнобедренного треугольника со сторонами (радиусами) от 1 до 10.
        /// </summary>
        public static void A_L1_P1_OOP()
        {

            //Circle firstCircle = new Circle(3);
            //Circle secondCircle = new Circle(5);
            //Square firstSquare = new Square(2);
            //Square secondSquare = new Square(4);
            //Triangle firstTriangle = new Triangle(2, 5);
            //Triangle secondTriangle = new Triangle(5, 7);

            //var array = new Figure []{ firstCircle, secondCircle, firstSquare, secondSquare };
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine(array[i].CalcArea());
            //}

            Random rnd = new Random();
            Figure[,] figuresArray = new Figure[3, 10];

            for (int i = 0; i < figuresArray.GetLength(0); i++)
            {
                for (int j = 0; j < figuresArray.GetLength(1); j++)
                {
                    figuresArray[0, j] = new Circle(rnd.Next(1, 10));
                    figuresArray[1, j] = new Square(rnd.Next(1, 10));
                    figuresArray[2, j] = new Triangle(rnd.Next(1, 10), rnd.Next(1, 10));
                }
            }

            for (int i = 0; i < figuresArray.GetLength(0); i++)
            {
                for (int j = 0; j < figuresArray.GetLength(1); j++)
                {
                    Console.Write($"{Math.Round(figuresArray[i, j].CalcArea(), 3)} ");
                }
                Console.WriteLine();
            }
        }

        class Figure
        {
            public virtual double CalcArea()
            {
                throw new NotImplementedException();
            }
        }

        class Circle:Figure
        {
            private int rad;
            public Circle (int rad)
            {
                this.rad = rad;
            }

            public override double CalcArea()
            {
                return Math.PI * rad * rad;
            }
        }

        class Square:Figure
        {
            private int side;
            public Square(int side)
            {
                this.side = side;
            }

            public override double CalcArea()
            {
                return side * side;
            }
        }

        class Triangle : Figure
        {
            private int side;
            private int height;
            public Triangle(int side, int height)
            {
                this.side = side;
                this.height = height;
            }

            public override double CalcArea()
            {
                return 0.5 * side * height;
            }
        }

        /// <summary>
        /// A.L1.P6. Перегрузить следующие операторы для Transport <>,==/!= на базе физических размеров. 
        /// Продемонстрировать использование в коде. 
        /// </summary>
        public static void A_L1_P6_OperatorsOverloading()
        {
        }

        /// <summary>
        /// A.L1.P7.Перегрузить операторы<>,==/!=  для продаваемых вещей в интернет магазине на базе их цены. 
        /// Продемонстрировать использование в коде. 
        /// </summary>
        public static void A_L1_P7_OperatorsOverloading()
        {            
        }        
    }
}
