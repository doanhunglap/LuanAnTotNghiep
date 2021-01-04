namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomBN")]
    public partial class NhomBN
    {
        [Key]
        [StringLength(20)]
        public string MaNhomBN { get; set; }

        [StringLength(50)]
        public string TenNhom { get; set; }
    }
}
