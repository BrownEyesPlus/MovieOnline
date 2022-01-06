using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Website_MovieOnline2.Models.ModelPhim1
{
    public partial class Website_MovieOnline2_DbContext : DbContext
    {
        public Website_MovieOnline2_DbContext()
            : base("name=Website_MovieOnline2_DbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<DanhGiaPhim> DanhGiaPhims { get; set; }
        public virtual DbSet<DaoDien> DaoDiens { get; set; }
        public virtual DbSet<LichSuGiaThanhVienVIP> LichSuGiaThanhVienVIPs { get; set; }
        public virtual DbSet<MucYeuThich> MucYeuThiches { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<QuocGia> QuocGias { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BinhLuanView> BinhLuanViews { get; set; }
        public virtual DbSet<MucYeuThichView> MucYeuThichViews { get; set; }
        public virtual DbSet<PhimView> PhimViews { get; set; }
        public virtual DbSet<Top8PhimMoi> Top8PhimMoi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.LichSuGiaThanhVienVIPs)
                .WithOptional(e => e.Admin)
                .HasForeignKey(e => e.MaAdmin);

            modelBuilder.Entity<DaoDien>()
                .HasMany(e => e.Phims)
                .WithOptional(e => e.DaoDien)
                .HasForeignKey(e => e.MaDaoDien);

            modelBuilder.Entity<LichSuGiaThanhVienVIP>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.MaPhim);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.DanhGiaPhims)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.MaPhim);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.MucYeuThiches)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.MaPhim);

            modelBuilder.Entity<QuocGia>()
                .HasMany(e => e.Phims)
                .WithOptional(e => e.QuocGia)
                .HasForeignKey(e => e.MaQuocGia);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Quyen)
                .HasForeignKey(e => e.MaQuyen);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.Phims)
                .WithOptional(e => e.TheLoai)
                .HasForeignKey(e => e.MaTheLoai);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.MaUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DanhGiaPhims)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.MaUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MucYeuThiches)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.MaUser);
        }
    }
}
