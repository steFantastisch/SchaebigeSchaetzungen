using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Store
{
    public class GameStore
    {
        private Game _currentGame;
        public Game CurrentGame
        {
            get { return _currentGame; }
            set
            {
                _currentGame = value;
                
            }
        }
        
    }
}
