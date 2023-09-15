using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
    /*Đây không phải là lệnh sử dụng không gia tên 
      * mà là tạo biệt danh cho một kiểu  dữ liệu 
      * ở đây đang tạ một biệt danh cho kiểu Dicticnary<string, ControllerAction >
      * trong cả file này có thể sử dụng tên kiểu RoutingTable 
      * thay cho Dictionnary<string, ControllerAction >
      * Lưu ý răng khai báo này nằm trực tiếp trong namepacse 
      */
    using RoutingTable = Dictionary<string, ControllerAction>;
    /// <summary>
    /// lưu ý khai báo delegate này là khái báo kiểu nằm trong namespace 
    /// delegate này đại diẹn cho tất cả các phướng thức có 
    /// - kiểu void 
    /// danh sách tham sso và là parameter 
    /// </summary>
    /// <param name="parameter"></param>
    public delegate void ControllerAction(Parameter parameter = null);

    /// <summary>
    /// Lớp cho phép ánh xạ truy vấn với phương thức 
    /// </summary>
    public class Router
    {
        //Nhóm 3 lệnh dưới đây biến Router thành mọt singleton 
        private static Router _instance;
        private Router()
        {
             _routingTable = new RoutingTable();
            _helpTable = new Dictionary<string, string>();
        }
        /*để ý : Constructor là private
          người sử dụng class thông qua property này để truy xuất các phương thức của class 
         chỉ khi nào _instance == null mới tạo object. Một khi đã tạo object, instance 
         sẻ không có giá trị null nữa 
         vì là biến static , _instance một khi khởi tạo sẻ tồn tại sướt chương trình */
        public static Router Instance =>_instance ?? (_instance = new Router());
        private readonly RoutingTable _routingTable;
        private readonly Dictionary<string, string> _helpTable;
        public string GetRouter()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var k in _routingTable.Keys)
                sb.AppendFormat("{0}, ", k);
                return sb.ToString();
        }
        public string GetHelp(string key )
        {
            if ( _helpTable.ContainsKey(key) )
                return _helpTable[key];
            else 
                return "Documentation not ready yet !";
        }
        /// <summary>
        ///  đăng ký mọt route, mỗi router ánh xạ một chuỗi truy vấn với một phương thức 
        /// </summary>
        /// <param name="route"></param>
        /// <param name="action"></param>
        /// <param name="help"></param>
        public void Resgister(string route, ControllerAction action, string help = "")
        {
            // nếu _routingTable đã chứa route này thì bỏ qua 
            if (!_routingTable.ContainsKey(route))
            {
                _routingTable[route] = action;
                _helpTable[route] = help;
            }
        }
        /// <summary>
        /// phân tích truy vấn và gọi phương thức tưong ứng với chuổi truy vấn 
        /// 
        /// </summary>
        /// <param name="request">chuổi truy vấn, bao gôm hai phần: param>
        /// <exception cref="Exception"></exception>
        public void Forward(string request)
        {
            var req = new Resquest(request);
            if (!_routingTable.ContainsKey(req.Route))
                throw new Exception("Command nt found");
            if (req.Parameter == null)
                _routingTable[req.Route]?.Invoke();
            else
                _routingTable[req.Route]?.Invoke(req.Parameter);
        }
        
        private class Resquest {
            /// <summary>
            /// thành phần của truy vấn 
            /// </summary>
           public string Route { get; private set; }
           /// <summary>
           /// thành phần tham số của truy vấn 
           /// </summary>
            public Parameter Parameter { get; private set; }
            public Resquest (string request)
            {
                Analyze(request); 
            }
            /// <summary>
            /// phân tích truy vấn để tách ra thành phần lệnh và thành phần tham só 
            /// </summary>
            /// <param name="request"></param>
            private void Analyze(string request)
            {
               // tìm xem trong chuổi truy vấn có tham số hay không 
               var firstIndex = request.IndexOf('?');
                // trường hợp truy vấn không chứa tham số 
                if (firstIndex < 0)
                {
                    Route = request.ToLower().Trim();
                }
                // Trường hợp truy vấn chưa tham số 
                else
                {
                    // nếu chuổi lối chỉ chứa tham số, không chứa route 
                    if (firstIndex <= 1) throw new Exception("Invaild request parameter");
                    // cắt chuổi truy vấn lấy mốc là ký tự ? 
                    // sau phép toán này thu được mảng 2 phần tử: thứ nhất là route, thứ hai là chuổi parameter 
                    var tokens = request.Split(new[] {'?' },2,StringSplitOptions.RemoveEmptyEntries);
                    // route là thành phần lệnh của truy vấn 
                    Route = tokens[0].Trim().ToLower();
                    //parameterPart là thành phần tham số của truy vấn 
                    var parameterPart = request.Substring(firstIndex);
                    Parameter = new Parameter(parameterPart);
                }
            }
        }

    }
}
