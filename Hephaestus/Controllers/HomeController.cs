using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hephaestus.Data;
using Microsoft.AspNetCore.Mvc;
using Hephaestus.Models;

namespace Hephaestus.Controllers
{

    public class HomeController : Controller
    {
        private string strConnectionString = Environment.GetEnvironmentVariable("HephaestusDB");

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
                                (int) dataReader["Id"]
                                , (string) dataReader["Epithet"]
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

        //[HttpPost]
        //public ActionResult CreateHero(Hero hero)
        //{
        //    HephaestusContext context = new HephaestusContext(strConnectionString);
        //    context.Heroes.Add(hero);
        //    return View("CreateHero");
        //}

        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
