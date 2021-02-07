using HealthProject_Domain;
using HelathProject_Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthProject.Controllers
{
    public class HomeController : Controller
    {
        HealthProjectDbEntities _dbEntities;

        public HomeController(HealthProjectDbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {

                _dbEntities.Users.Add(_user);
                _dbEntities.SaveChanges();

            }
            else
            {
                ViewBag.error = "Email already exists";
                return View();
            }


            return RedirectToAction("Login", "Home"); ;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, int password)
        {
            if (ModelState.IsValid)
            {
                /*var data1 = _dbEntities.Admins.Where(m => m.Email.Equals(email) && m.Password.Equals(password)).ToList();*/
                var data = _dbEntities.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password) && s.is_admin == 0).ToList();
                var data1 = _dbEntities.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password) && s.is_admin == 1).ToList();


                if (data.Count > 0)
                {
                    return RedirectToAction("Status");
                }

                else if (data1.Count > 0)
                {
                    return RedirectToAction("AdminLogin");
                }

            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult AdminLogin()
        {
            List<Status> statusshow = _dbEntities.Statuses.ToList();
            return View(statusshow);
        }

        public ActionResult Status()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Status(Status stats)
        {
            if (ModelState.IsValid)
            {

                _dbEntities.Statuses.Add(stats);
                _dbEntities.SaveChanges();

            }
            return RedirectToAction("Status", "Home");
        }
    }
}
