using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BlogDao
    {
        QuanLyPhongKhamDbContext db = null;
        public BlogDao()
        {
            db = new QuanLyPhongKhamDbContext();
        }

        //1 cách làm khác//
        //public List<TinTuc> ListBlog(int top)
        //{
        //    return db.TinTuc.OrderByDescending(x => x.NgayDang).Take(top).ToList();
        //}             


       // lấy tin ra tin tức có ngày đăng cao hơn và có top view cao hơn
        public List<TinTuc> ListBlog(int top)
        {
            return db.TinTuc.OrderByDescending(x => x.NgayDang).Take(top).ToList();
        }

        public TinTuc GetBlogByLink(string link)
        {
            return db.TinTuc.Where(x => x.Link == link).FirstOrDefault();
        }
    }
}
