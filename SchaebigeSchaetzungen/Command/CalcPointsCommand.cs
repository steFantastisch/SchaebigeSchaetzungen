﻿using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Command
{
    public class CalcPointsCommand : CommandBase
    {
        private Game game;
        int P1guess;
        int P2guess;



        public CalcPointsCommand(Game game)
        {

            this.game = game;
            this.P1guess = game.PlayerOne.Guess;
            if (game.PlayerTwo!=null)
            {
                this.P2guess = game.PlayerTwo.Guess;
            }
        }

        public string SingleplayerPts(int Playerguess, int Views)
        {
            int pts = 1;
            string txt = ">>> Views: " + Views.ToString() + " <<<    --> " + pts + " Punkte";
            return txt;
        }

        public string MultiplayerPtns(int P1guess, int P2guess, int Views)
        {
            int P1pts = 1;
            int P2pts = 1;
            string txt = ">>> Views: " + Views.ToString() + " <<<    \n--> P1 : " + P1pts + " Punkte || P2 : " + P2pts + "Punkte";
            return txt;
        }

        public override void Execute(object parameter)
        {
            return;
           
        }
    }
}