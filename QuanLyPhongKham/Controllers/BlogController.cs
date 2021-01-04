using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongKham.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {

            var blogDao = new BlogDao();
            ViewBag.NewBlog = blogDao.ListBlog(5);
            
            
                 
            return View();
        }

        public ActionResult DetailBlog(string Link)
        {
            var model = new BlogDao().GetBlogByLink(Link);
            return View(model);
        }
    }
}