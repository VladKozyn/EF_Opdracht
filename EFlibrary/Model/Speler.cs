using System;
using System.Collections.Generic;
using System.Text;

namespace EFlibrary
{
    public class Speler
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Rugnummer { get; set; }
        public int Waarde { get; set; }
        public int TeamStamnummer { get; set; }

        public Team Team { get; set; }

        public Speler(string naam, int rugnummer, int waarde, int teamStamnummer)
        {
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;
            TeamStamnummer = teamStamnummer;
        }
        public Speler(string naam, int rugnummer, int waarde, Team team)
        {
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;
            Team = team;
        }
    }
}
