using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    public class QuanLyDaoDienController : Controller
    {
        private Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();
        // GET: Admin/QuanLyDaoDien
        public ActionResult Index()
        {
            var model = context.DaoDiens.ToList();
            return View(model);
        }

        // GET: Admin/QuanLyDaoDien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QuanLyDaoDien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLyDaoDien/Create
        [HttpPost]
        public ActionResult Create(DaoDien daodien)
        {
            try
            {
                context.DaoDiens.Add(daodien);
                context.SaveChanges();

                return RedirectToAction("Index", "QuanLyDaoDien");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyDaoDien/Edit/5
        public ActionResult Edit(int id)
        {
            var model = context.DaoDiens.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
            
        }

        // POST: Admin/QuanLyDaoDien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DaoDien daodien)
        {
            try
            {
                context.Entry(daodien).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index", "QuanLyDaoDien");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyDaoDien/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.DaoDiens.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
        }

        // POST: Admin/QuanLyDaoDien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = context.DaoDiens.Where(x => x.Ma == id).FirstOrDefault();
                context.DaoDiens.Remove(model);
                context.SaveChanges();

                return RedirectToAction("Index", "QuanLyDaoDien");
            }
            catch
            {
                return View();
            }
        }
    }
}
