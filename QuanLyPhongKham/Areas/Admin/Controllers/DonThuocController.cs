using Model.Dao;
using QuanLyPhongKham.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongKham.Areas.Admin.Controllers
{
    public class DonThuocController : BaseController
    {

        private const string ThuocSession = "ThuocSession";
        // GET: Admin/DonThuoc
        public ActionResult Index()
        {
            var donthuoc = Session[ThuocSession];
            var list = new List<ThuocItem>();

            var dao = new DonThuocDao();
            ViewBag.NhomThuoc1 = dao.getListThuoc("MNT000001           ");
            if (donthuoc != null)
            {
                list = (List<ThuocItem>)donthuoc;
            }
            //truyen danh sach thuoc item vao view
            return View(list);
        }

        //load danh sach thuoc 
        public ActionResult ChildMenu(string id)
        {
            var dao = new DonThuocDao();
            var model = dao.getListThuoc(id);
            return PartialView(model);
        }

        //load danh sach nhom thuoc 
        public ActionResult ParentMenu()
        {
            var dao = new DonThuocDao();
            var model = dao.ListAll();
            return PartialView(model);
        }

        //load danh sach ke toa thuoc
        public ActionResult MainMenuThuoc(string maThuoc, int soLuong)
        {
            var thuoc = new DonThuocDao().ViewDetial(maThuoc);
            var donthuoc = Session[ThuocSession];
            if (donthuoc != null)
            {
                var list = (List<ThuocItem>)donthuoc;
                if (list.Exists(x => x.Thuoc.MaThuoc == maThuoc))
                {

                    foreach (var item in list)
                    {
                        if (item.Thuoc.MaThuoc == maThuoc)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng thuoc item
                    var item = new ThuocItem();
                    item.Thuoc = thuoc;
                    item.SoLuong = soLuong;
                    list.Add(item);
                }
                //Gán vào session
                Session[ThuocSession] = list;
            }
            else
            {
                //tạo mới đối tượng thuocitem
                var item = new ThuocItem();
                item.Thuoc = thuoc;
                item.SoLuong = soLuong;
                var list = new List<ThuocItem>();
                list.Add(item);
                //Gán vào session
                Session[ThuocSession] = list;
            }
            return PartialView(Session[ThuocSession]);
        }
        //public ActionResult AddThuoc(string maThuoc, int soLuong)
        //{
        //    var thuoc = new DonThuocDao().ViewDetial(maThuoc);
        //    var donthuoc = Session[ThuocSession];
        //    if (donthuoc != null)
        //    {
        //        var list = (List<ThuocItem>)donthuoc;
        //        if (list.Exists(x => x.Thuoc.MaThuoc == maThuoc))
        //        {

        //            foreach (var item in list)
        //            {
        //                if (item.Thuoc.MaThuoc == maThuoc)
        //                {
        //                    item.SoLuong += soLuong;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //tạo mới đối tượng thuoc item
        //            var item = new ThuocItem();
        //            item.Thuoc = thuoc;
        //            item.SoLuong = soLuong;
        //            list.Add(item);
        //        }
        //        //Gán vào session
        //        Session[ThuocSession] = list;
        //    }
        //    else
        //    {
        //        //tạo mới đối tượng cart item
        //        var item = new ThuocItem();
        //        item.Thuoc = thuoc;
        //        item.SoLuong = soLuong;
        //        var list = new List<ThuocItem>();
        //        list.Add(item);
        //        //Gán vào session
        //        Session[ThuocSession] = list;
        //    }
        //    return RedirectToAction("Index");
        //}



    }
}