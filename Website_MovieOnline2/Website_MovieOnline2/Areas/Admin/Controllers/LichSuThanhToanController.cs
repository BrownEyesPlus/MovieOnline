using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    public class LichSuThanhToanController : Controller
    {
        private Website_MovieOnline_DbContext2 context = new Website_MovieOnline_DbContext2();
        // GET: Admin/LichSuThanhToan
        public ActionResult Index()
        {
            var model = context.LichSuThanhToans.ToList();
            return View(model);
        }
    }
}