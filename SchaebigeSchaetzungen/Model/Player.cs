using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Xps;

namespace SchaebigeSchaetzungen.Model
{

    public class Player
    {
        private int playerID;

        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private int crowns;

        public int Crowns
        {
            get { return crowns; }
            set { crowns = value; }
        }


        private Avatar image;

        public Avatar Avatar
        {
            get { return image; }
            set { image = value; }
        }

        private bool fishcard;
        public bool Fishcard
        {
            get { return fishcard; }
            set { fishcard = value; }
        }

        private int points;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        private int guess;
        public int Guess
        {
            get { return guess; }
            set { guess = value; }
        }



        /// <summary>
        /// LOGIN
        /// </summary>
        /// <param name="password"></param>
        /// <param name="mail"></param>
        public Player(string password, string mail)
        {
            Password=password;
            Mail=mail;
           // DBPlayer.Read(this);
        }

        /// <summary>
        /// SIGN UP
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="mail"></param>
        public Player(string name ,string password, string mail)
        {
            Password=password;
            Mail=mail;
            Name=name;
            //TODO Avatar ?
            // DBPlayer.Insert(this);  liebr manuell immer sorgt sonst für verwirrung
        }
        public Player()
        {
           //TEMP
        }

    }
}
