using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Common;
using Website_MovieOnline2.Models.DAO;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Controllers
{
    public class MucYeuThichController : BaseController
    {
        private Website_MovieOnline_DbContext2 context = new Website_MovieOnline_DbContext2();
        // GET: MucYeuThich
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();

            var user = (Website_MovieOnline2.Common.UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];
            mymodel.MucYeuThichView = context.MucYeuThichViews.Where(x=>x.MaUser == user.UserID);
            
            return View(mymodel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var session = (UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];

            var dao = new MucYeuThichDao();
            dao.Insert(id, session.UserID);

            
            return RedirectToAction("Index", "Phim");
        }

        /*[HttpPost]
        public ActionResult Create(int id)
        {
            var session = (UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];

            var dao = new MucYeuThichDao();
            dao.Insert(id, session.UserID);

            return RedirectToAction("Index","Phim");
        }*/
        public ActionResult XemMucYeuThich()
        {          
            var user = (Website_MovieOnline2.Common.UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];
            var model = context.MucYeuThichViews.Where(x => x.MaUser == user.UserID);

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var session = (UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];

            var phimyeuthich = context.MucYeuThiches.Where(x => x.MaPhim == id && x.MaUser == session.UserID).FirstOrDefault();
            context.MucYeuThiches.Remove(phimyeuthich);
            context.SaveChanges();

            return RedirectToAction("Index", "MucYeuThich");
        }

        [HttpGet]
        public ActionResult ThemBinhLuan(int id)
        {
            //var session = (UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];

            var model = context.BinhLuanViews.ToList();

            return View(model);
        }

        
        public PartialViewResult XemBinhLuan(int id)
        {
            //var session = (UserLogin)Session[Website_MovieOnline2.Common.CommonConstants.USSER_SESSION];

            var model = context.BinhLuanViews.ToList();

            return PartialView(model);
        }

    }
}