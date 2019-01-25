using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public abstract class Skin
    {
        public abstract void Clear();                 //очистка экрана плеера
        public abstract void Render(string text);     //вывод строки на экран плеера
    }

    public class ClassicSkin : Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ColorSkin1 : Skin
    {
        private ConsoleColor Color { get; set; }

        public ColorSkin1(ConsoleColor color)
        {
            Color = color;
        }

        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class ColorSkin2 : Skin
    {
        public override void Clear()
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write('\u058D');
            }

            //Console.WriteLine(new string('\u058d', 30));  укороченная запись
        }

        //Random rndColor = new Random();

        //private ConsoleColor GetRandomConsoleColor()
        //{
        //    var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        //    return (ConsoleColor)consoleColors.GetValue(rndColor.Next(consoleColors.Length));
        //}

        public override void Render(string text)
        {
            Random rndColor = new Random();
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            Console.ForegroundColor = (ConsoleColor)consoleColors.GetValue(rndColor.Next(consoleColors.Length));
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class Capsule : Skin  //вывод текста Капслоком
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            string newText = text.ToUpper();
            Console.WriteLine(newText);
        }
    }
}
