using ChatApp_DataAccess;
using ChatApp_Model;
using ChatApp_Model.Models;
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
            LoggedUser loggedUser = new();
            return View(loggedUser);
        }
        [HttpPost]
        public IActionResult Index(LoggedUser loggedUser)
        {

            User matchedUser = _db.Users.FirstOrDefault(i => i.UserName == loggedUser.UserName);
            if (!_db.Users.Select(i=>i.UserName).Contains(loggedUser.UserName))
            {
                ModelState.AddModelError("", "Kullanıcı adı bulunamadı!");
            }
            else
            {
                if (matchedUser.Password == loggedUser.Password)
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
