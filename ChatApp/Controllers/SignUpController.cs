using ChatApp_DataAccess;
using ChatApp_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SignUpController(ApplicationDbContext db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult Index()
        {
            User newUser = new();
            return View(newUser);
        }
        [HttpPost]
        public IActionResult Index(User newUser)
        {
            try
            {
                if (_db.Users.Select(i => i.UserName).Contains(newUser.UserName))
                {
                    ModelState.AddModelError("takenUsername", "This username is already used.");
                }

                else
                {
                    if (newUser.UserName != null)
                    {
                        _db.Users.Add(new User
                        {
                            UserName = newUser.UserName,
                            FirstName = newUser.FirstName,
                            LastName = newUser.LastName,
                            Password = newUser.Password
                        });
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("Exception", "Error is occured while creating new account!");
            }
            return View();
        }
    }

}
