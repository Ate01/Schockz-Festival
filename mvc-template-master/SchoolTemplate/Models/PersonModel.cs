using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
    public class PersonModel
    {
        public string voornaam{ get; set; }

        [Required]
        public string achternaam { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public DateTime geboortedatum { get; set; }
    }
}
