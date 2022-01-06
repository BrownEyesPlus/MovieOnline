using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Models.DAO
{
    public class MucYeuThichDao
    {
        Website_MovieOnline_DbContext2 db = null;
        public MucYeuThichDao()
        {
            db = new Website_MovieOnline_DbContext2();
        }
        public int Insert(int maPhim,int maUser)
        {
            int check = db.MucYeuThiches.Count(x => x.MaPhim == maPhim && x.MaUser == maUser);
            if (check > 0)
            {
                return 0;
            }

            MucYeuThich entity = new MucYeuThich();
            entity.MaPhim = maPhim;
            entity.MaUser = maUser;
            db.MucYeuThiches.Add(entity);
            db.SaveChanges();
            return entity.Ma;
        }

        public bool Update(MucYeuThich entity)
        {
            try
            {
                var user = db.MucYeuThiches.Find(entity.Ma);
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<MucYeuThichView> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<MucYeuThichView> model = db.MucYeuThichViews;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ten.Contains(searchString) || x.TenPhimTiengViet.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Ma).ToPagedList(page, pageSize);
        }
        
        public MucYeuThichView ViewDetail(int id)
        {
            return db.MucYeuThichViews.Find(id);
        }
    }
}