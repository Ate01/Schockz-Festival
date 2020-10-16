using System;

namespace SchoolTemplate.Database
{
    public class Event //this public class links to the public class event in the home controller
    {
        public int id { get; set; } //primary key of database, always shown as an integer

        public string Plaats { get; set; } //string in database

        public DateTime Datumtijd { get; set; } //date and time in database

        public string Beschrijving { get; set; }

        public float Prijs { get; set; } //value of float number in database

        //public string Img { get; set; }
    }
}

//end of cs-file