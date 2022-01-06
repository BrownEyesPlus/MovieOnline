namespace Website_MovieOnline2.Models.ModelPhim2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaHienTaiView")]
    public partial class GiaHienTaiView
    {
        [Key]
        public int Ma { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gia { get; set; }

        public DateTime? Ngay { get; set; }

        public int? MaAdmin { get; set; }
    }
}
