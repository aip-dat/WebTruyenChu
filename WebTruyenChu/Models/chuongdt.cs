using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyenChu.Models;
using System.Web.Mvc;

namespace WebTruyenChu.Models
{
    public class chuongdt
    {
        public int machuong { get; set; }

        public int? matruyen { get; set; }

        public string tenchuong { get; set; }

    
        [AllowHtml]
        public string noidungchuong { get; set; }

        public DateTime? ngaydangchuong { get; set; }
    }
}