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
        public void Update(int id) {
            var model = new Book();
            var view = new BookUpdateView(model);
            view.Render();
        }
        /// <summary>
        /// Kích hoạt chức năng hiển thị danh sách 
        /// </summary>
        public void List()
        {
           /*
            Khai báo và khởi tạo một mảng, mỗi phần tử thuộc kiểu Bok 
           lệnh dưới đây khai báo và khởi tạo 1 mảng gồm 6 phần tử 
           mỗi phân tử thuộc kiểu book
           Do book là class, mỗi phần tử của mảng của phải được khai khởi tạo
           sử dụng từ khóa new tuong tự khởi tạo mọt object bình thừng
            */
            Book[] model = new Book[] { 
            new Book{Id=1, Title = "A new book 1"},
            new Book{Id=2, Title = "A new book 2"},
            new Book{Id=3,Title = "A new book 3"},
            new Book{Id=4, Title = "A new book 4"},
            new Book{Id=5, Title = "A new book 5"},
            new Book{Id=6,Title = "A new book 6"}
            };
            BookListView view = new BookListView(model);
            view.Render();
        }
    }
}
