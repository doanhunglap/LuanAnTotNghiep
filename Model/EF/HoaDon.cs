namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public long MaHoaDon { get; set; }

        public long? MaCTHD { get; set; }

        public long? MaNV { get; set; }

        public long? MaBN { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? NgayNhap { get; set; }
    }
}
