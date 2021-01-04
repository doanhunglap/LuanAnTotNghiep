using Model.Dao;
using Model.EF;
using QuanLyPhongKham.Common;
using QuanLyPhongKham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QuanLyPhongKham.Common.Encrypt;

namespace QuanLyPhongKham.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            //var model = new MenuDao().ListByGroupId(1);
            ViewBag.menuList = new MenuDao().ListByGroupId(1);
            LoginModel model = new LoginModel();
            return PartialView(model);
        }


        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    //dang nhap thanh cong
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

        public ActionResult Register()
        {
            return PartialView();
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        [HttpPost]
        public ActionResult Register(Account model)
        {
        
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                //kiem tra nguoi dung ton tai
                //true neu ton tai , tra ve lai trang Create
                if (dao.GetByMaTK(model.UserName) != null)
                {
                    SetAlert("ten nguoi dung ton tai moi nhap ten khac", "warning");
                    return RedirectToAction("index");
                }
                else
                {
                    //kiem tra pass rong 
                    // true neu pass k rong
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        var md5 = Encrypt.Encryptor.MD5Hash(model.Password);
                        model.Password = md5;
                        var result = new AccountDao().Register(model);
                        if (result)
                        {
                            SetAlert("tao tai khoan thanh cong", "success");
                        }
                        else
                        {
                            SetAlert("Da co loi xay ra", "error");
                        }
                    }
                    else
                    {
                        SetAlert("ban chua nhap password", "error");
                        return RedirectToAction("Create", "User");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}