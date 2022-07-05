using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChatApp_Model.Models
{
    public class LoggedUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return ($"{FirstName} {LastName}");
            }
        }
        //[DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        //[DisplayName("Şifre")]
        public string Password { get; set; }
       

    }
}
