using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop
{
    class InternetShop
    {
        protected int _idOfBook;
        protected int _idCustomer;

        public InternetShop() { }
        public InternetShop(int idCustomer)
        {
            this._idCustomer = idCustomer;
        }
    }
}
