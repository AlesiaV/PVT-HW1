using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Books
{
    abstract class Books:InternetShop
    {
        protected string _name;
        protected string _description;
        public double _price;

        public Books() { }
        public Books(int id, string name):base()
        {
            this._idOfBook = id;
            this._name = name;
        }

        public abstract void ShowAboutBook();
        

        public void AddOfBook()
        {

        }

        public void DeletOfBook()
        {

        }
    }
}
