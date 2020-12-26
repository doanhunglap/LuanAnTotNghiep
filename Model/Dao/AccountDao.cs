using Model.EF;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class AccountDao
    {
        QuanLyPhongKhamDbContext db = null;

        public AccountDao()
        {
            db = new QuanLyPhongKhamDbContext();
        }

        //lay ra 1 user tu Username
        public Account GetByMaTK(string userName)
        {
            return db.Account.FirstOrDefault(x => x.UserName == userName);
        }

        //lay ra 1 user tu MaTK
        public Account GetByID (long matk)
        {
            return db.Account.Find(matk);
        }


        public int Login(string userName , string password)
        {
            // kiem tra tai khoan ton tai 
            var result = db.Account.FirstOrDefault(x => x.UserName == userName);
            
            if (result == null)
            {
                //tai khoan khong ton tai
                return 0;
            }
            else
            {
                if (result.TrangThai == false)
                {
                    //tài khoản bị khóa
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                    {
                        //đăng nhập thành công
                        return 1;
                    }
                    else
                    {
                        //đăng nhập thất bại , sai mật khẩu
                        return -2;
                    }
                }
            }
        }

        public IEnumerable<Account> ListAllPaging(string searchString, int page,int pageSize )
        {
            IOrderedQueryable<Account> model = db.Account;
            if (!string.IsNullOrEmpty(searchString))
            {
                //contains kiểm tra chuỗi gần đúng
                model = model.Where(x => x.UserName.Contains(searchString) || x.PhanQuyen.Contains(searchString)).OrderByDescending(x => x.MaTK);
            }

            //tìm theo nhóm , ngày tháng => thêm if ()

            return model.OrderByDescending(x => x.MaTK).ToPagedList(page,pageSize);
        }

        public IEnumerable<Account> ListAll()
        {
            return db.Account.OrderByDescending(x => x.UserName).ToList();
        }

        public bool Create(Account acc)
        {
            try
            {
                var user = new Account();
                user.MaTK = acc.MaTK;
                user.UserName = acc.UserName;
                user.Password = acc.Password;
                user.PhanQuyen = acc.PhanQuyen;
                user.TrangThai = acc.TrangThai;
                db.Account.Add(user);
                db.SaveChanges(); 
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Update(Account acc)
        {
            try
            {
                var user = db.Account.Find(acc.MaTK);
                if (!string.IsNullOrEmpty(acc.Password))
                {
                    user.Password = acc.Password;
                }                
                user.PhanQuyen = acc.PhanQuyen;
                user.TrangThai = acc.TrangThai;
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }       
        }

        

        public bool ChangeStatus(long id)
        {
            var account = db.Account.Find(id);
            account.TrangThai = !account.TrangThai;
            return !account.TrangThai; 
        }

        public bool Delete(long id )
        {
            try
            {
                var acc = db.Account.Find(id);
                db.Account.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
