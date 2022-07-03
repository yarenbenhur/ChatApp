using ChatApp_DataAccess;
using ChatApp_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        public IActionResult Index()
        {
            User usermodel = new();
            return View(usermodel);
        }
        [HttpPost]
        public IActionResult Index(User userModel)
        {

            User matchedUser = _db.Users.FirstOrDefault(i => i.UserName == userModel.UserName);
            if (!_db.Users.Select(i=>i.UserName).Contains(userModel.UserName))
            {
                ModelState.AddModelError("", "Kullanıcı adı bulunamadı!");
            }
            else
            {
                if (matchedUser.Password == userModel.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Yanlış şifre!");

                }
            }           

            return View();
        }
    }
}
