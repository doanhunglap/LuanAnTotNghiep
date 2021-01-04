namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(20)]
        public string MaNV { get; set; }

        [StringLength(250)]
        public string HoTen { get; set; }

        [StringLength(250)]
        public string ChuyenKhoa { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(450)]
        public string GhiChu { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        [StringLength(20)]
        public string MaCV { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(20)]
        public string MaTK { get; set; }
    }
}
