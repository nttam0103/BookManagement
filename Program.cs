using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    using Controllers;
    internal class Program
    {
       
        static void Main(string[] args)
        {
            BookController controller = new BookController();
            controller.Single(0);
            Console.ReadKey();
        }
    }
}
