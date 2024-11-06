using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp1
{
    struct Song
    {
        //поля
        public string Author;
        public string Title;
        public string Filename;
        //конструктор
        public Song(string author, string title, string filename)
        {
            Author = author;
            Title = title;
            Filename = filename;
        }
    }
}
