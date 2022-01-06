namespace Website_MovieOnline2.Models.ModelPhim2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuanView")]
    public partial class BinhLuanView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ma { get; set; }

        public int? MaPhim { get; set; }

        public int? MaUser { get; set; }

        public DateTime? ThoiGian { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string TenHienThi { get; set; }
    }
}
