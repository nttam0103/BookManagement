namespace BookMan.ConsoleApp
{
    using Models;
    using Controllers;
    using Framework;
    using BookMan.ConsoleApp.DataServices;

    internal partial class Program
    {
        private static void ConfigRouter()
        {
            SimpleDataAccess context = new SimpleDataAccess();
            BookController controller = new BookController(context);

            Router r = Router.Instance;
            r.Resgister("about", About);
            r.Resgister("help", Help);
            r.Resgister(route: "create",
                action: p => controller.Create(),
                help: "[create]\n\n Nhập danh sách mới ");
            r.Resgister(route: "do create",
                action: p => controller.Create(toBook(p)),
                help: "This route should be used only in code ");
            r.Resgister(route: "list",
                action: p => controller.List(),
                help: "[list] \r Hiển thị danh sách ");
            r.Resgister(route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path =<value>] \r hiển thị tất cả danh sách ");
            r.Resgister(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id = <valuar>]  \r hiển thị một cuốn danh sach theo id ");
            r.Resgister(route: "single file",
                action: p => controller.Single(p["id"].ToInt(), p["path"]),
                help: "[single file ? id = <value> & path = <value>]");
            r.Resgister(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "[update ? id = <value>] \r\n Tìm và cập nhật dữ liệu");
            r.Resgister(route: "do update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "this route should be used only in code" );

            #region helper 
            Models.Book toBook(Parameter p)
            {
                var b = new Models.Book();
                if (p.ConstainsKey("id")) b.Id = p["id"].ToInt();
                if (p.ConstainsKey("authors")) b.Author = p["authors"];
                if (p.ConstainsKey("title")) b.Title = p["title"];
                if (p.ConstainsKey("publisher")) b.Publisher = p["publisher"];
                if (p.ConstainsKey("year")) b.Year = p["year"].ToInt();
                if (p.ConstainsKey("edittion ")) b.Edittion = p["edittion"].ToInt();
                if (p.ConstainsKey("isbn")) b.Isbn = p["isbn"];
                if (p.ConstainsKey("tags")) b.Tags = p["tags"];
                if (p.ConstainsKey("description")) b.Description = p["description"];
                if (p.ConstainsKey("file")) b.File = p["file"];
                if (p.ConstainsKey("rate")) b.Rating = p["rate"].ToInt();
                if (p.ConstainsKey("reading")) b.Reading = p["reading"].ToBool();

                return b;
            }
            #endregion

        }
    }
}