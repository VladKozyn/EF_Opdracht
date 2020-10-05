using EFlibrary;
using System;

namespace EFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataInteractie di = new DataInteractie();
            //  di.initializeerDatabank();
            //di.VoegTeamToe(new Team(10, "test", "tst", "nope"));
           Console.WriteLine(di.SelecteerTeam(3).Naam);
        }
    }
}
