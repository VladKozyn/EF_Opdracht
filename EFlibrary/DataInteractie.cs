using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EFlibrary
{
    public class DataInteractie
    {
        Context ctx = new Context();
        public void initializeerDatabank()
        {
            string NaamSpeler;
            int Rugnummer;
            int Waarde;
            int TeamStamnummerSpeler;

            int StamNummer;
            string NaamTeam;
            string Bijnaam;
            string Trainer;

            List<string> clubNaamAllGebruikt = new List<string>();
            clubNaamAllGebruikt.Add("");
            string currentLine;
            string[] choppedLine;
            List<Speler> listSpelers = new List<Speler>();
            List<Team> listTeams = new List<Team>();

            using (StreamReader r = new StreamReader(@"C:\Users\lieke\OneDrive\scool\prog 4\EFlibrary\foot.csv"))
            {
                r.ReadLine();
                while ((currentLine = r.ReadLine()) != null)
                {
                    choppedLine = currentLine.Split(',');
                    NaamSpeler = choppedLine[0];
                    Rugnummer = int.Parse(choppedLine[1]);
                    Waarde = int.Parse(choppedLine[3].Replace(" ",""));
                    TeamStamnummerSpeler = int.Parse(choppedLine[4]);
                    StamNummer = int.Parse(choppedLine[4]);
                    NaamTeam = choppedLine[2];
                    Bijnaam = choppedLine[6];
                    Trainer = choppedLine[5];
                    listSpelers.Add(new Speler(NaamSpeler, Rugnummer, Waarde, TeamStamnummerSpeler));
                   
                        if(!(clubNaamAllGebruikt.Contains(NaamTeam)) )
                        {
                            listTeams.Add(new Team(StamNummer, NaamTeam, Bijnaam, Trainer));
                            clubNaamAllGebruikt.Add(NaamTeam);
                        }
                    
                   
                }
            }
            using (var ctx = new Context())
            {
                ctx.Spelers.AddRange(listSpelers);
                ctx.Teams.AddRange(listTeams);
                ctx.SaveChanges();
            }
        }
        public void VoegSpelerToe(Speler speler)
        {
            ctx.Spelers.Add(speler);
            ctx.SaveChanges();
        }
        public void VoegTeamToe(Team team)
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();
        }
        public void VoegTransferToe(Transfer transfer)
        {
            if(ctx.Spelers.Any(x=>x.Id == transfer.SpelerId))
            {
                if(ctx.Teams.Any(x => x.StamNummer == transfer.NieuwTeamId))
                {
                    ctx.Transfers.Add(transfer);

                 //       var TeamUpdate = ctx.Teams.SingleOrDefault(a => a.StamNummer == transfer.NieuwTeamId);
                    var spelerUpdate = ctx.Spelers.SingleOrDefault(b => b.Id == transfer.SpelerId);

                    spelerUpdate.Waarde = transfer.SpelerWaarde;
                    spelerUpdate.TeamStamnummer = transfer.NieuwTeamId;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("team bestaat niet");
                }
            }
            else
            {
                throw new Exception("speler bestaat niet");
            }
            
        }

        public Speler SeleteerSpeler(int spelerID)
        {
            Speler speler = ctx.Spelers.Where(s => s.Id == spelerID).FirstOrDefault();
            return speler;
        }
        public Team SelecteerTeam(int stamnummer)
        {
            Team team = ctx.Teams.Where(t => t.StamNummer == stamnummer).FirstOrDefault();
            return team;
        }
        public Transfer SelecteerTransfer(int transfer)
        {
            Transfer returnTransfer = ctx.Transfers.Where(t => t.Id == transfer).FirstOrDefault();
            return returnTransfer;
        }

    }
}
