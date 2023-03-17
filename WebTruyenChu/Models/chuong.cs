namespace WebTruyenChu.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("chuong")]
    public partial class chuong
    {
        [Key]
        public int machuong { get; set; }

        public int? matruyen { get; set; }

        [Required]
        [StringLength(1000)]
        public string tenchuong { get; set; }

        [Required]
        [StringLength(2000)]
        [AllowHtml]
        public string noidungchuong { get; set; }

        public DateTime? ngaydangchuong { get; set; }

        public virtual truyen truyen { get; set; }
    }
}
