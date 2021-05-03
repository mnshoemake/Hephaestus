using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Hephaestus.Data;
using Microsoft.AspNetCore.Mvc;
using Hephaestus.Models;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Hephaestus.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly HephaestusContext _context;

        public HomeController(HephaestusContext context)
        {
            _context = context;
        }

        private List<Models.Hero> GetHeroesByUserId(int userId)
        {
            List<Models.Hero> lstHeroes = new List<Hero>();

            try
            {
                lstHeroes = _context.Heroes.Where(x => x.UserId == userId).ToList();
                return lstHeroes;
            }

            catch (Exception)
            {
                throw;
            }

        }

        private User GetUserByUserId(int userId)
        {
            User user = new User();
            try
            {
                user = (User)_context.Users.Where(x => x.Id == userId).FirstOrDefault();
                user.Heroes = _context.Heroes.Where(h => h.UserId == userId).ToList();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateHero()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            else
                return View();
        }


        [HttpPost]
        public IActionResult CreateHero(Hero hero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (HttpContext.Session.GetInt32("UserId") != null)
                    {
                        hero.UserId = (int)HttpContext.Session.GetInt32("UserId");
                    }
                    else hero.UserId = 1;

                    _context.Heroes.Add(hero);
                    _context.SaveChanges();
                    return RedirectToAction("UserDashboard");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save Hero data. " +
                                                 "Please try again. If the issue persists, " +
                                                 "please contact your system administrator.");
                    return View();
                }
            }
            
            return View(hero);
        }

        public IActionResult DeleteHero(int id)
        {
            try
            {
                var deletedHero = _context.Heroes.Single(h => h.Id.Equals(id));
                _context.Remove(deletedHero);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Unable to delete Hero data. " +
                                                  "Please try again. If the issue persists, " +
                                                  "please contact your system administrator.");
                
            }
            return RedirectToAction("UserDashboard");
        }

        public IActionResult ViewHero(int id)
        {
            try
            {
                var hero = _context.Heroes.Where(a => a.Id.Equals(id)).FirstOrDefault();
                return View(hero);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to find Hero data. " +
                                                  "Please try again. If the issue persists, " +
                                                  "please contact your system administrator.");
                return RedirectToAction("UserDashboard");
            }
        }

        public IActionResult EditHero(int id)
        {
            try
            {
                var hero = _context.Heroes.Where(a => a.Id.Equals(id)).FirstOrDefault();
                return View(hero);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to find Hero data. " +
                                                  "Please try again. If the issue persists, " +
                                                  "please contact your system administrator.");
                return RedirectToAction("UserDashboard");
            }
        }

        [HttpPost]
        public IActionResult EditHero(Hero hero)
        {
            try
            {
                _context.Entry(hero).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("ViewHero", new { id = hero.Id });
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save Hero data." +
                                             "Please try again. If the issue persists, " +
                                             "please contact your system administrator.");

            }
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save User data." +
                                             "Please try again. If the issue persists, " +
                                             "please contact your system administrator.");
            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = _context.Users.Where(a => a.EmailAddress.Equals(user.EmailAddress) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetInt32("UserId", obj.Id);
                        HttpContext.Session.SetString("UserName", obj.UserName);
                        return RedirectToAction("UserDashboard");
                    }
                }
                catch(Exception)
                {
                    ModelState.AddModelError("", "Unable to find User data." +
                             "Please try again. If the issue persists, " +
                             "please contact your system administrator.");
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult UserDashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int userId = HttpContext.Session.GetInt32("UserId").Value;
                return View(GetUserByUserId(userId));
            }
            else { return RedirectToAction("Login"); }
        }
    }
}
