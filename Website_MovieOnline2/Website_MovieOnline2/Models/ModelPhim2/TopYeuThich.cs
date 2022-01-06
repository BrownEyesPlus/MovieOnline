namespace Website_MovieOnline2.Models.ModelPhim2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopYeuThich")]
    public partial class TopYeuThich
    {
        [Column("Luot thich")]
        public int? Luot_thich { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ma { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string TenPhimTiengViet { get; set; }

        [StringLength(500)]
        public string AnhMoi { get; set; }
    }
}
