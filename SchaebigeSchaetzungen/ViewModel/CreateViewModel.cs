using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class CreateViewModel : ViewModelBase
    {
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value;
               this.Player.Name=Name;
                OnPropertyChanged(nameof(Name));
            }
		}

		private string mail;

		public string Mail
		{
			get { return mail; }
			set { mail = value;
				this.Player.Mail=mail;
                OnPropertyChanged(nameof(Mail));
            }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value;
               this.Player.Password=Password;
                OnPropertyChanged(nameof(Password));
            }
		}
        private Player p;
        public Player Player
        {
            get { return p; }
            set { p = value; }
        }

        private Game game;
        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        public ICommand CancelCommand { get; }
        public ICommand CreateCommand { get; }


		public CreateViewModel(NavigationStore navigationStore, Game game, Func<LoginPlayerOneViewModel> createUserCredentialViewModel, Func<GameModeSelectionViewModel> createGameModeSelectionViewModel)
		{
            p = new Player();
            p.Mail=Mail;
            p.Password=Password;
            p.Name=Name;

            this.Game= game;       
            this.CancelCommand = new NavigateCommand(navigationStore, game, createUserCredentialViewModel);
            this.CreateCommand = new CreatePlayerCommand(navigationStore, game, createUserCredentialViewModel,p);
        }
    }
}
