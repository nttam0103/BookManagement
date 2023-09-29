using BookMan.ConsoleApp.Framework;
using System;
namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// class để thêm môt cuốn sách mới 
    /// </summary>
    public  class BookCreateView:ViewBase
    {
        public BookCreateView() { }
        /// <summary>
        /// yêu cầu người dùng  nhập từngt thông tin và lưu lại thông tin đó 
        /// </summary>
        public override void Render()
        {
            ViewHelp.WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);
            var title = ViewHelp.InputString("Title"); //đọc vào biến title            
            var authors = ViewHelp.InputString("Authors"); //đọc vào biến authors            
            var publisher = ViewHelp.InputString("Publisher"); //đọc vào biến publisher
            var year = ViewHelp.InputInt("Year"); // nhập giá trị cho biến year
            var edition = ViewHelp.InputInt("Edition"); // nhập giá trị cho biến edition
            var tags = ViewHelp.InputString("Tags");
            var description = ViewHelp.InputString("Description");
            var rate = ViewHelp.InputInt("Rate");
            var reading = ViewHelp.InputBool("Reading");
            var file = ViewHelp.InputString("File");

            var request =
                "do create ? " +
                $" Title = {title}" +
                $" & authors = {authors}" +
                $" & publisher = {publisher}" +
                $" & year = {year}" +
                $"& edition = {edition}" + 
                $" & tags = {tags}" + 
                $" & description = {description}" + 
                $"& rate = {rate}" + 
                $" & reading = {reading}" + 
                $"& file = {file}";
            Router.Forward(request);
        }
    }

}
