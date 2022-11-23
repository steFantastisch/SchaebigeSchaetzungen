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

        public NavigateCommand(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            navigationStore.CurrentViewModel = new CreateViewModel();
        }
    }
}
