using Model.Dao;
using Model.EF;
using QuanLyPhongKham.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongKham.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/Home

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AccountDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            //tạo dữ liệu trả về View (phân trang theo từ khóa tiềm kiếm)
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                //kiem tra nguoi dung ton tai
                //true neu ton tai , tra ve lai trang Create
                if (dao.GetByMaTK(model.UserName)!= null)
                {
                    SetAlert("ten nguoi dung ton tai moi nhap ten khac", "warning");
                    return RedirectToAction("Create", "User");
                }
                else
                {
                    //kiem tra pass rong 
                    // true neu pass k rong
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        var md5 = Encrypt.Encryptor.MD5Hash(model.Password);
                        model.Password = md5;
                        var result = new AccountDao().Create(model);
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

        public ActionResult Edit(long id)
        {
            var acc = new AccountDao().GetByID(id);
            return View(acc);
        }

        [HttpPost]
        public ActionResult Edit(Account acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                if (!string.IsNullOrEmpty(acc.Password))
                {
                    var encry = Encrypt.Encryptor.MD5Hash(acc.Password);
                    acc.Password = encry;
                }
                var result = dao.Update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhap user thanh cong!");
                }

            }
            return View("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new AccountDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });

        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            
            var dao = new AccountDao().Delete(id);
            SetAlert("Xoa Thanh Cong", "success");
            return RedirectToAction("Index");

        }



    }
}