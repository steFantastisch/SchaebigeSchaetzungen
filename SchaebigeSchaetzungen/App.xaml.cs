using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;

        public App()
        {
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = new UserCredentialsViewModel(navigationStore, CreateCreateViewModel);
            


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private CreateViewModel CreateCreateViewModel()
        {
            return new CreateViewModel(navigationStore, CreateUserCredentialsViewModel);
        }

        private UserCredentialsViewModel CreateUserCredentialsViewModel()
        {
            return new UserCredentialsViewModel(navigationStore, CreateCreateViewModel);
        }
    }
}
