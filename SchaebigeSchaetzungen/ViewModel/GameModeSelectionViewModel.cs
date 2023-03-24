using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class GameModeSelectionViewModel : ViewModelBase
    {
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }



        public ICommand SingleplayerCommand { get; }
        public ICommand MultiplayerCommand { get; }
        public ICommand CancelCommand { get; }

        public GameModeSelectionViewModel(
            NavigationStore navigationStore, 
            Game game,
            Func<LoginPlayerOneViewModel> createLoginPlayerOneViewModel, 
            Func<LoginPlayerTwoViewModel> createLoginPlayerTwoViewModel, 
            Func<SingleplayerGameViewModel> createSingleplayerGameViewModel)
        {
            this.Game = game;
            this.SingleplayerCommand = new NavigateCommand(navigationStore, game, createSingleplayerGameViewModel);
            this.MultiplayerCommand = new NavigateCommand(navigationStore, game, createLoginPlayerTwoViewModel);
            this.CancelCommand = new NavigateCommand(navigationStore, game, createLoginPlayerOneViewModel);
        }
    }
}
