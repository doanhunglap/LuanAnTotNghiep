using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DonThuocDao
    {
        QuanLyPhongKhamDbContext db = null;

        public DonThuocDao()
        {
            db = new QuanLyPhongKhamDbContext();
        }

        public IEnumerable<NhomThuoc> ListAll()
        {
            return db.NhomThuoc.OrderBy(x => x.MaNhomThuoc).ToList();
        }

        public IEnumerable<Thuoc> getListThuoc(string id)
        {
            return db.Thuoc.Where(x => x.MaNhomThuoc==id).ToList();
        }

        //public IEnumerable<DonThuoc> getListDonThuoc(string id)
        //{
        //    return db.DonThuoc.Where(x => x. == id).ToList();
        //}
        public Thuoc ViewDetial(string id)
        {
            return db.Thuoc.Find(id);
        }


    }
}
