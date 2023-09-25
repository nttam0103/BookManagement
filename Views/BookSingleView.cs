using System;
using BookMan.ConsoleApp.Framework;
namespace BookMan.ConsoleApp.Views // namespace  cách đặt 
{
    using Models; // using bên trong namespace 
    /// <summary>
    /// Class để hiển thị một cuốn sách, chỉ sử dụng trng dự án (internal )
    /// </summary>
    public  class BookSingleView: ViewBase<Book>
    {

        public BookSingleView(Book model): base(model) { } 
        
        /// <summary>
        /// Thực hiện in thông tin ra màn hình console 
        /// </summary>
        public override void Render()
        {
            if (Model == null)  // kiiểm tra xem object có dữ liệu không 
            {
               ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return; 
            }
           ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            Console.WriteLine($"Authors:            {Model.Authors}");
            Console.WriteLine($"Title:                  {Model.Title}");
            Console.WriteLine($"Publisher:          {Model.Publisher}");
            Console.WriteLine($"Year:                   {Model.Year}");
            Console.WriteLine($"Edition:               {Model.Edittion}");
            Console.WriteLine($"Isbn:                    {Model.Isbn}");
            Console.WriteLine($"Tags:                   {Model.Tags}");
            Console.WriteLine($"Description:        {Model.Description}");
            Console.WriteLine($"Rating:                 {Model.Rating}");
            Console.WriteLine($"Reading:                {Model.Reading}");
            Console.WriteLine($"File:                       {Model.File}");
            Console.WriteLine($"File Name:              {Model.FileName}");
        }
      public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}' ");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject( Model );
            System.IO.File.WriteAllText( path, json );
            ViewHelp.WriteLine("Done");
        }
    }
}
