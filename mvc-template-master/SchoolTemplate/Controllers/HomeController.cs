using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
    public class HomeController : Controller
    {
        // zorg ervoor dat je hier je gebruikersnaam (leerlingnummer) en wachtwoord invult
        string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110242;Uid=110242;Pwd=ENTypoTi;";

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            // uncomment deze regel om producten uit je database toe te voegen
            //products = GetProducts();

            return View(GetEvents());
        }

        //The following from rows 28 to 60 are to make the webpages visible. These could vary for
        //every website

        [Route("events")]
        public IActionResult Events() //fetches events from database
        {
            var events = GetEvents();
            return View(events);
        }

        [Route("gallery")]
        public IActionResult Galerij() //makes the gallery page visible
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy() //makes the privacy policy page visible, even though it is unnecessary at the moment
        {
            return View();
        }

        [Route("details")]
        public IActionResult Details() //makes the details page visible; this page is accessible via the events page
        {
            //ViewData["id"] = id;
            var events = GetEvents();
            return View(events);
        }

        [Route("contact")]
        public IActionResult Contact() //makes the contact page visible

        {
            return View();
        }

        [Route("contact")]
        [HttpPost]
        public IActionResult Contact(PersonModel model) //connects the contact page with the PersonModel file
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

        private List<Event> GetEvents() //from here to row 113 events will be fetched from the database
        {
            List<Event> contact = new List<Event>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from event", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event f = new Event
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Plaats = reader["plaats"].ToString(),
                            Datumtijd = DateTime.Parse(reader["datumtijd"].ToString()),
                            Beschrijving = reader["beschrijving"].ToString(),
                            Prijs = float.Parse(reader["prijs"].ToString()),
                            //Img = Blob.Equals(reader[""])

                        };
                        contact.Add(f);
                    }
                }
            }

            return contact;
        }

        private void SavePerson(PersonModel person) //this private void will collect all details filled in
                                                    //and will execute the query and add those in the database
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO contact(voornaam, achternaam, email, geb_datum, commentaar) VALUES(?voornaam, ?achternaam, ?email, ?geb_datum, ?commentaar)", conn);

                cmd.Parameters.Add("?voornaam", MySqlDbType.VarChar).Value = person.voornaam;
                cmd.Parameters.Add("?achternaam", MySqlDbType.VarChar).Value = person.achternaam;
                cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = person.email;
                cmd.Parameters.Add("?geb_datum", MySqlDbType.Date).Value = person.geb_datum;
                cmd.Parameters.Add("?commentaar", MySqlDbType.VarChar).Value = person.commentaar;
                cmd.ExecuteNonQuery();
            }
        }
    }
}

//end of cs-file