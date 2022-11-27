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
<<<<<<< Updated upstream
        private readonly GameStore gameStore;
        private Game game1;
=======
        private readonly Game game;
>>>>>>> Stashed changes

        public App()
        {
            navigationStore = new NavigationStore();
<<<<<<< Updated upstream
            //gameStore = new GameStore();
           game1 = new Game();
=======
            game = new Game();
            game.PlayerOne = new Player();
            game.PlayerOne.Name = "Stefan";
            //game.PlayerTwo.Name = "Simon";
>>>>>>> Stashed changes
        }

        protected override void OnStartup(StartupEventArgs e)
        {
<<<<<<< Updated upstream
    
            navigationStore.CurrentViewModel = new LoginPlayerOneViewModel(navigationStore, game1, CreateCreateViewModel, CreateGameModeSelectionViewModel); ;
 
=======
            navigationStore.CurrentViewModel = new LoginPlayerOneViewModel(navigationStore, game, CreateCreateViewModel, CreateGameModeSelectionViewModel);

>>>>>>> Stashed changes


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore,game1)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private CreateViewModel CreateCreateViewModel()
        {
<<<<<<< Updated upstream
            return new CreateViewModel(navigationStore, game1, CreateLoginPlayerOneViewModel, CreateGameModeSelectionViewModel);
=======
            return new CreateViewModel(navigationStore, game, CreateLoginPlayerOneViewModel, CreateGameModeSelectionViewModel);
>>>>>>> Stashed changes
        }

        private LoginPlayerOneViewModel CreateLoginPlayerOneViewModel()
        {
<<<<<<< Updated upstream
            return new LoginPlayerOneViewModel(navigationStore, game1, CreateCreateViewModel, CreateGameModeSelectionViewModel);
=======
            return new LoginPlayerOneViewModel(navigationStore, game, CreateCreateViewModel, CreateGameModeSelectionViewModel);
>>>>>>> Stashed changes
        }

        private GameModeSelectionViewModel CreateGameModeSelectionViewModel()
        {
<<<<<<< Updated upstream
            return new GameModeSelectionViewModel(new Player(),  navigationStore,game1, CreateLoginPlayerOneViewModel, CreateLoginPlayerTwoViewModel, CreateSingleplayerGameViewModel);
=======
            return new GameModeSelectionViewModel(navigationStore, game, CreateLoginPlayerOneViewModel, CreateLoginPlayerTwoViewModel, CreateSingleplayerGameViewModel);
>>>>>>> Stashed changes
        }

        private LoginPlayerTwoViewModel CreateLoginPlayerTwoViewModel()
        {
<<<<<<< Updated upstream
            return new LoginPlayerTwoViewModel(navigationStore, game1, CreateMultiplayerGameViewModel, new Player());
=======
            return new LoginPlayerTwoViewModel(navigationStore, game, CreateMultiplayerGameViewModel, new Player());
>>>>>>> Stashed changes
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
