namespace BookMan.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.DataServices;
    using Models;
    using Views;
    /// <summary>
    /// lớp điều khiểu, giúp nói dữ liệu sách với giao diện 
    /// </summary>
    internal class BookController
    {
        public Repository Repository;
        public BookController (SimpleDataAccess context)
        {
            Repository = new Repository (context);
        }
        /// <summary>
        /// ghép nối dữ liệu 1  cuốn sách với giao diện hiển thị 1 cuốn 
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách </param>
        public void Single(int id, string path ="") {
            var model = Repository.Select(id);
            // Khởi tạo view 
            BookSingleView view = new BookSingleView(model);
            // gọi chương trình Render để thực hiện thị ta màn hình 
            if (!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
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
        public void List(string path = "")
        {
            // lấy dữ liệu qua repository 
            var model = Repository.Select();
           // khởi tạo view 
            BookListView view = new BookListView(model);
            // gọi phương thức Render để phục vụ dự hiển thị ra màn hình 
            if(!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
            view.Render();
        }

    }
}
