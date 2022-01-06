using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Controllers
{
    public class PhimController : Controller
    {
        
        private Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();
        // GET: Phim
        [HttpGet]
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Top8PhimMoi = context.Top8PhimMoi.ToList();
            var model = context.Top8PhimMoi.ToList();
            return View(mymodel);
        }

        public ActionResult ChiTietPhim(int id)
        {
            var model = context.PhimViews.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
        }

        public ActionResult Xem(int id)
        {           
            var model = context.PhimViews.Where(x => x.Ma == id).FirstOrDefault();
            model.Viewer = model.Viewer + 1;
            context.SaveChanges();

            dynamic mymodel = new ExpandoObject();
            mymodel.PhimView = context.PhimViews.Where(x => x.Ma == id).FirstOrDefault();
            mymodel.BinhLuanView = context.BinhLuanViews.Where(x => x.MaPhim == id).ToList();
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult BinhLuan(int id, string noidung)
        {
            var session = (Website_MovieOnline2.Common.UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];

            BinhLuan binhluan = new BinhLuan();
            binhluan.MaPhim = id;
            binhluan.MaUser = session.UserID;
            binhluan.ThoiGian = DateTime.Now;
            binhluan.NoiDung = noidung;
            context.BinhLuans.Add(binhluan);
            context.SaveChanges();
            return RedirectToAction("Xem","Phim",new {id = id});
        }
    }
}