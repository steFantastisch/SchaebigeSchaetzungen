using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Command
{
    public class CreateGameCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;
        private readonly Game game1;
        private readonly string Name;

        public CreateGameCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel,Game game1,string Username)
        {
            this.Name= Username;
            this.navigationStore = navigationStore;
            this.game1 = game1;
            this.createViewModel = createViewModel;
            

        }
        public override void Execute(object parameter)
        {
            //TODO
            //In zukunft darf ja nicht hier jeder spieler erstellt werden sondern durch die anmeldedaten überprüft werden
            Player Spieler1 = new Player();
            Spieler1.Name = Name;
            game1.PlayerOne = Spieler1;
           
            //Navigation zum nächsten Fenster
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
