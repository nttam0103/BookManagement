using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using BookMan.ConsoleApp.Framework;
    using Models;
    /// <summary>
    /// class để hiển thị danh sach Book 
    /// </summary>
    internal class BookListView:  ViewBase
    {
        public BookListView(Book[] model) : base(model) { }
        protected Book[] Model; // mảng của các object kiểu Book 
      
        /// <summary>
        /// in danh sách ra console 
        /// </summary>
        public void Render()
        {
            if (((Book[]) Model).Length == 0){
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE BOOKJ LIST");
            Console.ForegroundColor= ConsoleColor.Yellow;
            foreach(Book b in Model as Book[])
            {
                ViewHelp.Write($"[{b.Id}]",b.Reading ? ConsoleColor.DarkCyan);
            }
            Console.ResetColor();
        }
        public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving date to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!");
        }
    } 
}
