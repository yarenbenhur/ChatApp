using ChatApp_DataAccess;
using ChatApp_Model;
using ChatApp_Model.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class FriendController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FriendController(ApplicationDbContext db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult Index()
        {
            List<User> userList = _db.Users.ToList();
            //var friendList =  _db.Friendship.Include(i=).ToList();
          

            return View(userList);
        }
        [HttpPost]
        public IActionResult Index(List<User> userList)
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Upsert(User userModel, string username)
        //{
        //    userModel.FriendList.Add(_db.Users.FirstOrDefault(i => i.UserName == username));

            
        //    return View();
        //}
    }
}
