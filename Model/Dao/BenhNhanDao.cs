using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BenhNhanDao
    {
        QuanLyPhongKhamDbContext db = null;

        public BenhNhanDao()
        {
            db = new QuanLyPhongKhamDbContext();
        }

        public IEnumerable<BenhNhan> ListAllPaging(string searchString, int page, int pageSize)
        {
            IOrderedQueryable<BenhNhan> model = db.BenhNhan;
            if (!string.IsNullOrEmpty(searchString))
            {
                //contains kiểm tra chuỗi gần đúng
                model = model.Where(x => x.MaBN.Contains(searchString) || x.TenBN.Contains(searchString)).OrderByDescending(x => x.MaBN);
            }

            //tìm theo nhóm , ngày tháng => thêm if ()

            return model.OrderByDescending(x => x.MaBN).ToPagedList(page, pageSize);
        }

        public BenhNhan GetByTenBN(string tenBenhNhan)
        {
            return db.BenhNhan.FirstOrDefault(x => x.TenBN == tenBenhNhan);
        }

        //lay ra 1 user tu MaTK
        public BenhNhan GetByMaThuoc(string maBN)
        {
            return db.BenhNhan.Where(x => x.MaBN == maBN).FirstOrDefault();
        }



        public IEnumerable<BenhNhan> ListAll()
        {
            return db.BenhNhan.OrderByDescending(x => x.TenBN).ToList();
        }

        public IEnumerable<NhomBN> GetListNhomBN()
        {
            return db.NhomBN.OrderByDescending(x => x.MaNhomBN).ToList();
        }

        public bool Create(BenhNhan BN)
        {
            try
            {
                var bn = new BenhNhan();
                bn.MaBN = BN.MaBN;
                bn.TenBN = BN.TenBN;
                bn.GioiTinh = BN.GioiTinh;
                bn.SDT = BN.SDT;
                bn.Mach = BN.Mach;
                bn.HuyetAp = BN.HuyetAp;
                bn.NgayLap = BN.NgayLap;
                bn.ThanNhiet = BN.ThanNhiet;
                bn.CanNang = BN.CanNang;
                bn.DiaChi = BN.DiaChi;
                db.BenhNhan.Add(bn);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(BenhNhan BN)
        {
            try
            {
                var bn = db.BenhNhan.Find(BN.MaBN);
                bn.TenBN = BN.TenBN;
                bn.GioiTinh = BN.GioiTinh;
                bn.SDT = BN.SDT;
                bn.Mach = BN.Mach;
                bn.HuyetAp = BN.HuyetAp;
                bn.NgayLap = BN.NgayLap;
                bn.ThanNhiet = BN.ThanNhiet;
                bn.CanNang = BN.CanNang;
                bn.DiaChi = BN.DiaChi;
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }





        public bool Delete(string maBN)
        {
            try
            {
                var bn = db.BenhNhan.Find(maBN);
                db.BenhNhan.Remove(bn);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
