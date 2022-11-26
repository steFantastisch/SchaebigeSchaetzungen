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
        
        string Name;

        public CreateGameCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel,string User)
        {
            this.Name= User;
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            

        }
        public override void Execute(object parameter)
        {
            Player Spieler1 = new Player();
            Spieler1.Name = Name;
           
            //Navigation zum nächsten Fenster
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
