using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
    public class PersonModel //this public class will link to the home controller under the HttpPost of [Route("Contact")]
    {
        public string voornaam { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht / Last name is required")] //one of three error messages that pops up when this area is not filled in, and the person presses the submit button to execute the data
        public string achternaam { get; set; }

        [Required(ErrorMessage = "Mailadres is verplicht / E-mail adress is required")]
        [EmailAddress(ErrorMessage = "Ongeldige mailadres / E-mail adress invalid")]
        public string email { get; set; }

        public DateTime geb_datum { get; set; }

        public string commentaar { get; set; }

    }
}

