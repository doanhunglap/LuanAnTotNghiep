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
        public long ID { get; set; }

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

        public long? GroupID { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public long? MaTK { get; set; }

        [StringLength(50)]
        public string Link { get; set; }
    }
}
