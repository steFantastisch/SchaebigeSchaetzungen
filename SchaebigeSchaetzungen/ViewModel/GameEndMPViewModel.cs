using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using SchaebigeSchaetzungen.Store;
using System;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class GameEndMPViewModel : ViewModelBase
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

     

        public GameEndMPViewModel(
           NavigationStore navigationStore,
           Game game,
          Func<GameModeSelectionViewModel> createGameModeSelectionViewModel,
          Func<MultiplayerGameViewModel> createMultiplayerGameViewModel, Func<HighscoreViewModel> createHighscoreViewModel)
        {
            this.Game = game;
            game.DBPlayer.UpdateCrowns(game.PlayerOne);
            game.DBPlayer.UpdateCrowns(game.PlayerTwo);

            this.HighscoreCommand = new NavigateCommand(navigationStore, game, createHighscoreViewModel);
            this.PlayagainCommand = new NavigateCommand(navigationStore, game, createMultiplayerGameViewModel);

            this.ExitCommand = new NavigateCommand(navigationStore, game, createGameModeSelectionViewModel);
        }

    }
}
