namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [Key]
        [StringLength(20)]
        public string MaThuoc { get; set; }

        [StringLength(50)]
        public string TenThuoc { get; set; }

        [StringLength(20)]
        public string DonViTinh { get; set; }

        public double? DonGia { get; set; }

        public int? SoLuongMacDinh { get; set; }

        [StringLength(100)]
        public string CachDung { get; set; }

        [StringLength(20)]
        public string MaNhomThuoc { get; set; }

        [StringLength(350)]
        public string ImagePath { get; set; }

        public int SoLuong { get; set; }
    }
}
