using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
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
            game.PlayerOne=null; //PlayerOne wird abgemeldet
            if (this.Game.PlayerOne == null)
            {
                this.Game.PlayerOne = new Player();
                
                game.PlayerOne.Mail = Username;
                game.PlayerOne.Password=Password;
                //TODO delete the following lines for no prefilled pw and mail
                game.PlayerOne.Mail = "webde";
                game.PlayerOne.Password = "1234";
            }
            


            this.CreateCommand = new NavigateCommand(navigationStore, Game, createCreateViewModel);
            this.LoginCommand= new LoginCheckCommand(navigationStore, Game, createGameModeSelectionViewModel, game.PlayerOne);
            //this.LoginCommand = new NavigateCommand(navigationStore, Game, createGameModeSelectionViewModel);
            
        }
    }
}
