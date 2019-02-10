using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleImageProcessingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool input = true;
            while (input)
            {
                //Console.WriteLine("Enter the path to the folder with images:");
                //string pathDirectory = Console.ReadLine(); //D:\Изображения\
                string pathDirectory = @"D:\Изображения\";

                Console.WriteLine("\nPlease enter the command: ");
                Console.WriteLine("1 - renaming images according to shooting date;"); //переименование изображений в соответствии с датой съемки
                Console.WriteLine("2 - adding a mark to the image when the photo was taken;"); //добавление на изображение отметки, когда фото было сделано
                Console.WriteLine("3 - sorting images by folders by year;"); //сортировка изображений по папкам по годам
                Console.WriteLine("4 - sorting images by folder by location."); //сортировка изображений по папкам по месту съемки
                Console.Write("-> ");

                try
                {
                    BasicClass imagePr = null;
                    int command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            imagePr = new RenameImagesShootDate(pathDirectory, @"RenameImagesShootDate\");
                            break;
                        case 2:
                            imagePr = new AddMark(pathDirectory, @"AddMark\");
                            break;
                        case 3:
                            imagePr = new SortByYear(pathDirectory, @"SortByYear\");
                            break;
                        case 4:
                            imagePr = new SortByLocation(pathDirectory, @"SortByLocation\");
                            break;

                            //default:
                            //    Console.WriteLine("Please enter a correctly command!");
                            //    break;
                    }

                    imagePr.ImageProcessAppl();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a correctly command!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
