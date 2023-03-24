using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;

namespace SchaebigeSchaetzungen.Command
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;
        private readonly Game game;

        public NavigateCommand(NavigationStore navigationStore, Game game, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.game = game;
        }

        public override void Execute(object parameter)
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
