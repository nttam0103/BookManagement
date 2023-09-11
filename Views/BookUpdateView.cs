using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using BookMan.ConsoleApp.Framework;
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
            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green);
            ConsoleColor labelColor = ConsoleColor.Magenta, valueColor = ConsoleColor.White;
            //hiển thị giá trị cũ 
            ViewHelp.Write("Authors: ", labelColor);
            ViewHelp.WriteLine(Model.Authors, valueColor);

            //yêu cầu nhập giá trị mới 
            ViewHelp.Write("New value: ",labelColor);

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

      
        
    }
}
