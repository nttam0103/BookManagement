using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    using BookMan.ConsoleApp.DataServices;
    using BookMan.ConsoleApp.Framework;
    using BookMan.ConsoleApp.Models;
    using Controllers;
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConfigRouter();
            while (true)
            {
                ViewHelp.Write("# Request >>> ", ConsoleColor.Green);
                string request = Console.ReadLine();
                Router.Instance.Forward(request);
                Console.WriteLine();
            }
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
        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER version 1.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by trongtam", ConsoleColor.Magenta);
        }
    }
}
