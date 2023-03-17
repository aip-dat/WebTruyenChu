namespace WebTruyenChu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("truyen")]
    public partial class truyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public truyen()
        {
            chuongs = new HashSet<chuong>();
        }

        [Key]
        public int matruyen { get; set; }

        public int? matheloai { get; set; }

        [Required]
        [StringLength(1000)]
        public string tentruyen { get; set; }

        [Required]
        [StringLength(1000)]
        public string hinh { get; set; }

        [Required]
        [StringLength(200)]
        public string tacgia { get; set; }

        [Required]
        [StringLength(2000)]
        public string mota { get; set; }

        public DateTime? ngaydangtruyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuong> chuongs { get; set; }

        public virtual theloai theloai { get; set; }
    }
}
