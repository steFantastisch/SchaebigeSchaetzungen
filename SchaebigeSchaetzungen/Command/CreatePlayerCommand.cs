using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchaebigeSchaetzungen.Command
{
    public class CreatePlayerCommand : CommandBase
    {
        private Player _player;
        private readonly Game game;

        public CreatePlayerCommand(Game game, Player player)
        {
            
            _player = player;
            this.game = game;
        }

        public override void Execute(object parameter)
        {

            //prüfen ob alle eingaben Stimmen
            DBPlayer.Insert(_player);
        }
    }
}
