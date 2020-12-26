namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiThuoc")]
    public partial class LoaiThuoc
    {
        [Key]
        public long MaLoaiThuoc { get; set; }

        [StringLength(250)]
        public string TenLoaiThuoc { get; set; }
    }
}
