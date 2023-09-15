using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Lớp cho phép ánh xạ truy vấn với phương thức 
    /// </summary>
    internal class Router
    {
        /// <summary>
        /// lớp xử lý truy vấn 
        /// </summary>
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
