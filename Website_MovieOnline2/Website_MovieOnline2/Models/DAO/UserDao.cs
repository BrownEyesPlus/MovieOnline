using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_MovieOnline2.Models.ModelPhim2;

namespace Website_MovieOnline2.Models.DAO
{
    public class UserDao
    {
        Website_MovieOnline_DbContext2 db = null;
        public UserDao()
        {
            db = new Website_MovieOnline_DbContext2();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.Ma;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Ma);
                user.HoTen = entity.HoTen;
                if (!String.IsNullOrEmpty(entity.MatKhau))
                {
                    user.MatKhau = entity.MatKhau;
                }
                user.NgaySinh = entity.NgaySinh;
                user.TenHienThi = entity.TenHienThi;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TaiKhoan.Contains(searchString) || x.HoTen.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Ma).ToPagedList(page, pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.TaiKhoan == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.TaiKhoan == userName && x.MatKhau == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUseName (string userName)
        {
            return db.Users.Count(x => x.TaiKhoan == userName) > 0;
        }
    }
}