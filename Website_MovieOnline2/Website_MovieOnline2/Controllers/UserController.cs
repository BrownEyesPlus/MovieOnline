using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Controllers
{
    public class UserController : Controller
    {
        private Website_MovieOnline_DbContext2 context = new Website_MovieOnline_DbContext2();
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            var session =(Website_MovieOnline2.Common.UserLogin) Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];
            var model = context.Users.Where(x => x.Ma == session.UserID).FirstOrDefault();
            return View(model);
        }

        public ActionResult DangKyVIP()
        {
            
            var session = (Website_MovieOnline2.Common.UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];
            var model = context.Users.Where(x => x.Ma == session.UserID).FirstOrDefault();

            if(model.TrangThaiVip == false)
            {
                model.TrangThaiVip = true;

                LichSuThanhToan thanhtoan = new LichSuThanhToan();
                thanhtoan.MaUser = session.UserID;
                thanhtoan.Ngay = DateTime.Now;
                thanhtoan.Gia = context.GiaHienTaiViews.FirstOrDefault().Gia;
                context.LichSuThanhToans.Add(thanhtoan);

                context.SaveChanges();
            }                

            return RedirectToAction("Index");
        }

    }
}