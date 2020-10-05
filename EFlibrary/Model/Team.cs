using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFlibrary
{
   public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StamNummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> Spelers { get; set; } = new List<Speler>();


        public Team(int stamNummer, string naam, string bijnaam, string trainer)
        {
            StamNummer = stamNummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;
        }
        public Team(int stamNummer, string naam, string bijnaam, string trainer,List<Speler> spelers)
        {
            StamNummer = stamNummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;
            Spelers = spelers;
        }
    }
}
