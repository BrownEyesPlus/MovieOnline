using PagedList;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Controllers
{
    public class TimKiemPhimController : Controller
    {
        private Website_MovieOnline_DbContext2 context = new Website_MovieOnline_DbContext2();
        // GET: TimKiemPhim
        [HttpGet]
        public ActionResult Index(int? page)
        {

            dynamic mymodel = new ExpandoObject();
            mymodel.PhimViews = context.PhimViews.ToList().OrderByDescending(x => x.Ma);

            var links = (from l in context.PhimViews select l).OrderByDescending(x => x.Ma);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(int? page,string search)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.PhimViews = context.PhimViews.Where(x=>x.TenPhimTiengViet.Contains(search) || x.Ten.Contains(search)).OrderByDescending(x => x.Ma);

            var links = (from l in context.PhimViews.Where(x => x.TenPhimTiengViet.Contains(search) || x.Ten.Contains(search)) select l).OrderByDescending(x => x.Ma);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
    }
}