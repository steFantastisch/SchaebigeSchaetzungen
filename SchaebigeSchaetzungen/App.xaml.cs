using SchaebigeSchaetzungen.Model;
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
            navigationStore.CurrentViewModel = new LoginPlayerOneViewModel(navigationStore, CreateCreateViewModel, CreateGameModeSelectionViewModel);



            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private CreateViewModel CreateCreateViewModel()
        {
            return new CreateViewModel(navigationStore, CreateLoginPlayerOneViewModel, CreateGameModeSelectionViewModel);
        }

        private LoginPlayerOneViewModel CreateLoginPlayerOneViewModel()
        {
            return new LoginPlayerOneViewModel(navigationStore, CreateCreateViewModel, CreateGameModeSelectionViewModel);
        }

        private GameModeSelectionViewModel CreateGameModeSelectionViewModel()
        {
            return new GameModeSelectionViewModel(new Player(), navigationStore, CreateLoginPlayerOneViewModel, CreateLoginPlayerTwoViewModel, CreateSingleplayerGameViewModel);
        }

        private LoginPlayerTwoViewModel CreateLoginPlayerTwoViewModel()
        {
            return new LoginPlayerTwoViewModel(navigationStore, CreateMultiplayerGameViewModel, new Player());
        }

        private SingleplayerGameViewModel CreateSingleplayerGameViewModel()
        {
            return new SingleplayerGameViewModel();
        }
        private MultiplayerGameViewModel CreateMultiplayerGameViewModel()
        {
            return new MultiplayerGameViewModel();
        }

    }
}
