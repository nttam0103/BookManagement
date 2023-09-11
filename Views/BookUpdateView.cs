using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    internal class BookUpdateView
    {
        protected Book Model;
        public BookUpdateView(Book model)
        {
            Model = model;
        }
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("UPDATE BOOK INFORMATION");
            Console.ResetColor();

            //hiển thị giá trị cũ 
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.Write("Authors: ");
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine(Model.Authors);

            //yêu cầu nhập giá trị mới 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("New value: ");
            Console.ResetColor();

            // đọc giá trị mới 
            var str = Console.ReadLine();
            /*
             nếu người dùng nhập enter luon (bỏ qua nhập dữ liệu) thì lấy lại giá trị cũ 
            của trường authors gán cho biến cục bộ authors 
            Nếu người dùng nhập giá trị mới thì biến cục bộ authors nhận giá trị này 
            Giá trị của biến authors về sau sẻ chuyển về controller để xử lý 
             */
            var authors = string.IsNullOrEmpty(str.Trim()) ? Model.Authors: str;
         
        }

        private void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor) Console.ResetColor();
        }
        private void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor) Console.ResetColor();
            {
                
            }
        }
        
    }
}
