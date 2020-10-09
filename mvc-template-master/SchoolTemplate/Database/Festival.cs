using System;

namespace SchoolTemplate.Database
{
public class Contact
    {
        public int id { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public DateTime Datum { get; set; }

        public string Email { get; set; }
   }
}
