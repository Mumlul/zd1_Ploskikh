using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace yp1
{
    internal class Product
    {
       //свойства класса
        public decimal Price { get; set; }
        public string Name { get; set; }


        //конструктор класса
        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        //получение данных о товаре
        public string GetInfo()
        {
                return $"Наименование: {Name}; Цена: {Price} руб.";
        }

        
    }
}
