namespace Website_MovieOnline2.Models.ModelPhim1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Phim")]
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            BinhLuans = new HashSet<BinhLuan>();
            DanhGiaPhims = new HashSet<DanhGiaPhim>();
            MucYeuThiches = new HashSet<MucYeuThich>();
        }

        [Key]
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

        public double? DanhGiaTB { get; set; }

        [StringLength(100)]
        public string TenTep { get; set; }

        public int? MaTheLoai { get; set; }

        public int? MaDaoDien { get; set; }

        public int? MaQuocGia { get; set; }

        public int? Viewer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaPhim> DanhGiaPhims { get; set; }

        public virtual DaoDien DaoDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MucYeuThich> MucYeuThiches { get; set; }

        public virtual QuocGia QuocGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        /*public virtual HttpPostedFileBase ImageFile { get; set; }*/
    }
}
