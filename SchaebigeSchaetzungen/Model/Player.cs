﻿namespace SchaebigeSchaetzungen.Model
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

        /// <summary>
        /// overall Points
        /// </summary>
        public int Crowns
        {
            get { return crowns; }
            set { crowns = value; }
        }

        /// <summary>
        /// Punkte in der derzeitigen RUNDE
        /// </summary>
        private int points;
        public int Points
        {
            get { return points; }
            set
            {
                points = value;
                GamePoints=GamePoints+value;
                Crowns=Crowns+value;
            }
        }

        /// <summary>
        /// Punkte im Gesamten Spiel
        /// </summary>
        private int gamepoints;
        public int GamePoints
        {
            get { return gamepoints; }
            set { gamepoints = value; }
        }


        private int guess;
        public int Guess
        {
            get { return guess; }
            set { guess = value; }
        }

        /// <summary>
        /// SIGN UP
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="mail"></param>
        public Player(string name, string password, string mail)
        {
            Password=password;
            Mail=mail;
            Name=name;
            // DBPlayer.Insert(this);  liebr manuell immer sorgt sonst für verwirrung
        }

        public Player()
        {
            //TEMP
        }

    }
}
