using Google.Apis.YouTube.v3;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{

  
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

        private int currentViews;
        public int CurrentViews
        {
            get { return currentViews; }
            set { currentViews = value; }
        }
     

        public Game()
        {

        }

    }
}
