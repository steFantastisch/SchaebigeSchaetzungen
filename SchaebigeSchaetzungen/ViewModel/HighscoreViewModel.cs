using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using SchaebigeSchaetzungen.Store;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class HighscoreViewModel : ViewModelBase
    {

        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }
        private List<Player> playerList;
        public List<Player> PlayerList
        {
            get { return playerList; }
            set { playerList = value; }
        }

        private int rank;

        public int Rank
        {
            get { rank++;
                return rank; }
            set { rank = value; }
        }



        public ICommand ExitCommand { get; }

        public HighscoreViewModel(
           NavigationStore navigationStore,
           Game game,
          Func<GameModeSelectionViewModel> createGameModeSelectionViewModel)
        {
            this.Game = game;
            PlayerList = DBPlayer.ReadAll();
      Rank= 0;
            this.ExitCommand = new NavigateCommand(navigationStore, game, createGameModeSelectionViewModel);

        }
    }
}
