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
    public class SingleplayerGameViewModel : ViewModelBase
    {
     
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }



        public ICommand GameEndCommand { get; }
        public ICommand CalculatePts { get; }

        public SingleplayerGameViewModel(
            NavigationStore navigationStore,
            Game game,
            Func<GameEndViewModel> createGameEndViewModel)
        {
            this.Game = game;
            this.GameEndCommand = new NavigateCommand(navigationStore, game, createGameEndViewModel);
            this.CalculatePts = new CalcPointsCommand(game);
        }
    }
}
