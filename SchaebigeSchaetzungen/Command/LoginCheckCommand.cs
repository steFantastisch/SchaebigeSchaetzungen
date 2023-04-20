using Google.Apis.YouTube.v3.Data;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Windows;

namespace SchaebigeSchaetzungen.Command
{
    public class LoginCheckCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;
        private Game game;
        Player player;

        public LoginCheckCommand(NavigationStore navigationStore, Game game, Func<ViewModelBase> createViewModel, Player p)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.game = game;
            this.player = p;

        }

        public override void Execute(object parameter)
        {
            if (game.PlayerTwo!=null)
            {
                try
                {
                    game.PlayerTwo=game.dBPlayer.Read(player);
                    if (game.PlayerTwo.Name!=null)
                    {
                        navigationStore.CurrentViewModel = createViewModel();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Player 2 not found in DB!", "Not found", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                try
                {
                    game.PlayerOne=game.dBPlayer.Read(player);
                    if (game.PlayerOne.Name!=null)
                    {
                        navigationStore.CurrentViewModel = createViewModel();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Player 1 not found in DB!", "Not found", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }
    }
}
