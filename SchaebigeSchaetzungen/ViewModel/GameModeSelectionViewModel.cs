using SchaebigeSchaetzungen.Command;
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
    public class GameModeSelectionViewModel : ViewModelBase
    {
<<<<<<< Updated upstream
        private Player _playerOne;
        private Game _game1;
        //Nur TEMP Variable zu testzwecken
        private string _NAMEY;
        public string nameEY
        {
            get { return _NAMEY; }
            set { _NAMEY = value; }
        }
        public Game game1
        {
            get { return _game1; }
            set { _game1 = value; }
        }
=======
        private Game game;
>>>>>>> Stashed changes

        public Game Game
        {
<<<<<<< Updated upstream
            get { return _playerOne; }
            set { _playerOne = value; }
=======
            get { return game; }
            set { game = value; }
>>>>>>> Stashed changes
        }



        public ICommand SingleplayerCommand { get; }
        public ICommand MultiplayerCommand { get; }
        public ICommand CancelCommand { get; }

        public GameModeSelectionViewModel(
<<<<<<< Updated upstream
            Player playerOne, 
            NavigationStore navigationStore,
            Game game1,
=======
            NavigationStore navigationStore, 
            Game game,
>>>>>>> Stashed changes
            Func<LoginPlayerOneViewModel> createLoginPlayerOneViewModel, 
            Func<LoginPlayerTwoViewModel> createLoginPlayerTwoViewModel, 
            Func<SingleplayerGameViewModel> createSingleplayerGameViewModel)
        {
<<<<<<< Updated upstream
         
            this._playerOne = playerOne;
            this.game1 = game1;
            nameEY = game1.PlayerOne.Name;
            this.SingleplayerCommand = new NavigateCommand(navigationStore, createSingleplayerGameViewModel, game1);
            this.MultiplayerCommand = new NavigateCommand(navigationStore, createLoginPlayerTwoViewModel, game1);
            this.CancelCommand = new NavigateCommand(navigationStore, createLoginPlayerOneViewModel, game1);
=======
            this.Game = game;
            this.SingleplayerCommand = new NavigateCommand(navigationStore, game, createSingleplayerGameViewModel);
            this.MultiplayerCommand = new NavigateCommand(navigationStore, game, createLoginPlayerTwoViewModel);
            this.CancelCommand = new NavigateCommand(navigationStore, game, createLoginPlayerOneViewModel);
>>>>>>> Stashed changes
        }
    }
}
