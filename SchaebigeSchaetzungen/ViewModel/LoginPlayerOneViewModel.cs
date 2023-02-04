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
    public class LoginPlayerOneViewModel : ViewModelBase
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                this.Game.PlayerOne.Name = username;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }


        public ICommand LoginCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand HelpCommand { get; }



        public LoginPlayerOneViewModel(NavigationStore navigationStore, Game game, Func<CreateViewModel> createCreateViewModel, Func<GameModeSelectionViewModel> createGameModeSelectionViewModel)
        {

            this.Game = game;
            if (this.Game.PlayerOne == null)
            {
                this.Game.PlayerOne = new Player();
                //TODO Delete following Line
                game.PlayerOne.Name = "Stefan";
            }


            this.CreateCommand = new NavigateCommand(navigationStore, Game, createCreateViewModel);
            this.LoginCommand = new NavigateCommand(navigationStore, Game, createGameModeSelectionViewModel);
        }
    }
}
