using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace yp1
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Попытка выполнить код
            try
            {
                /*
                //ввод данных первого кота
                Console.WriteLine("Введите имя первого кота");
                string cn = Console.ReadLine();
                Console.WriteLine("Введите вес кота(цифрами)");
                double w = Convert.ToDouble(Console.ReadLine());
                //Создание объекта класса и заносим данные через конструктор
                Cat murzik = new Cat(cn, w);
                Console.WriteLine("_______________________________");
                //Перезаписываем данные для присовения их для второгог кота 
                Console.WriteLine("Введите имя второго кота");
                cn = Console.ReadLine();
                Console.WriteLine("Введите вес второго кота(цифрами)");
                w = Convert.ToDouble(Console.ReadLine());
                //Создаем второй объекта класса и занорсим данные через конструктор
                Cat barsik = new Cat(cn, w);
                //вывод данных о котах
                Console.WriteLine("_______________________________");
                murzik.Meow();
                Console.WriteLine("_______________________________");
                barsik.Meow();
                Console.WriteLine("_______________________________");
                //переопределение переменной name,weight второго обмекта 
                barsik.Name = "Барсик";
                barsik.Weight = 10;
                //вывод данных
                barsik.Meow();
                Console.WriteLine("_______________________________");
                barsik.Name = "1234";
                barsik.Meow();*/
                // Создаем экземпляр формы
                Shop myForm = new Shop();
                // Запускаем приложение Windows Forms
                Application.Run(myForm);

            }
            //Если была замечена ошибка неправильного ввода данных выполняется
            catch (FormatException)
            {
                Console.WriteLine("Вывели неправильное значение повторите попытку заного");
            }
           
        }
    }
}
