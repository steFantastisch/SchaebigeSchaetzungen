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
    public class CreateViewModel : ViewModelBase
    {
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
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
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        public ICommand FinishCommand { get; }
        public ICommand CancelCommand { get; }


		public CreateViewModel(NavigationStore navigationStore, Game game, Func<LoginPlayerOneViewModel> createUserCredentialViewModel, Func<GameModeSelectionViewModel> createGameModeSelectionViewModel)
		{
            
			//this.FinishCommand = new NavigateCommand(navigationStore, game, createGameModeSelectionViewModel);
            //TODO Avatar
            this.Game= game;
            //this.Player=new Player();

			//this.FinishCommand = new CreatePlayerCommand(game,this.Player);
            
            this.CancelCommand = new NavigateCommand(navigationStore, game, createUserCredentialViewModel);
        }
    }
}
