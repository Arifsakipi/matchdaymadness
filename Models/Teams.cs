﻿using System.ComponentModel.DataAnnotations;

namespace MatchdayMadness2.Models
{
    public class Teams
    {
        [Key]
        public int id { get; set; }
        public string? Name { get; set; }
        public string? League { get; set; }
        public string? Coach { get; set; }
        public string? Formation { get; set; }
        public string? Stadium { get; set; }
        public int? MatchesPlayed { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        public int? Draws { get; set; }

        public virtual List<Players> Players { get; set; }
        public virtual List<Favorites> Favorites { get; set; }
        public virtual List<Matches> Matches { get; set; }
        public virtual List<Table> Tables { get; set; }
        public virtual List<Matches> HomeMatches { get; set; }
        public virtual List<Matches> AwayMatches { get; set;}
       
    }
}
