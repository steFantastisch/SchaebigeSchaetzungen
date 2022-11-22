using SchaebigeSchaetzungen.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class MainViewModel :ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return navigationStore.CurrentViewModel;
            }
        }

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }

    }
}
