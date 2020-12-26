using Model.EF;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class ThuocDao
    {
        QuanLyPhongKhamDbContext db = null;

        public ThuocDao()
        {
            db = new QuanLyPhongKhamDbContext();
        }

        //lay ra 1 user tu Username
        public Thuoc GetByTenThuoc(string tenThuoc)
        {
            return db.Thuoc.FirstOrDefault(x => x.TenThuoc == tenThuoc);
        }

        //lay ra 1 user tu MaTK
        public Thuoc GetByMaThuoc(string maThuoc)
        {
            return db.Thuoc.Where(x => x.MaThuoc == maThuoc).FirstOrDefault();
        }


        
       
        public IEnumerable<Thuoc> ListAllPaging()
        {
            return db.Thuoc.ToList();
        }

        public IEnumerable<Thuoc> ListAll()
        {
            return db.Thuoc.OrderByDescending(x => x.TenThuoc).ToList();
        }
 

        public bool Create(Thuoc thuoc)
        {
            try
            {
                var th = new Thuoc();
                th.MaThuoc = thuoc.MaThuoc;
                th.TenThuoc = thuoc.TenThuoc;
                th.CachDung = thuoc.CachDung;
                th.DonViTinh = thuoc.DonViTinh;
                th.DonGia = thuoc.DonGia;
                th.SoLuongMacDinh = thuoc.SoLuongMacDinh;         
                db.Thuoc.Add(th);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Thuoc thuoc)
        {
            try
            {
                var th = db.Thuoc.Find(thuoc.MaThuoc);
                th.TenThuoc = thuoc.TenThuoc;
                th.CachDung = thuoc.CachDung;
                th.DonViTinh = thuoc.DonViTinh;
                th.DonGia = thuoc.DonGia;
                th.SoLuongMacDinh = thuoc.SoLuongMacDinh;
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }



        

        public bool Delete(string maThuoc)
        {
            try
            {
                var thuoc = db.Thuoc.Find(maThuoc);
                db.Thuoc.Remove(thuoc);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Thuoc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IOrderedQueryable<Thuoc> model = db.Thuoc;
            if (!string.IsNullOrEmpty(searchString))
            {
                //contains kiểm tra chuỗi gần đúng
                model = model.Where(x => x.MaThuoc.Contains(searchString) || x.TenThuoc.Contains(searchString)).OrderByDescending(x => x.MaThuoc);
            }

            //tìm theo nhóm , ngày tháng => thêm if ()

            return model.OrderByDescending(x => x.MaThuoc).ToPagedList(page, pageSize);
        }



    }
}
