using SchaebigeSchaetzungen.Store;

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

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

    }
}
