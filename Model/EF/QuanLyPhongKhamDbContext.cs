namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyPhongKhamDbContext : DbContext
    {
        public QuanLyPhongKhamDbContext()
            : base("name=QuanLyPhongKhamDbContext")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<BenhNhan> BenhNhan { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<DonThuoc> DonThuoc { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhanVienType> NhanVienType { get; set; }
        public virtual DbSet<NhomBN> NhomBN { get; set; }
        public virtual DbSet<NhomThuoc> NhomThuoc { get; set; }
        public virtual DbSet<PhieuHen> PhieuHen { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.CanNang)
                .IsFixedLength();

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.ThanNhiet)
                .IsFixedLength();

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.Mach)
                .IsFixedLength();

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.HuyetAp)
                .IsFixedLength();

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.NhomBN)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonThuoc>()
                .Property(e => e.MaDT)
                .IsFixedLength();

            modelBuilder.Entity<DonThuoc>()
                .Property(e => e.NhomThuoc)
                .IsFixedLength();

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<NhomBN>()
                .Property(e => e.MaNhomBN)
                .IsUnicode(false);

            modelBuilder.Entity<NhomThuoc>()
                .Property(e => e.MaNhomThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.DonViTinh)
                .IsFixedLength();

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.MaNhomThuoc)
                .IsUnicode(false);
        }
    }
}
