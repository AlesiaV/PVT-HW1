using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
            loop:
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();
            Console.WriteLine("Choose print type: ");
            Console.WriteLine("1 - Console");
            Console.WriteLine("2 - File");
            Console.WriteLine("3 - Image");
            string type = Console.ReadLine();
            IPrinter printer3 = null;
            switch (type)
            {
                case "1":
                    Console.WriteLine("You have chosen printing into Console");
                    var printer1 = new ConsolePrinter(text, ConsoleColor.Blue);
                    printer1.Print(text);
                    break;
                case "2":
                    Console.WriteLine("You have chosen printing into File");
                    var printer2 = new FilePrinter(text, "Test");
                    printer2.Print(text);
                    break;
                case "3":
                    printer3 = new BitmapPrinter("File For Example");
                    Console.WriteLine("You have chosen printing into Image");
                    break;
                default:
                    Console.WriteLine("Wrong input. Repeat, please."); goto loop;
                    //break;
            }

            //Console.WriteLine("Write text:");

            //for (int i = 0; i < 5; i++)
            //{
            //    var textS = Console.ReadLine();
            //}
        }

        public interface IPrinter
        {
           void Print(string str);
        }

        //public abstract class Printer
        //{
        //    public string PrintingText { get; set; }
        //    public abstract void Print();
        //    public Printer(string str)
        //    {
        //        PrintingText = str;
        //    }
        //}

        public class ConsolePrinter : IPrinter
        {
            private ConsoleColor _color;

            public ConsolePrinter(string str, ConsoleColor color) /*: base (str)*/
            {
                _color = color;
            }
            public /*override*/ void Print(string str)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(str);
                Console.ResetColor();
            }
        }

        public class FilePrinter : IPrinter
        {
            private string _fileName;

            public FilePrinter(string str, string fileName) /*: base(str)*/
            {
                _fileName = fileName;
            }
            public /*override*/ void Print(string str)
            {
                System.IO.File.AppendAllText($@"D:\{_fileName}.txt", str);/*, PrintingText);*/
                //Console.WriteLine(PrintingText);
                Console.ResetColor();
            }
        }

        public class BitmapPrinter : IPrinter
        {
            public string FileName { get; }
            public BitmapPrinter(string fileName)
            {
                FileName = fileName;
            }
            public void Print(string str)
            {
                System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap(width: 1000, height: 1000);

                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                float x = 150.0F;
                float y = 50.0F;

                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                Graphics graphics = Graphics.FromImage(newBitmap);
                graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);

                newBitmap.Save($@"D:\{FileName}.png");
            }
        }
    }
}
