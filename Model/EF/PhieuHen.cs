namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuHen")]
    public partial class PhieuHen
    {
        [Key]
        public long MaPhieuHen { get; set; }

        public long? MaNV { get; set; }

        public DateTime? NgayHen { get; set; }

        public long? MaBN { get; set; }

        [StringLength(450)]
        public string TrieuChung { get; set; }

        [StringLength(250)]
        public string TinhTrang { get; set; }

        [StringLength(10)]
        public string GioHen { get; set; }
    }
}
