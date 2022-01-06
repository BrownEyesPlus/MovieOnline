using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    public class LichSuVIPController : Controller
    {
        private Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();
        // GET: Admin/LichSuVIP
        public ActionResult Index()
        {
            var model = context.LichSuGiaThanhVienVIPs.ToList().OrderByDescending(x => x.Ma);
            return View(model);
        }

        public ActionResult Create()
        {
            LichSuGiaThanhVienVIP model = new LichSuGiaThanhVienVIP();
            model.Ngay = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LichSuGiaThanhVienVIP lichsu)
        {
            try
            {
                lichsu.MaAdmin = 1;
                lichsu.Ngay = DateTime.Now;
                context.LichSuGiaThanhVienVIPs.Add(lichsu);
                context.SaveChanges();

                return RedirectToAction("Index", "LichSuVIP");
            }
            catch
            {
                return View();
            }
        }
    }
}