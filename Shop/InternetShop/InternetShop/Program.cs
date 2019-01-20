using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop{
    class Program
    {
        static void Main(string[] args)
        {
            Books.FictionBook.FictionBook book1 = new Books.FictionBook.FictionBook() { _price = 25.30 };
            Books.FictionBook.FictionBook book2 = new Books.FictionBook.FictionBook() { _price = 50.10 };
            Books.StudyBook.StudyBook book3 = new Books.StudyBook.StudyBook() { _price = 11.20 };
            Books.StudyBook.StudyBook book4 = new Books.StudyBook.StudyBook() { _price = 11.20 };

            //для класса FictionBook
            if (book1._price > book2._price)
                Console.WriteLine($"Наибольная цена 1-ой книги: {book1._price}");
            else if (book1._price < book2._price)
                Console.WriteLine($"Наибольная цена 2-ой книги:: {book2._price}");
            else
                Console.WriteLine($"Цены обоих книг равны {book2._price}");

            //для класса StudyBook
            if (book3._price == book4._price)
                Console.WriteLine($"Цены обоих книг равны {book3._price}");

            Console.ReadLine();
            
        }
    }
}
