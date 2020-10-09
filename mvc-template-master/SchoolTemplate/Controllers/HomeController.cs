using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
    public class HomeController : Controller
    {
        // zorg ervoor dat je hier je gebruikersnaam (leerlingnummer) en wachtwoord invult
        string connectionString = "Server=172.16.160.21;Port=3306;Database=110242;Uid=110242;Pwd=ENTypoTi;";

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            // uncomment deze regel om producten uit je database toe te voegen
            //products = GetProducts();

            return View(GetFestivals());
        }       

        [Route("events")]
        public IActionResult Events()
        {
            return View();
        }

        [Route("gallery")]
        public IActionResult Galerij()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("festival/{id}")]
        public IActionResult Festival(string id)
        {
            ViewData["id"] = id;

            return View();
        }

        [Route("contact")]
        public IActionResult Contact()

        {
            return View();
        }

        [Route("contact")]
        [HttpPost]
        public IActionResult Contact(PersonModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            SavePerson(model);

            ViewData["formsuccess"] = "ök";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });  
        }

        private List<Festival> GetFestivals()
        {
            List<Festival> festivals = new List<Festival>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from festival", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival f = new Festival
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Voornaam = reader["voornaam"].ToString(),
                            Achternaam = reader["achternaam"].ToString(),
                            Email = reader["email"].ToString(),
                            Datum = DateTime.Parse(reader["geb_datum"].ToString()),
                        };
                        festivals.Add(f);
                    }
                }
            }

            return festivals;
        }

        private void SavePerson(PersonModel person)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO klant(voornaam, achternaam, emailadres, geb_datum) VALUES(?voornaam, ?achternaam, ?email, ?geb_datum)", conn);

                cmd.Parameters.Add("?voornaam", MySqlDbType.VarChar).Value = person.voornaam;
                cmd.Parameters.Add("?achternaam", MySqlDbType.VarChar).Value = person.achternaam;
                cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = person.email;
                cmd.Parameters.Add("?geb_datum", MySqlDbType.VarChar).Value = person.geb_datum;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
