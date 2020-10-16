using System;

namespace SchoolTemplate.Database
{
    public class Event
    {
        public int id { get; set; }

        public string Plaats { get; set; }

        public DateTime Datumtijd { get; set; }

        public string Beschrijving { get; set; }

        public float Prijs { get; set; }

        //public string Img { get; set; }
    }
}