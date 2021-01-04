using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongKham.Areas.Admin.Controllers
{
    public class ThuocController : BaseController
    {
        // GET: Admin/Thuoc
        //public ActionResult Index( int page = 1, int pageSize = 10)
        //{
        //    var dao = new ThuocDao();
        //    var model = dao.ListAllPaging();

        //    //tạo dữ liệu trả về View (phân trang theo từ khóa tiềm kiếm)
        //    return View(model);
        //}

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ThuocDao();
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
        public ActionResult Create(Thuoc model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThuocDao();
                //kiem tra nguoi dung ton tai
                //true neu ton tai , tra ve lai trang Create
                if (dao.GetByTenThuoc(model.TenThuoc) != null)
                {
                    SetAlert("ten thuoc ton tai moi nhap ten khac", "warning");
                    return RedirectToAction("Create", "Thuoc");
                }
                else
                {
                    
                       
                        var result = new ThuocDao().Create(model);
                        if (result)
                        {
                            SetAlert("tao moi thuoc thanh cong", "success");
                        }
                        else
                        {
                            SetAlert("Da co loi xay ra", "error");
                        }
                    
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new ThuocDao();
            dao.Delete(id);
            SetAlert("Xoa Thanh Cong", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var acc = new ThuocDao().GetByMaThuoc(id);
            return View(acc);
        }

        [HttpPost]
        public ActionResult Edit(Thuoc model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThuocDao();
                //kiem tra nguoi dung ton tai
                //true neu ton tai , tra ve lai trang Create
                if (dao.GetByTenThuoc(model.TenThuoc) != null)
                {
                    SetAlert("ten thuoc ton tai moi nhap ten khac", "warning");
                    return RedirectToAction("Create", "Thuoc");
                }
                else
                {
                    var result = new ThuocDao().Update(model);
                    if (result)
                    {
                        SetAlert("tao moi thuoc thanh cong", "success");
                    }
                    else
                    {
                        SetAlert("Da co loi xay ra", "error");
                    }

                    return RedirectToAction("Index");
                }
            }
            return View();
        }



    }
}