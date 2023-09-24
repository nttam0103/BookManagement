using System;
using BookMan.ConsoleApp.Framework;
namespace BookMan.ConsoleApp.Views // namespace  cách đặt 
{
    using Models; // using bên trong namespace 
    /// <summary>
    /// Class để hiển thị một cuốn sách, chỉ sử dụng trng dự án (internal )
    /// </summary>
    public  class BookSingleView:ViewBase
    {
        public BookSingleView(Book model): base(model) { } 
        
        /// <summary>
        /// Thực hiện in thông tin ra màn hình console 
        /// </summary>
        public void Render()
        {
            if (Model == null)  // kiiểm tra xem object có dữ liệu không 
            {
               ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return; // Kết thức thực hiện phương thức (bỏ qua phần còn lại )
            }
           ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            // Chuyển đổi dữ liệu từ object ang book, chỉ áp dụng với kiểu class 
            var model = Model as Book;
            Console.WriteLine($"Authors:            {model.Authors}");
            Console.WriteLine($"Title:                  {model.Title}");
            Console.WriteLine($"Publisher:          {model.Publisher}");
            Console.WriteLine($"Year:                   {model.Year}");
            Console.WriteLine($"Edition:               {model.Edittion}");
            Console.WriteLine($"Isbn:                    {model.Isbn}");
            Console.WriteLine($"Tags:                   {model.Tags}");
            Console.WriteLine($"Description:        {model.Description}");
            Console.WriteLine($"Rating:                 {model.Rating}");
            Console.WriteLine($"Reading:                {model.Reading}");
            Console.WriteLine($"File:                       {model.File}");
            Console.WriteLine($"File Name:              {model.FileName}");
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
