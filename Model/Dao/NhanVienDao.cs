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

        public List<NhanVien> GetByGroupID (long groupId)
        {
            return db.NhanVien.Where(x => x.GroupID == groupId).OrderBy(x => x.ID).ToList();
        }

        public NhanVien GetNhanVienByLink(string link)
        {
            return db.NhanVien.Where(x => x.Link == link).FirstOrDefault();
        }

    }
}
