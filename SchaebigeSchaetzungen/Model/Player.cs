using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{

    internal class Player
    {
        public Player(string name, string passwort, string mail)
        {
            Name=name;
            Passwort=passwort;
            Mail=mail;
            Crowns=1000;
        }

        public string Name {get; set;}
        public string Passwort {get; set;}
        public string Mail { get; set; }
        public int Crowns { get; set; }
        //avatar?

    }
}
