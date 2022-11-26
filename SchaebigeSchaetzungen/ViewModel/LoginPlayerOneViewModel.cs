using SchaebigeSchaetzungen.Command;
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

        public ICommand LoginCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand HelpCommand { get; }

        public LoginPlayerOneViewModel(NavigationStore navigationStore, Func<CreateViewModel> createCreateViewModel, Func<GameModeSelectionViewModel> createGameModeSelectionViewModel)
        {
            //TODO DELETE FOLLOWING LINE
            this.Username = "Stefan";
            this.CreateCommand = new NavigateCommand(navigationStore, createCreateViewModel);
            this.LoginCommand = new NavigateCommand(navigationStore, createGameModeSelectionViewModel);
        }
    }
}
