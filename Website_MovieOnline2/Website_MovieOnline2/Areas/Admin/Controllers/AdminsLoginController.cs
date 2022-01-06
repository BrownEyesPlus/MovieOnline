using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Website_MovieOnline2.Areas.Admin.Models;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    public class AdminsLoginController : Controller
    {
        Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();

        // GET: Admin/AdminsLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminsLoginModel model)
        {

            if (model.UserName == null || model.Password == null)
                ModelState.AddModelError("", "Bạn chưa điền tài khoản và mật khẩu");
            else
            {
                if (Membership.ValidateUser(model.UserName, model.Password) && ModelState.IsValid)
                {

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    dynamic model1 = new ExpandoObject();
                    model1 = context.Admins.Where(x => x.TaiKhoan == model.UserName).FirstOrDefault();
                    return RedirectToAction("Index", "Home", model1);

                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AdminsLogin");
        }
    }
}