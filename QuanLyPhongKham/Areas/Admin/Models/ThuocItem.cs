using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyPhongKham.Areas.Admin.Models
{
    [Serializable]
    public class ThuocItem
    { 
        public Thuoc Thuoc { get; set; }

        public int SoLuong { get; set; }
    }
}