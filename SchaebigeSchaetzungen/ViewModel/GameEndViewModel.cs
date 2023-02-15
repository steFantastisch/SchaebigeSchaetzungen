using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
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
          
           Func<SingleplayerGameViewModel> createSingleplayerGameViewModel, Func<MultiplayerGameViewModel> createMultiplayerGameViewModel, Func<HighscoreViewModel> createHighscoreViewModel)
        {
            this.Game = game;
            DBPlayer.UpdateCrowns( game.PlayerOne);
           
            this.HighscoreCommand = new NavigateCommand(navigationStore, game, createHighscoreViewModel);

            //TODO nächste Zeile checken ob SIngle oder multiplayer ist
            if (game.PlayerTwo==null)
                {
                this.PlayagainCommand = new NavigateCommand(navigationStore, game, createSingleplayerGameViewModel);
            }
            else{
                DBPlayer.UpdateCrowns(game.PlayerTwo);
                this.PlayagainCommand = new NavigateCommand(navigationStore, game, createMultiplayerGameViewModel);
            }
            
            this.ExitCommand = new NavigateCommand(navigationStore, game, createGameModeSelectionViewModel);
        }

    }
}
