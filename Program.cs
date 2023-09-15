using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    using BookMan.ConsoleApp.DataServices;
    using BookMan.ConsoleApp.Framework;
    using Controllers;
    internal class Program
    {
      private  static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new SimpleDataAccess();
            BookController controller = new BookController(context);

            Router.Instance.Resgister("about", About);
            Router.Instance.Resgister("help", Help);
            while (true)
            {
                ViewHelp.Write("Request> ",ConsoleColor.Green);
                string request = Console.ReadLine();
                Router.Instance.Forward(request);
                Console.ReadLine();
            }
        }
        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER version 1.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by trongtam", ConsoleColor.Magenta);

        }
        private static void Help(Parameter parameter)
        {
            if(parameter == null)
            {
                ViewHelp.WriteLine("SUPPORTED COMMANDS:", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRouter(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd = <command> to get command details", ConsoleColor.Cyan);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}
