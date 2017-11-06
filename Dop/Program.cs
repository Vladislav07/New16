using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dop
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement booksFromFile = XElement.Load(@"D:\Мои документы\AstraOut.xml");
            Console.WriteLine(booksFromFile);
            Console.ReadLine();
        }
    }
}
