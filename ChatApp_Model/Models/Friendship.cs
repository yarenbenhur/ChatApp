using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Model.Models
{
    public class Friendship
    {
     
        
        public int UserId { get; set; }
        public int FriendUserId { get; set; }
        public User User { get; set; }

    }
}
