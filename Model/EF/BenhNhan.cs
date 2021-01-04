namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        [Key]
        [StringLength(20)]
        public string MaBN { get; set; }

        [StringLength(50)]
        public string TenBN { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        public string CanNang { get; set; }

        [StringLength(20)]
        public string ThanNhiet { get; set; }

        [StringLength(20)]
        public string Mach { get; set; }

        [StringLength(20)]
        public string HuyetAp { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string NhomBN { get; set; }

        public DateTime? NgayLap { get; set; }

        [StringLength(20)]
        public string MaTK { get; set; }
    }
}
