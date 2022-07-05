using ChatApp_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ChatApp_Model
{
    public class User
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
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        
        //public List<User> FriendList { get; set; }
        //public ICollection<Friendship> Friendship { get; set; }



    }
}
