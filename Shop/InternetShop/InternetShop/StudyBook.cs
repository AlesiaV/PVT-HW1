using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Books.StudyBook
{
    class StudyBook:Books
    {
        public StudyBook() { }
        public StudyBook(int id, string name): base(id, name)
        {
            this._idOfBook = id;
            this._name = name;
        }
        public StudyBook(int id, string name, string description, double price): this (id, name)
        {
            this._idOfBook = id;
            this._name = name;
            this._description = description;
            this._price = price;
        }

        public override void ShowAboutBook()
        {
            Console.WriteLine($"Книга {_name} - {_idOfBook} - {_description} - {_price}");
        }

        public static bool operator <(StudyBook book1, StudyBook book2)
        {
            return book1._price < book2._price;
        }

        public static bool operator >(StudyBook book1, StudyBook book2)
        {
            return book1._price > book2._price;
        }

        public static bool operator ==(StudyBook book1, StudyBook book2)
        {
            return book1._price == book2._price;
        }

        public static bool operator !=(StudyBook book1, StudyBook book2)
        {
            return book1._price != book2._price;
        }
    }
}
