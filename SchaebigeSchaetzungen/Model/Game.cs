using Google.Apis.YouTube.v3;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{

    public enum Gamemode
    {
        Singleplayer,
        Multiplayer
    }

    public class Game
    {
        private Player playerOne;

        public Player? PlayerOne
        {
            get { return playerOne; }
            set { playerOne = value; }
        }

        private Player? playerTwo;

        public Player? PlayerTwo
        {
            get { return playerTwo; }
            set { playerTwo = value; }
        }

        private Gamemode gamemode;

        public Gamemode Gamemode
        {
            get { return gamemode; }
            set { gamemode = value; }
        }

        private int currentViews;
        public int CurrentViews
        {
            get { return currentViews; }
            set { currentViews = value; }
        }
        private List<Video> playlist;

        public List<Video> Playlist
        {
            get { return playlist; }
            set { playlist = value; }
        }


        public Game()
        {

        }

        public Game(Player playerOne, Player playerTwo, Gamemode gamemode)
        {
            this.PlayerOne = playerOne;
            this.PlayerTwo = playerTwo;
            this.Gamemode = gamemode;


            playerOne.Points = 0;
            playerTwo.Points = 0;
        }

    }
}
