﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
       
        public Player(string name, string classs)
        {
            this.Name = name;
            this.Class = classs;
            this.Rank= Rank = "Trial";
            this.Description = Description = "n/a";
        }
        public string Rank { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");
            
            return sb.ToString().Trim();
        }
    }
}