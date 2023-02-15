using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class MultiplayerGameViewModel : ViewModelBase
    {
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }



        public ICommand GameEndCommand { get; }

        public MultiplayerGameViewModel(
            NavigationStore navigationStore,
            Game game,
            Func<GameEndViewModel> createGameEndViewModel)
        {
           
            this.Game = game;
            game.PlayerOne.GamePoints=0;
            game.PlayerTwo.GamePoints=0;
            this.GameEndCommand = new NavigateCommand(navigationStore, game, createGameEndViewModel);

        }
    }
}

