using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Model.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            Users = new User();
            LoggedUser = new LoggedUser();
        }

        public User Users { get; set; }
        public LoggedUser LoggedUser { get; set; }
    }
}
