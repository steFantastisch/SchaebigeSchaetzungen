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
    public class GameModeSelectionViewModel : ViewModelBase
    {
        private Player _playerOne;
 

        public Player PlayerOne
        {
            get { return _playerOne; }
            set { _playerOne = value; }
        }


        public ICommand SingleplayerCommand { get; }
        public ICommand MultiplayerCommand { get; }
        public ICommand CancelCommand { get; }

        public GameModeSelectionViewModel(
            Player playerOne, 
            NavigationStore navigationStore, 
            Func<LoginPlayerOneViewModel> createLoginPlayerOneViewModel, 
            Func<LoginPlayerTwoViewModel> createLoginPlayerTwoViewModel, 
            Func<SingleplayerGameViewModel> createSingleplayerGameViewModel)
        {
         
            this._playerOne = playerOne;
            this.SingleplayerCommand = new NavigateCommand(navigationStore, createSingleplayerGameViewModel);
            this.MultiplayerCommand = new NavigateCommand(navigationStore, createLoginPlayerTwoViewModel);
            this.CancelCommand = new NavigateCommand(navigationStore, createLoginPlayerOneViewModel);
        }
    }
}
