namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Views;
    /// <summary>
    /// lớp điều khiểu, giúp nói dữ liệu sách với giao diện 
    /// </summary>
    internal class BookController
    {
        /// <summary>
        /// ghép nối dữ liệu 1  cuốn sách với giao diện hiển thị 1 cuốn 
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách </param>
        public void Single(int id) {
            Book model = new Book()
            {
                Id = 1,
                Authors = "Adam Freeman",
                Title = "Expert ASP.NET Web APT 2 fOR MVC Developers (The Expert's Voice in .NET)",
                Publisher = "Apress",
                Year = 2014,
                Tags = "c#, asp.net, mvc",
                Description = "Expert insight and understanding of how to create, customize, and deploy complex, flexible, and robust  HTTP Web services",
                Rating = 5, 
                Reading = true 
            };
            // Khởi tạo view 
            BookSingleView view = new BookSingleView(model);
            // gọi chương trình Render để thực hiện thị ta màn hình 
            view.Render();

        }
        public void Create()
        {
            BookCreateView view = new BookCreateView();
            view.Render();
        }
    }
}
