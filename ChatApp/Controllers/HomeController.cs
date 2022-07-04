using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using ChatApp_Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChatApp_DataAccess;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<User> userList = _db.Users.ToList();
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public JsonResult GetFriendList()
        {
            List<User> users = _db.Users.ToList();
            List<SelectListItem> userlist = new List<SelectListItem>();
            foreach (var item in users)
            {
                userlist.Add(new SelectListItem
                {
                    Value = item.UserName,
                    Text = item.FullName

                });
            }
            return Json(userlist);
        }
        [HttpPost]
        public JsonResult SendMsg(string message, string friend)
        {
            RabbitMQController obj = new ();
            IConnection con = obj.GetConnecion();
            bool flag = obj.Send(con, message,friend);
            return Json(null);
        }
        [HttpPost]
        public JsonResult ReceiveMsg()
        {
            try
            {
                RabbitMQController obj = new RabbitMQController();
                IConnection con = obj.GetConnecion();
                string userqueue = "ceydatuncok";
                string message = obj.Receive(con, userqueue);
                return Json(message);
            }
            catch (Exception)
            {

                return null;
            }


        }


    }
}
