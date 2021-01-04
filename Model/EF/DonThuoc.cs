namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonThuoc")]
    public partial class DonThuoc
    {
        [Key]
        [StringLength(20)]
        public string MaDT { get; set; }

        [StringLength(50)]
        public string TenBN { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(50)]
        public string ChanDoan { get; set; }

        [StringLength(20)]
        public string NhomThuoc { get; set; }

        public double? TongTien { get; set; }

        [StringLength(50)]
        public string NguoiLap { get; set; }

        public DateTime? NgayLap { get; set; }
    }
}
