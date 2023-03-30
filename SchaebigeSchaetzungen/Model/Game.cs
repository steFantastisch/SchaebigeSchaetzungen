using System;

namespace SchaebigeSchaetzungen.Model
{

  
    public class Game
    {
        private IPointsCalculator _pointsCalculator;
        public IPointsCalculator PointsCalculator
        {
            get { return _pointsCalculator; }
        }

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

        public Game(IPointsCalculator pointsCalculator)
        {
            _pointsCalculator = pointsCalculator;
        }

    }
}
