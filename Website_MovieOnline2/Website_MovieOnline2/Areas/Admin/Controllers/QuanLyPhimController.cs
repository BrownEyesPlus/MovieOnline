using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Areas.Admin.Controllers
{
    public class QuanLyPhimController : Controller
    {
        private Website_MovieOnline2_DbContext context = new Website_MovieOnline2_DbContext();
        // GET: Admin/QuanLyPhim
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/QuanLyPhim/Details/5
        public ActionResult Details(int id)
        {
            var model = context.PhimViews.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
        }

        // GET: Admin/QuanLyPhim/Create
        [HttpGet]
        public ActionResult Create()
        {
            // Lấy data
            // Lấy toàn bộ thể loại:
            List<TheLoai> theloai = context.TheLoais.ToList();

            // Tạo SelectList
            SelectList theloaiList = new SelectList(theloai, "Ma", "Ten");

            ViewBag.TheLoaiList = theloaiList;

            
            List<DaoDien> daodien = context.DaoDiens.ToList();
            SelectList daodienList = new SelectList(daodien, "Ma", "Ten");
            ViewBag.DaoDienList = daodienList;

            List<QuocGia> quocgia = context.QuocGias.ToList();
            SelectList quocgiaList = new SelectList(quocgia, "Ma", "Ten");
            ViewBag.QuocGiaList = quocgiaList;

            return View();
        }

        // POST: Admin/QuanLyPhim/Create
        [HttpPost]
        public ActionResult Create(Phim phim, FileAnh anh)
        {

            try
            {
                //upload file ảnh
                string fileName = Path.GetFileNameWithoutExtension(anh.ImageFile.FileName);
                string extension = Path.GetExtension(anh.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                phim.AnhMoi =  fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                anh.ImageFile.SaveAs(fileName);

                phim.Viewer = 0;

                context.Phims.Add(phim);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyPhim/Edit/5
        public ActionResult Edit(int id)
        {
            List<TheLoai> theloai = context.TheLoais.ToList();
            SelectList theloaiList = new SelectList(theloai, "Ma", "Ten");
            ViewBag.TheLoaiList = theloaiList;

            List<DaoDien> daodien = context.DaoDiens.ToList();
            SelectList daodienList = new SelectList(daodien, "Ma", "Ten");
            ViewBag.DaoDienList = daodienList;

            List<QuocGia> quocgia = context.QuocGias.ToList();
            SelectList quocgiaList = new SelectList(quocgia, "Ma", "Ten");
            ViewBag.QuocGiaList = quocgiaList;

            var model = context.Phims.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
        }

        // POST: Admin/QuanLyPhim/Edit/5
        [HttpPost]
        public ActionResult Edit(int  id, Phim phim, FileAnh anh)
        {
            try
            {
                if(anh != null)
                {
                    //var luotxem = context.Phims.Where(x => x.Ma == phim.Ma).FirstOrDefault();
                    //upload file ảnh
                    string fileName = Path.GetFileNameWithoutExtension(anh.ImageFile.FileName);
                    string extension = Path.GetExtension(anh.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    phim.AnhMoi = fileName;
                    
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                    anh.ImageFile.SaveAs(fileName);
                }
                
                context.Entry(phim).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");     
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyPhim/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.Phims.Where(x => x.Ma == id).FirstOrDefault();
            return View(model);
        }

        // POST: Admin/QuanLyPhim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = context.Phims.Where(x => x.Ma == id).FirstOrDefault();
                context.Phims.Remove(model);
                context.SaveChanges();
                

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
