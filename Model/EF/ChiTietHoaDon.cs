namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        public long MaCTHD { get; set; }

        public long? MaKQ { get; set; }

        public long? MaHD { get; set; }

        [StringLength(250)]
        public string TenDonThuoc { get; set; }

        public long? MaThuoc { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string LieuDung { get; set; }

        public decimal? DonGia { get; set; }
    }
}
