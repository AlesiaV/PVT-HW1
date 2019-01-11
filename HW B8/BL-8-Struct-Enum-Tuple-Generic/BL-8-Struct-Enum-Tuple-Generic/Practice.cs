using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Practice
    {
        public static Random random = new Random();


        /// <summary>
        /// BL8-P1/3. Cоздать структуру 2DRectangle, которая будет содержать ширину, высоту и координату.
        /// </summary>
        public static void Lb8_P1_3()
        {
            var newRectangle = new Rectangle2D(24, 50, 15, 15);
            newRectangle.ShowStruct();
        }

        struct Rectangle2D
        {
            int width;
            int height;
            Coordinate coord;

            public Rectangle2D(int width, int height, int x, int y)
            {
                this.width = width;
                this.height = height;
                coord = new Coordinate(x, y);
            }

            public void ShowStruct()
            { 
                Console.WriteLine($"Width: {width}, height: {height}, coordinate X: {coord.x}, coordinate Y: {coord.y}\n");
            }
        }


        /// <summary>
        /// BL8-P2/3. Cоздать случайный массив квадратов с количеством элементов 100. 
        /// Используйте класс Random(10), чтоб установить значения сторон. 
        /// </summary>
        public static void Lb8_P2_3()
        {
            Rectangle2D[] arrayRectangles = new Rectangle2D[100];
         
            for (int i = 0; i < arrayRectangles.Length; i++)
            {
                int rndSideOfRectangle = random.Next(10);
                arrayRectangles[i] = new Rectangle2D(rndSideOfRectangle, rndSideOfRectangle, random.Next(10),
                random.Next(10));
            }

            Console.WriteLine($"Количество дубликатов: {arrayRectangles.Length - arrayRectangles.Distinct().Count()}.");
        }

        /// <summary>
        /// BL8-P3/3.Anonymous. Создать метод GetSongData, 
        /// который принимает обьекта типа Song и возвращает анонимный тип, 
        /// который содержит Title, Minutes, Seconds и AlbumYear. 
        /// </summary>
        public static void Lb8_P3_3_Anonymous()
        {            
        }
    }
}
