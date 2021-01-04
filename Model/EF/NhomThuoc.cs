namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomThuoc")]
    public partial class NhomThuoc
    {
        [Key]
        [StringLength(20)]
        public string MaNhomThuoc { get; set; }

        [StringLength(50)]
        public string TenNhomThuoc { get; set; }
    }
}
