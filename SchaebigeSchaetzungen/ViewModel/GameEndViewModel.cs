﻿using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class GameEndViewModel : ViewModelBase
    {

        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        public ICommand HighscoreCommand { get; }
        public ICommand PlayagainCommand { get; }
        public ICommand ExitCommand { get; }

        public GameEndViewModel(
           NavigationStore navigationStore,
           Game game,
          Func<GameModeSelectionViewModel> createGameModeSelectionViewModel,
          
           Func<SingleplayerGameViewModel> createSingleplayerGameViewModel)
        {
            this.Game = game;
            //this.HighscoreCommand = new NavigateCommand(navigationStore, game, createHighscoreGameViewModel);
            this.PlayagainCommand = new NavigateCommand(navigationStore, game, createSingleplayerGameViewModel);
            this.ExitCommand = new NavigateCommand(navigationStore, game, createGameModeSelectionViewModel);
        }

    }
}