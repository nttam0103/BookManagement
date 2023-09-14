using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Lưu các cặp khóa - giá trị người dùng nhập 
    /// chuổi tham sô cần viết ở dạng khóa = giá trị 
    /// nếu có nhiều tham ss thì viết tách bằng ký tự & 
    /// </summary>
    public class Parameter
    {
        private readonly Dictionary<string, string> _pairs = new Dictionary<string, string>();
       /// <summary>
       /// nạp chồn phép toán indexing []; cho phép truy xuất giá trị the kiểu biến [khoa ] = giá trị ;
       /// 
       /// </summary>
       /// <param name="key">khóa </param>
       /// <returns>giá trị tương ứng </returns>
        public string this[string key] // nập chồng phép toán indexing phải viết hai phưng thức get,set 
        {
            get
            {
                if (_pairs.ContainsKey(key))
                    return _pairs[key];
                else return null;
            } // phương thức get trả lại giá trị từ dictionary 
            set => _pairs[key] = value; // phương thức set gán giá trị  cho dictionaty 
        }
        /// <summary>
        /// Kiểm tra xem một khóa có trong dánhach tham số không 
        /// </summary>
        /// <param name="key">Khóa cần kiểm tra </param>
        /// <returns></returns>
        public bool ConstainsKey(string key)
        {
            return _pairs.ContainsKey(key);
        }
        /// <summary>
        /// nhận chuổi ký tự phân tích, chuyển thành cặp khóa - giá trị 
        /// </summary>
        /// <param name="parameter">chuỏi ký tự the quyt tắc khóa_1 = giá trị & khóa_2=giá trị2 </param>
        public Parameter(string parameter) 
        {
            // cắt chuổi theo mốc là ký tự &
            // kết quả của phép tán này là một mảng, mổi phần tử là mọt chuổi 
            var pairs = parameter.Split(new[] {'&'},StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var p = pair.Split('='); //cắt mỗi  phần tử là ký tự = 
                if (p.Length ==2)
                {
                    var key = p[0].Trim(); // phần tử thứ nhất là khóa 
                    var value = p[1].Trim(); // phần tử thứ hai là giá trị 
                    this[key] = value;// lưu cặp khóa giá trị này lại sử dụng phép tán indexing 
                    // củng có thể viết theo kiẻu kahcs, trực tiếp sử dụng biến _pái
                    ///_pairs[key] = value;
                }
            }
        }
    }
}
