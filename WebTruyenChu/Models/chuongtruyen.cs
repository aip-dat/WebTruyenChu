using System;
using System.Collections.Generic;

namespace WebTruyenChu.Models
{
    public class chuongtruyen
    {
        TruyenChuContext dbcontext = new TruyenChuContext();
        public int matruyen { get; set; }
        public string tentheloai { get; set; }
        public string tentruyen { get; set; }
        public string hinh { get; set; }
        public string tacgia { get; set; }
        public string mota { get; set; }

        public DateTime? ngaydangtruyen { get; set; }
        public List<chuong> mchuong { get; set; }
    }
}