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
    public class LoginPlayerTwoViewModel : ViewModelBase
    {
        public LoginPlayerTwoViewModel(NavigationStore navigationStore, Game game, Func<MultiplayerGameViewModel> createMultiplayerGameViewModel)
        {
           
            this.Game = game;
            if (this.Game.PlayerTwo == null)
            {
                this.Game.PlayerTwo = new Player();
                //TODO DELETE FOLLOWING LINE
                Game.PlayerTwo.Mail = "Simon@Stenzel.de";
                game.PlayerTwo.Name = "tempname2";
            }
            this.StartCommand = new NavigateCommand(navigationStore, Game, createMultiplayerGameViewModel);
        }
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
               this.Game.PlayerTwo.Name = username;
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

        private Player playerTwo;

        public Player PlayerTwo
        {
            get { return playerTwo; }
            set { playerTwo = value; }
        }
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }



        public ICommand StartCommand { get; }

        
    }
}
