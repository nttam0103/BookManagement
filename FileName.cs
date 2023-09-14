using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    internal class FileName
    {
        static void Main() {
            Console.WriteLine("Break");
            var i = 0;
            while (true)
            {
                if (i == 10)
                  break;
                Console.Write($"{i}\t");
                i++;
            }
            Console.WriteLine("Continue");
            var j = 0;
            do
            {
                j++;
                if (j == 5) continue;
                Console.Write($"{j}\t"); 
            } while (j < 10);
            Console.ReadLine();
        }
    }
}
