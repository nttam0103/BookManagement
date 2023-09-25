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
    internal class BookListView: ViewBase<Book[]>
    {
        public BookListView(Book[] model) : base(model) { }
        /// <summary>
        /// in danh sách ra console 
        /// </summary>
        public  override void Render()
        {
            if (Model.Length == 0){
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE BOOKJ LIST");
            Console.ForegroundColor= ConsoleColor.Yellow;
            foreach(Book b in Model)
            {
                ViewHelp.Write($"[{b.Id}]", ConsoleColor.Green);
                ViewHelp.WriteLine ($"[{b.Title}]", b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
            }
            ViewHelp.WriteLine($"{Model.Length} item(s)", ConsoleColor.Green);
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
