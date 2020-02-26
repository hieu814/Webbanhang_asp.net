namespace WebBanHang_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=banhangconn")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<donhang> donhangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Danhmuc>()
                .HasMany(e => e.sanphams)
                .WithRequired(e => e.Danhmuc)
                .HasForeignKey(e => e.ID_danhmuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<donhang>()
                .Property(e => e.user_soDT)
                .IsUnicode(false);

            modelBuilder.Entity<donhang>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.donhang)
                .HasForeignKey(e => e.id_donhang);

            modelBuilder.Entity<sanpham>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.sanpham)
                .HasForeignKey(e => e.id_sanpham);

            modelBuilder.Entity<user>()
                .Property(e => e.soDT)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.donhangs)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
