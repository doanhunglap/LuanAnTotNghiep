using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
     public class NhanVienDao
    {

        QuanLyPhongKhamDbContext db = null;

        public NhanVienDao()
        {
            db = new QuanLyPhongKhamDbContext();
        }

        public List<NhanVien> GetByMaCV (string maCV)
        {
            return db.NhanVien.Where(x => x.MaCV == maCV).OrderBy(x => x.MaNV).ToList();
        }

        public List<NhanVien> GetListNV()
        {
            return db.NhanVien.ToList();
        }

    }
}
