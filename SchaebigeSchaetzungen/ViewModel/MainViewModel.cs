using SchaebigeSchaetzungen.Model;
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
        private readonly Game game1;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public MainViewModel(NavigationStore navigationStore,Game game1)
        {
            this.navigationStore = navigationStore;
            this.game1 = game1;
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

    }
}
