using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    public class QuanLyTheLoaiController : Controller
    {
        private Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();
        // GET: Admin/QuanLyTheLoai
        public ActionResult Index()
        {
            var model = context.TheLoais.ToList();
            return View(model);
        }

        // GET: Admin/QuanLyTheLoai/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QuanLyTheLoai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLyTheLoai/Create
        [HttpPost]
        public ActionResult Create(TheLoai theloai)
        {
            try
            {
                context.TheLoais.Add(theloai);
                context.SaveChanges();

                return RedirectToAction("Index", "QuanLyTheLoai");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyTheLoai/Edit/5
        public ActionResult Edit(int id)
        {
            var model = context.TheLoais.Where(x=>x.Ma==id).FirstOrDefault();
            return View(model);
        }

        // POST: Admin/QuanLyTheLoai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TheLoai theloai)
        {
            try
            {
                context.Entry(theloai).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index", "QuanLyTheLoai");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyTheLoai/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.TheLoais.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
        }

        // POST: Admin/QuanLyTheLoai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = context.TheLoais.Where(x => x.Ma == id).FirstOrDefault();
                context.TheLoais.Remove(model);
                context.SaveChanges();

                return RedirectToAction("Index", "QuanLyTheLoai");
            }
            catch
            {
                return View();
            }
        }
    }
}
