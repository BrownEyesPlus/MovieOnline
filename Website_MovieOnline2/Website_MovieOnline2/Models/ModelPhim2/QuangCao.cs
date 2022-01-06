namespace Website_MovieOnline2.Models.ModelPhim2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        [Key]
        public int Ma { get; set; }

        [StringLength(50)]
        public string TenQuangCao { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        [StringLength(500)]
        public string Anh { get; set; }
    }
}
