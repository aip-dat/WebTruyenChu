using System.Collections.Generic;

namespace WebTruyenChu.Models
{
    public class HomeModel
    {
        public List<truyen> truyens { get; set; }
        public List<theloai> theloais { get; set; }
        public List<chuong> chuongs { get; set; }
    }
}