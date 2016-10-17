using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLeague
{

    // Override the ToString() method of each class to convert to string.
    // Write the output of the methods on Sport to an HTML file --> <project dir>\html\index.html
    // In index.html write out the results of getAllTeams(), getPlayerOfTheYear(), and getCoachOfTheYear()
    class Program
    {
        static void Main(string[] args)
        {
            var texasHockey = new Sport("Texas Hockey League", TypeOfSport.Hockey);

            var leagues = "Eastern Conference, Western Conference"
                .Split(new char[] { ',' })
                .Select(s => new League(s.Trim()));
            var eastConf = leagues.First();
            var westConf = leagues.ElementAt(1);
            texasHockey.leagues = leagues.Concat(texasHockey.leagues);

            // Add teams to eastConf
            var easternTeams = "Texas Wildcatters, Houston Huskies, Corpus Christi IceRays"
                .Split(new char[] { ',' })
                .Select(s => new Team(s.Trim()));
            //var east = texasHockey.leagues.First();
            eastConf.teams = eastConf.teams.Concat(easternTeams);
            // texasHockey.leagues.teams = texasHockey.leagues.teams.Concat(easternTeams);

            // Add players and coaches to eastConf teams
            var cattersPlayers = "Kean Cansu, Colin Harper, Ella Byrd, Mark Meyer, Mack Green"
                .Split(new char[] { ',' })
                .Select(s => new Player(s.Trim()));
            var catters = easternTeams.First();
            catters.players = catters.players.Concat(cattersPlayers);

            List<int> cattersPoints = new List<int> { 45, 22, 78, 6, 37 };
            foreach(Player player in catters.players)
            {
                foreach(int num in cattersPoints)
                {
                    player.points = num;
                } 
            }
            //    .Split(new char[] { ',' })
            //    .Select(s => catters.players(s.Trim(points)));
            //var catters.players.points = catters.players.points.Concat(cattersPoints);

            //eastConf.teams.players = eastConf.teams.players.Concat(cattersPlayers);

            //.Split(new char[] { ',' })
            //.Select(s => ;

            //Team.setPlayerPoints(catters, cattersPoints);
            //foreach (Player player in catters.players)
            //{
            //    //int points = 0;
            //    foreach (int point in cattersPoints)
            //    {
            //        player.points = point;
            //    }
            //    // return player.points;
            //}

            foreach (Player player in catters.players)
            {
                Console.Write(player.name);
                Console.WriteLine(": {0} points", player.points);
            }

            var huskiesPlayers = "Darryl Hodges, Francisco Snyder, Ray Brooks, Claudia Patterson, Bob Bowen"
                .Split(new char[] { ',' })
                .Select(s => new Player(s.Trim()));
            var huskies = easternTeams.ElementAt(1);
            huskies.players = huskies.players.Concat(huskiesPlayers);


            var iceRaysPlayers = "Jo Cain, Tyler Adkins, Shannon Rivera, Darin Bryan, Dawn Matthews"
                .Split(new char[] { ',' })
                .Select(s => new Player(s.Trim()));
            var iceRays = easternTeams.ElementAt(2);
            iceRays.players = iceRays.players.Concat(huskiesPlayers);


            // Add teams to westConf
            var westernTeams = "Amarillo Gorillas, El Paso Raiders, San Antonio Iguanas"
                .Split(new char[] { ',' })
                .Select(s => new Team(s.Trim()));
            westConf.teams = westConf.teams.Concat(westernTeams);

            // Add players to westConf teams


            // Testing structure
            Console.Write(texasHockey.name);
            Console.WriteLine(": {0}", TypeOfSport.Hockey);
            foreach (Player player in catters.players)
            {
                Console.Write(player.name);
                Console.WriteLine(": {0} points", player.points.ToString());
            }

            //Directory.CreateDirectory("html");
            //File.WriteAllText(@"html/index.html", texasHockey.ToString());

            Console.ReadLine();
        }
    }

    public enum TypeOfSport
    {
        Baseball,
        Football,
        Hockey,
        Soccer,
        Volleyball,
        Polo
    }

    public class Sport
    {
        public IEnumerable<League> leagues = new List<League>(); // need to initialize here?
        // added
        public IEnumerable<Team> teams = new List<Team>();

        public TypeOfSport sport;
        public string name;

        public Sport(string name, TypeOfSport sport)
        {
            this.name = name;
            this.sport = sport;
        }

        //public override string ToString()
        //{
        //    // All this is in the wrong spot??????
        //    string html = @"<!DOCTYPE html>
        //                    <html>
        //                    <head>
        //                        <title></title>
        //                        <link href=""..."" type=""text/css"" rel=""stylesheet"">
        //                    </head>
        //                    <body>
        //                        <h1>Awards<h1>
        //                        <p>Player of the Year: {0}</p>
        //                        <p>Coach of the Year: {1}</p>
        //                        <h1>Teams</h1>
        //                        {2}
        //                    </body>
        //                    </html>";

        //    String.Format(html, name.getPlayerOfTheYear(), name.getCoachOfTheYear(), name.getAllTeams());
        //}

        // should return all the Teams in the Sport
        //public void getAllTeams(Sport name, IEnumerable<League> leagues)
        //{
        //    foreach (Team team in name.leagues)
        //    {
        //        return team.name.ToString();
        //    }
        //}

        // should return Player with the most points
        //public Player getPlayerOfTheYear()
        //{

        //}

        // should return the Coach whose Team's Players had the highest average points
        //public Coach getCoachOfTheYear()
        //{

        //    // override ToString()
        //}
    }

    public class League
    {
        public IEnumerable<Team> teams = new List<Team>();
        
        public string name;

        //Constructor
        public League(string name) { this.name = name; }

        public override string ToString()
        {
            return name.ToString();
        }
    }

    public class Team
    {
        public IEnumerable<Coach> coaches = new List<Coach>();
        public IEnumerable<Player> players = new List<Player>();
        public string name;
        public string hometown;

        public Team(string name)
        {
            this.name = name;
        }

        public static void setPlayerPoints(Team team, List<int> list)
        {
            foreach (Player player in team.players)
            {
                //int points = 0;
                foreach (int point in list)
                {
                    player.points = point;
                }
            }
            // return points;
        }


        //public Team(string name, string hometown)
        //{
        //    this.name = name;
        //    this.hometown = hometown;

        //}

        // override ToString() 

    }

    public class Coach
    {
        public string name;

        //Constructor
        public Coach(string name) { this.name = name; }

        // override ToString() 
    }

    public class Player
    {
        public string name;
        public int points { get; internal set; }

        public Player(string name)
        {
            this.name = name;
        }

        public Player(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        //public Player(Player p, Team t, int[] points)
        //{
        //    foreach(Player p in t)
        //}

        //public static void setPlayerPoints(Team team, List<int> list)
        //{
        //    foreach (Player player in team.players)
        //    {
        //        //int points = 0;
        //        foreach (int point in list)
        //        {
        //            player.points = point;
        //        }
        //    }
        //    // return points;
        //}

        // override ToString()
        //public override string ToString()
        //{
        //    return ($"{0}: {1}", name, points.ToString());
        //}


    }
}

