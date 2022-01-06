namespace Website_MovieOnline2.Models.ModelPhim1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuGiaThanhVienVIP")]
    public partial class LichSuGiaThanhVienVIP
    {
        [Key]
        public int Ma { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public int? MaAdmin { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
