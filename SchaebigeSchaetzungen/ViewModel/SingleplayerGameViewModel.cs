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

        private int views;
        public int Views
        {
            get
            {
                return views;
            }
            set
            {
                views = value;
                OnPropertyChanged(nameof(views));
            }
        }
        public ICommand GameEndCommand { get; }
 

        public SingleplayerGameViewModel(
            NavigationStore navigationStore,
            Game game,
            Func<GameEndViewModel> createGameEndViewModel)
        {
            this.Game = game;
            game.PlayerOne.Guess=0;
            game.PlayerOne.GamePoints=0;
            //abmelden des zweiten Players
            game.PlayerTwo=null;
            this.GameEndCommand = new NavigateCommand(navigationStore, game, createGameEndViewModel);
          
        }
    }
}
