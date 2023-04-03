using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
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
        private readonly Game game;
        private IDBAccess _dBAccess;
        private IDBPlayer _dBPlayer;

        public App()
        {
            navigationStore = new NavigationStore();
            _dBAccess= new DBAccess();
            _dBPlayer=new DBPlayer(_dBAccess);
            game = new Game(_dBPlayer);                
        }

        protected override void OnStartup(StartupEventArgs e)
        {
             navigationStore.CurrentViewModel = new LoginPlayerOneViewModel(navigationStore, game, CreateCreateViewModel, CreateGameModeSelectionViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private CreateViewModel CreateCreateViewModel()
        {
            return new CreateViewModel(navigationStore, game, CreateLoginPlayerOneViewModel, CreateGameModeSelectionViewModel);
        }

        private LoginPlayerOneViewModel CreateLoginPlayerOneViewModel()
        {
            return new LoginPlayerOneViewModel(navigationStore, game, CreateCreateViewModel, CreateGameModeSelectionViewModel);
        }

        private GameModeSelectionViewModel CreateGameModeSelectionViewModel()
        {
            return new GameModeSelectionViewModel(navigationStore, game, CreateLoginPlayerOneViewModel, CreateLoginPlayerTwoViewModel, CreateSingleplayerGameViewModel);
        }

        private LoginPlayerTwoViewModel CreateLoginPlayerTwoViewModel()
        {
            return new LoginPlayerTwoViewModel(navigationStore, game, CreateMultiplayerGameViewModel);
        }

        private SingleplayerGameViewModel CreateSingleplayerGameViewModel()
        {
            return new SingleplayerGameViewModel(navigationStore, game, CreateGameEndViewModel);
        }
        private MultiplayerGameViewModel CreateMultiplayerGameViewModel()
        {
            return new MultiplayerGameViewModel(navigationStore, game, CreateGameEndMPViewModel);
        }
        private GameEndViewModel CreateGameEndViewModel()
        {
            return new GameEndViewModel(navigationStore, game, CreateGameModeSelectionViewModel, CreateSingleplayerGameViewModel, CreateHighscoreViewModel);
        }
        private GameEndMPViewModel CreateGameEndMPViewModel()
        {
            return new GameEndMPViewModel(navigationStore, game, CreateGameModeSelectionViewModel, CreateMultiplayerGameViewModel, CreateHighscoreViewModel);
        }
        private HighscoreViewModel CreateHighscoreViewModel()
        {
            return new HighscoreViewModel(navigationStore, game, CreateGameModeSelectionViewModel);
        }
    }
}
