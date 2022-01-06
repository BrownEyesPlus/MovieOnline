namespace Website_MovieOnline2.Models.ModelPhim1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MucYeuThich")]
    public partial class MucYeuThich
    {
        [Key]
        public int Ma { get; set; }

        public int? MaPhim { get; set; }

        public int? MaUser { get; set; }

        public virtual Phim Phim { get; set; }

        public virtual User User { get; set; }
    }
}
