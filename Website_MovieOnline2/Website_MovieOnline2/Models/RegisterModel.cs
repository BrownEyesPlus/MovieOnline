using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_MovieOnline2.Models
{
    public class RegisterModel
    {
        [Key]
        public int ID { set; get; }

        [Display(Name="Tài Khoản")]
        [Required(ErrorMessage ="Tài khoản không được trống")]
        public string TaiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(50,MinimumLength=4, ErrorMessage ="Độ dài kí tự tối thiểu là 4")]
        [Required(ErrorMessage = "Mật khẩu không được trống")]
        public string MatKhau { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau",ErrorMessage = "Xác nhận mật khẩu sai")]
        [StringLength(50)]
        public string XacNhanMatKhau { get; set; }

        [Display(Name = "Tên hiển thị")]
        [StringLength(50)]
        [Required(ErrorMessage = "Tên hiển thị không được trống")]
        public string TenHienThi { get; set; }

        [Display(Name = "Họ tên")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Trạng thái VIP")]
        public bool? TrangThaiVip { get; set; }
    }
}