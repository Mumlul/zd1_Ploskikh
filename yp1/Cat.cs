using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp1
{
    internal class Cat
    {
        //поля класса
        private string name;
        private double weight;
        //Свойство переменной name
        public string Name
        {
            get { return name; }
            set
            {
                bool pr = true;

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch)) pr = false;
                }

                if (pr) name = value;
                else
                {
                    name = "Вы ввели их не правильно";
                    Console.WriteLine("были введены цифры в имени поэтому имя не присвоено");
                } 
                   
            }
        }
        //Свойство переменной weight
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0 || value > 21)
                {
                    Console.WriteLine("Данынй число не может быть весом кота, поэтому будет 10");
                    weight = 10.3;
                }
                else weight = value;
            }
        }


        //конструктор класса
        public Cat(string cn,double w)
        {
            Name = cn;
            Weight = w;
        }

        //данный метод проверяет правильность введения имени кота
        public void Setcatname(string cn)
        {
            bool pr = true;

            foreach (var ch in cn)
            {
                if (!char.IsLetter(ch)) pr = false;
            }
            if (pr) name = cn;
            else Console.WriteLine("error");
        }

        //данный метод проверяет правильность введения веса кота
        public void Setweight(double w)
        {
            if (w <= 0 || w > 21)
            {
                Console.WriteLine("Данное число не может быть весом кота");
            }
            else weight = w;
        }

        //метод выводит данные кота
        public void Meow()
        {
            Console.WriteLine("имя кота:" + name);
            Console.WriteLine("вес кота:" + weight);
        }


    }
}

