using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Command
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;
<<<<<<< Updated upstream
        private readonly Game game1;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel, Game game)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.game1 = game;
=======
        private readonly Game game;

        public NavigateCommand(NavigationStore navigationStore, Game game, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.game = game;
>>>>>>> Stashed changes
        }
      

        public override void Execute(object parameter)
        {
            
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
