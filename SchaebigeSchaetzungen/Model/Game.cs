﻿using SchaebigeSchaetzungen.Persistence;
using System;

namespace SchaebigeSchaetzungen.Model
{


    public class Game
    {


        public IDBPlayer dBPlayer;
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


        public static int[] CalculateMultiplayerPoints(int P1guess, int P2guess, int Views)
        {

            double percentageDifference;
            int maxScore = 100; // Maximal erreichbare Punktzahl

            if (Views > P1guess)
            {
                percentageDifference = (double)(Views - P1guess) / Views;
            }
            else
            {
                percentageDifference = (double)(P1guess - Views) / P1guess;
            }

            int[] pts = new int[2];

            pts[0] =maxScore - (int)(percentageDifference * maxScore);

            if (Views > P2guess)
            {
                percentageDifference = (double)(Views - P2guess) / Views;
            }
            else
            {
                percentageDifference = (double)(P2guess - Views) / P2guess;
            }

            pts[1] =maxScore - (int)(percentageDifference * maxScore);

            return pts;
        }

        public static string SingleplayerPts(int Playerguess, int Views)
        {

            double percentageDifference;
            int maxScore = 100; // Maximal erreichbare Punktzahl

            if (Views > Playerguess)
            {
                percentageDifference = (double)(Views - Playerguess) / Views;
            }
            else
            {
                percentageDifference = (double)(Playerguess - Views) / Playerguess;
            }

            int score = maxScore - (int)(percentageDifference * maxScore);

            // Optionale Begrenzung der Punktzahl auf einen minimalen Wert 
            score = Math.Max(score, 0);

            return score.ToString();
        }

        public Game(IDBPlayer _dbPlayer)
        {
            dBPlayer=_dbPlayer;
        }

    }
}
