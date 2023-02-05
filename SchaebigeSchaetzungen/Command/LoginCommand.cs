using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Command
{
    public class LoginCommand : CommandBase
    {

        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;
        private readonly Game game;
        private readonly Player player;

        public LoginCommand(NavigationStore navigationStore, Game game, Func<ViewModelBase> createViewModel, Player player)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.game = game;
            this.player= player;
        }

        public override void Execute(object parameter)
        {

            navigationStore.CurrentViewModel = createViewModel();

        }
    }
}
