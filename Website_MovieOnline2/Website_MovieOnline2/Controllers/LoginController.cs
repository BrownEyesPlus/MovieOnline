using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Common;
using Website_MovieOnline2.Models;
using Website_MovieOnline2.Models.DAO;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TaiKhoan;
                    userSession.UserID = user.Ma;
                    Session.Add(CommonConstants.USSER_SESSION, userSession);

                    return RedirectToAction("Index", "Phim");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUseName(model.TaiKhoan))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.TaiKhoan = model.TaiKhoan;
                    model.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                    user.MatKhau = model.MatKhau;
                    user.TenHienThi = model.TenHienThi;
                    user.HoTen = model.HoTen;
                    user.NgaySinh = model.NgaySinh;
                    user.TrangThaiVip = false;

                    var result = dao.Insert(user);
                    if (result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }    
                }                    
            }
            return View(model);
        }

        

        public ActionResult Logout()
        {
            Session[CommonConstants.USSER_SESSION] = null;
            return RedirectToAction("/");
        }
    }
}