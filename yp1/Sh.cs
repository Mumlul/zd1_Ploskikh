using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp1
{
    internal class Sh
    {
        //поле класса
        private Dictionary<Product,int> products;


        //Свойства
        public Dictionary<Product, int> Products { get { return products; }
            set { } }

        //Поиск товара по имени
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

        //проверка что такое продукт существует
        public bool pr(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return true;
                }
            }
            return false;
        }


        //добавление кол-ва товара
        public void Dop(string productname,int count)
        {
            Product toSell = FindByName(productname);
            if (toSell != null)
            {
                
                    products[toSell] += count;
                
            }
           
           
        }

        //конструктоор
        public Sh()
        {
            products = new Dictionary<Product, int>();
        }
        //добавление продукта
        public void AddProduct(Product product,int count)
        {
            products.Add(product,count);
        }

        //Вывод всех продуктов
        public string  WriteAllProducts()
        {
            StringBuilder productList = new StringBuilder("Список продуктов:\n");
            foreach (var product in products)
            {
                if(product.Value>0)
                productList.AppendLine(product.Key.GetInfo() + " - Количество: " +product.Value);
            }
            return productList.ToString();
        }
        //Создание и добавление продукта
        public void CreateProduct(string name, decimal price,int count)
        {
            products.Add(new Product(name, price),count);
        }
        //Продажа продукта
        public string Sell(string ProductName,int count)
        {
            Product toSell = FindByName(ProductName);
            if (toSell != null)
            {
                if (products[toSell] > 0) 
                {
                    products[toSell]-=count; 
                    return $"Продано: {toSell.GetInfo()}";
                }
                else
                {
                    return "Товар закончился!";
                }
            }
            else
            {
                return "Товар не найден!";
            }
        }

        //Добавление товара в корзину
        public string Korzina(string productName, int count)
        {
            Product toSell = FindByName(productName);
            if (toSell != null)
            {
               
                if (count > products[toSell])
                {
                    return $"Недостаточно товара для продажи. Доступно: {products[toSell]}";
                }
                else
                {
                    products[toSell] -= count;
                    decimal totalPrice = toSell.Price * count;

                    return $"Добавлено в корзину: {toSell.GetInfo()} - Количество: {count} - Общая цена: {totalPrice}";
                }

                
            }
            else
            {
                return "Товар не найден!";
            }
        }
        
    }
}
