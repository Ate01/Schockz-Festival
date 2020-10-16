using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
    public class PersonModel //this public class will link to the home controller under the HttpPost of [Route("Contact")]
    {
        public string voornaam { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht / Last name is required")]
        public string achternaam { get; set; }

        [Required(ErrorMessage = "Mailadres is verplicht / E-mail adress is required")]
        [EmailAddress(ErrorMessage = "Ongeldige mailadres / E-mail adress invalid")]
        public string email { get; set; }

        public DateTime geb_datum { get; set; }

        public string commentaar { get; set; }

    }
}

