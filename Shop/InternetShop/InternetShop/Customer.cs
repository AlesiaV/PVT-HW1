using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Customer
{
    class Customer:InternetShop
    {
        
        protected string _name;
        protected string _surname;

        public Customer() { }
        public Customer(int id, string name, string surname):base(id)
        {
            this._idCustomer = id;
            this._name = name;
            this._surname = surname;
        }
    }
}
