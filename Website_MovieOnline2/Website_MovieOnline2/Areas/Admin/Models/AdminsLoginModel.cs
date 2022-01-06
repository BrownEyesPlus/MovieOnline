using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_MovieOnline2.Areas.Admin.Models
{
    public class AdminsLoginModel
    {
        [Required(ErrorMessage = "Bạn chưa điền tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Phải nhập mật khẩu")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}