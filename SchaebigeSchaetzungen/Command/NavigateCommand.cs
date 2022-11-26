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

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
