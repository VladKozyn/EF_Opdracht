using System;
using System.Collections.Generic;
using System.Text;

namespace EFlibrary
{
    public class Transfer
    {
        public int Id { get; set; }
        public Speler Speler { get; set; }
        public int SpelerWaarde{ get; set; }
        public Team oudTeam { get; set; }
        public Team nieuwTeam { get; set; }
        public int SpelerId { get; set; }
        public int NieuwTeamId { get; set; }

        public Transfer(Speler speler, int spelerWaarde, Team nieuwTeam)
        {
            Speler = speler;
            SpelerWaarde = spelerWaarde;
            this.nieuwTeam = nieuwTeam;
        }

        public Transfer(int spelerWaarde, int spelerId, int nieuwTeamId)
        {
            SpelerWaarde = spelerWaarde;
            SpelerId = spelerId;
            NieuwTeamId = nieuwTeamId;
        }
    }
}
