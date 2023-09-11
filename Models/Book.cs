namespace BookMan.ConsoleApp.Models
{
    /// <summary>
    /// Lớp mô tả sách điện tử 
    /// </summary>
    internal class Book
    {
        private int _id = 1;
        /// <summary>
        /// Số định danh duy nhất cho mỗi object 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { if (value >= 1) _id = value; }
        }

        private string _authors = "Unknow authors";
        /// <summary>
        /// Tên tác giả hoặc nhóm tác giả, Không nhận xâu rỗng 
        /// </summary>
        public string Authors
        {
            get { return _authors; }
            set { if (!string.IsNullOrEmpty(value)) _authors = value; } // không nhận xâu rỗng 
        }
        private string _title = "A new book";
        /// <summary>
        /// Tiêu đề sách, không nhận xâu rỗng 
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { if (!string.IsNullOrEmpty(value)) _title = value; }// không nhân xâu rỗng 
        }
        private string _publisher = "Unknow publisher";
        /// <summary>
        /// Nhà xuất bản, không nhận xâu rỗng 
        /// </summary>
        public string Publisher
        {
            get { return _publisher; }
            set { if (!string.IsNullOrEmpty(value)) _publisher = value; } // không nhận xâu rỗng 
        }
        private int _year = 2018;
        /// <summary>
        /// năm xuất bản, không nhỏ hơn 1950 
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { if (value >= 1950) _year = value; } //năm  không nhân giá trị  < 1950
        }
        private int _edittion = 1;
        /// <summary>
        /// Lần tái bản, khng nhỏ hơn 1 
        /// </summary>
        public int Edittion
        {
            get { return _edittion; }
            set { if (value >= 1) _edittion = value; } // không nhận giá trị  < 1 
        }
        /// <summary>
        /// mã số quốc tế 
        /// </summary>
        public string Isbn { get; set; } = "";
        /// <summary>
        /// Từ khóa mô tả nội dung / thể loại 
        /// </summary>
        public string Tags { get; set; } = "";
        /// <summary>
        /// Mô tả tóm tắt nội dung 
        /// </summary>
        public string Description { get; set; } = "A new book";
        private int _rating = 1;
        /// <summary>
        /// đánh giá cá nhân, nhận trí trị 1 đến 5 
        /// </summary>
        public int Rating
        {
            get { return _rating; }
            set { if (value >= 1 && value <= 5) _rating = value; }// nhận giá trị từ 1- 5 
        }
        /// <summary>
        /// đánh dấu đang đọc 
        /// </summary>
        public bool Reading { get; set; }
        /// <summary>
        /// file sách (gồm đường dẫn )
        /// </summary>
        private string _file;
        public string File
        {
            get { return _file; }
            set { if (System.IO.File.Exists(value)) _file = value; }//  nhận đường dẫn đúng 
        }
        /// <summary>
        /// File sách (không đường dẫn )
        /// </summary>
        public string FileName { get { return System.IO.Path.GetFileName(_file); } } // trả lại tên sách ngắn ngọn 

    }
}
