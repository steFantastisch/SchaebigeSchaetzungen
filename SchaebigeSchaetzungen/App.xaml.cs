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
        private readonly GameStore gameStore;
        private Game game1;

        public App()
        {
            navigationStore = new NavigationStore();
            //gameStore = new GameStore();
           game1 = new Game();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
    
            navigationStore.CurrentViewModel = new LoginPlayerOneViewModel(navigationStore, game1, CreateCreateViewModel, CreateGameModeSelectionViewModel); ;
 


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore,game1)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private CreateViewModel CreateCreateViewModel()
        {
            return new CreateViewModel(navigationStore, game1, CreateLoginPlayerOneViewModel, CreateGameModeSelectionViewModel);
        }

        private LoginPlayerOneViewModel CreateLoginPlayerOneViewModel()
        {
            return new LoginPlayerOneViewModel(navigationStore, game1, CreateCreateViewModel, CreateGameModeSelectionViewModel);
        }

        private GameModeSelectionViewModel CreateGameModeSelectionViewModel()
        {
            return new GameModeSelectionViewModel(new Player(),  navigationStore,game1, CreateLoginPlayerOneViewModel, CreateLoginPlayerTwoViewModel, CreateSingleplayerGameViewModel);
        }

        private LoginPlayerTwoViewModel CreateLoginPlayerTwoViewModel()
        {
            return new LoginPlayerTwoViewModel(navigationStore, game1, CreateMultiplayerGameViewModel, new Player());
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
