using System.Web.Mvc;

namespace QuanLyPhongKham.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "DonThuocMain",
                "Admin/DonThuoc/MainMenuThuoc",
                new { controller = "DonThuoc", action = "MainMenuThuoc", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "DonThuocParent",
                "Admin/DonThuoc/ParentMenu",
                new { controller = "DonThuoc", action = "ParentMenu", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "DonThuocChild",
                "Admin/DonThuoc/ChildMenu",
                new { controller = "DonThuoc", action = "ChildMenu", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "Thuoc",
                "thuoc",
                new { controller = "Thuoc", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "BenhNhan",
                "benh-nhan",
                new { controller = "BenhNhan", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "DonThuoc",
                "don-thuoc",
                new { controller = "DonThuoc", action = "Index", id = UrlParameter.Optional }
            );

            
            context.MapRoute(
                "HoaDon",
                "hoa-don",
                new { controller = "HoaDon", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "KhoThuoc",
                "kho-thuoc",
                new { controller = "KhoThuoc", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "BaoCao",
                "bao-cao",
                new { controller = "BaoCao", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "CauHinh",
                "cau-hinh",
                new { controller = "CauHinh", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller="Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}