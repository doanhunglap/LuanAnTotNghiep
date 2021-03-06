﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongKham.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            var model = new NhanVienDao().GetByGroupID(1);
            return View(model);
        }

        public ActionResult Detail(string link)
        {
            var model = new NhanVienDao().GetNhanVienByLink(link);
            return View(model);
        }
    }
}