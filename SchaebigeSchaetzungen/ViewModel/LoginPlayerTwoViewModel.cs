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

        private Player playerOne;

        public Player PlayerOne
        {
            get { return playerOne; }
            set { playerOne = value; }
        }



        public ICommand StartCommand { get; }

<<<<<<< Updated upstream
        public LoginPlayerTwoViewModel(NavigationStore navigationStore, Game game1, Func<MultiplayerGameViewModel> createMultiplayerGameViewModel, Player playerOne)
=======
        public LoginPlayerTwoViewModel(NavigationStore navigationStore, Game game, Func<MultiplayerGameViewModel> createMultiplayerGameViewModel, Player playerOne)
>>>>>>> Stashed changes
        {
            //TODO DELETE FOLLOWING LINE
            this.Username = "Simon";
            this.playerOne = playerOne;
<<<<<<< Updated upstream
            this.StartCommand = new NavigateCommand(navigationStore, createMultiplayerGameViewModel, game1);
=======
            this.StartCommand = new NavigateCommand(navigationStore, game, createMultiplayerGameViewModel);
>>>>>>> Stashed changes
        }
    }
}
