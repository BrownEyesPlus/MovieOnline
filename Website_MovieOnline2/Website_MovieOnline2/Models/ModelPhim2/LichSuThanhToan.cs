namespace Website_MovieOnline2.Models.ModelPhim2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuThanhToan")]
    public partial class LichSuThanhToan
    {
        [Key]
        public int Ma { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public int? MaUser { get; set; }

        public virtual User User { get; set; }
    }
}
