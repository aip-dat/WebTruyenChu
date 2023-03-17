using System.Data.Entity;

namespace WebTruyenChu.Models
{
    public partial class TruyenChuContext : DbContext
    {
        public TruyenChuContext()
            : base("name=TruyenChuContext")
        {
        }

        public virtual DbSet<chuong> chuongs { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<truyen> truyens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<theloai>()
                .Property(e => e.tenurl)
                .IsUnicode(false);

            modelBuilder.Entity<truyen>()
                .Property(e => e.hinh)
                .IsUnicode(false);
        }
    }
}
