namespace BookMan.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.DataServices;
    using BookMan.ConsoleApp.Framework;
    using Models;
    using Views;
    /// <summary>
    /// lớp điều khiểu, giúp nói dữ liệu sách với giao diện 
    /// </summary>
    internal class BookController : ControllerBase
    {
        protected Repository Repository;
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
            Render(new BookSingleView(model), path);

        }
        public void Create( Book book =null)
        {
             if(book == null)
            {
                Render(new BookCreateView());
                return;
            }
             Repository.Insert(book);
            Success("Book created!");
        }
        public void Update(int id, Book book = null ) {
            if (book == null)
            {
                var model = Repository.Select(id);
              var view =  new BookUpdateView(model);
                Render(view);
                return;
            }
            Repository.Update(id, book);
            Success("Book updated !");
        }
        /// <summary>
        /// Kích hoạt chức năng hiển thị danh sách 
        /// </summary>
        public void List(string path = "")
        {
            // lấy dữ liệu qua repository 
            var model = Repository.Select();
            Render(new BookListView(model));
        }

    }
}
