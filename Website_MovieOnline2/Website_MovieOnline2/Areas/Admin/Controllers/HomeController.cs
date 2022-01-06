using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.PhimViews = context.PhimViews.ToList().OrderByDescending(x=>x.Ma);
            dynamic mymodel2 = new ExpandoObject();
            mymodel2.Admins = context.Admins.ToList().FirstOrDefault();
            return View(mymodel);
            
        }
    }
}