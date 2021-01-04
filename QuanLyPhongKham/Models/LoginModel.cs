using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyPhongKham.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời Nhập UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời Nhập Password")]
        public string Password { get; set; }

        
    }
}