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

namespace Hephaestus.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly HephaestusContext _context;

        public HomeController(HephaestusContext context)
        {
            _context = context;
        }

        private readonly string strConnectionString = Environment.GetEnvironmentVariable("HephaestusDB");

        private List<Models.Hero> GetHeroesByUserId(int userId)
        {
            List<Models.Hero> lstHeroes = new List<Hero>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConnectionString))
                {
                    sqlConnection.Open();
                    string strCmd =
                        @"SELECT
                            Id
                            ,Epithet
                            ,EpithetDie
                            ,Name
                            ,NameDie
                            ,Lineage
                            ,IsDemigod
                            ,Pronouns
                            ,HonoredGod
                            ,Strength
                            ,ArtsAndOrationDie
                            ,BloodAndValorDie
                            ,CraftAndReasonDie
                            ,ResolveAndSpiritDie
                            ,FavorGodName1
                            ,FavorGodName2
                            ,FavorGodName3
                            ,FavorGodName4
                            ,FavorScore1
                            ,FavorScore2
                            ,FavorScore3
                            ,FavorScore4
                            ,Notes
                            ,UserId
                           WHERE
                                UserId = " + userId.ToString();

                    using (SqlCommand sqlCommand = new SqlCommand(strCmd, sqlConnection))
                    {
                        System.Data.IDataReader dataReader = sqlCommand.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Hero hero = new Hero(
                                (string) dataReader["Epithet"]
                                , (int) dataReader["EpithetDie"]
                                , (string) dataReader["Name"]
                                , (int) dataReader["NameDie"]
                                , (string) dataReader["Lineage"]
                                , (bool) dataReader["IsDemigod"]
                                , (string) dataReader["Pronouns"]
                                , (string) dataReader["HonoredGod"]
                                , (string) dataReader["Strength"]
                                , (int) dataReader["ArtsAndOrationDie"]
                                , (int) dataReader["BloodAndValorDie"]
                                , (int) dataReader["CraftAndReasonDie"]
                                , (int) dataReader["ResolveAndSpiritDie"]
                                , (string) dataReader["FavorGodName1"]
                                , (string) dataReader["FavorGodName2"]
                                , (string) dataReader["FavorGodName3"]
                                , (string) dataReader["FavorGodName4"]
                                , (int) dataReader["FavorScore1"]
                                , (int) dataReader["FavorScore2"]
                                , (int) dataReader["FavorScore3"]
                                , (int) dataReader["FavorScore4"]
                                , (string) dataReader["Notes"]
                                , (int) dataReader["UserId"]
                            );
                            lstHeroes.Add(hero);
                        }

                        dataReader.Close();
                        dataReader.Dispose();
                    }
                }

                return lstHeroes;
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
            return View();
        }


        [HttpPost]
        public IActionResult CreateHero(Hero hero)
        {
            try
            {
                _context.Heroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save Hero data." +
                                             "Please try again. If the issue persists, " +
                                             "please contact your system administrator.");

            }

            return View(hero);
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
    }
}
