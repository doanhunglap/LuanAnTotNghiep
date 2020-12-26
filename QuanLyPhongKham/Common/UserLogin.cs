using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyPhongKham.Common
{
    [Serializable]
    public class UserLogin
    {
        public long MaTK { get; set; }

        public string UserName { get; set; }
    }
}