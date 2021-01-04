namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public long MaTinTuc { get; set; }

        [StringLength(50)]
        public string TenTinTuc { get; set; }

        public long? MaNV { get; set; }

        public DateTime? NgayDang { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string Nguoidang { get; set; }

        [StringLength(450)]
        public string Comment { get; set; }

        public int? Viewposts { get; set; }

        [StringLength(250)]
        public string Hinhanh { get; set; }

        [StringLength(50)]
        public string Link { get; set; }
    }
}
