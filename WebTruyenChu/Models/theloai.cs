namespace WebTruyenChu.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("theloai")]
    public partial class theloai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public theloai()
        {
            truyens = new HashSet<truyen>();
        }

        [Key]
        public int matheloai { get; set; }

        [Required]
        [StringLength(300)]
        public string tentheloai { get; set; }

        [StringLength(200)]
        public string tenurl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<truyen> truyens { get; set; }
    }
}
