using Model.Dao;
using QuanLyPhongKham.Areas.Admin.Models;
using QuanLyPhongKham.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QuanLyPhongKham.Common.Encrypt;

namespace QuanLyPhongKham.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result==1)
                {
                    var user = dao.GetByMaTK(model.UserName);
                    var userSession = new UserLogin();
                    userSession.MaTK = user.MaTK;
                    userSession.UserName = user.UserName;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "User");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản Đã Bị Khóa");
                }
                else if (result == -2) 
                {
                    ModelState.AddModelError("", "Sai Mật Khẩu");
                }
                else
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");
                }
            }
            


            return View("Index");
        }
    }
}