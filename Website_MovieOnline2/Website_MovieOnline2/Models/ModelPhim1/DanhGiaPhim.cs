namespace Website_MovieOnline2.Models.ModelPhim1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGiaPhim")]
    public partial class DanhGiaPhim
    {
        [Key]
        public int Ma { get; set; }

        public int? MaPhim { get; set; }

        public int? MaUser { get; set; }

        public double? Diem { get; set; }

        public virtual Phim Phim { get; set; }

        public virtual User User { get; set; }
    }
}
