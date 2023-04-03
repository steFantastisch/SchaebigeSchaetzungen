using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchaebigeSchaetzungen.Command
{
    public class CreatePlayerCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;
        private Game game;
        Player player;

        public CreatePlayerCommand(NavigationStore navigationStore, Game game, Func<ViewModelBase> createViewModel, Player p)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.game = game;
            this.player = p;

        }

        public override void Execute(object parameter)
        {
            if ((player.Mail == null) || (player.Name == null)||(player.Password == null))
            {
                MessageBox.Show("Not saved. You left something empty","Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                game.dBPlayer.Insert(player);
                navigationStore.CurrentViewModel = createViewModel();
                MessageBox.Show("Player created and saved in DB", "Success", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Not saved", MessageBoxButton.OK, MessageBoxImage.Error);

            }
           
        }
    }
}
