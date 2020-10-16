using System;

namespace SchoolTemplate.Database
{
public class Contact
    {
        public int id { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public DateTime geb_datum { get; set; }

        public string Email { get; set; }

        public string Commentaar { get; set; }
    }
}
