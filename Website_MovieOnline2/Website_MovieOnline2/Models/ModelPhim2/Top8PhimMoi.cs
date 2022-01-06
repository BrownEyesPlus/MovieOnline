namespace Website_MovieOnline2.Models.ModelPhim2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Top8PhimMoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ma { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string TenPhimTiengViet { get; set; }

        [StringLength(10)]
        public string DiemIMDb { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhatHanh { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [StringLength(500)]
        public string AnhMoi { get; set; }

        [StringLength(10)]
        public string ThoiLuong { get; set; }

        [StringLength(50)]
        public string NgonNgu { get; set; }

        [StringLength(100)]
        public string TenTep { get; set; }

        [StringLength(50)]
        public string QuocGia { get; set; }

        [StringLength(50)]
        public string DaoDien { get; set; }

        [StringLength(50)]
        public string TheLoai { get; set; }

        public int? Viewer { get; set; }
    }
}
