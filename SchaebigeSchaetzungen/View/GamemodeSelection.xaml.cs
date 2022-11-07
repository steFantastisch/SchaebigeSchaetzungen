using SchaebigeSchaetzungen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaktionslogik für GamemodeSelection.xaml
    /// </summary>
    public partial class GamemodeSelection : Window
    {
        private Player _playerOne;
        private Player _playerTwo;
        public GamemodeSelection(Player playerOne)
        {
            this._playerOne = playerOne;
            InitializeComponent();
        }

        private void btnSingleplayer_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(_playerOne, _playerTwo, Gamemode.Singleplayer);
            //TODO call gamewindow
        }

        private void btnMultiplayer_Click(object sender, RoutedEventArgs e)
        {
            //todo loginwindow
            Game game = new Game(_playerOne, _playerTwo, Gamemode.Multiplayer);
            //todo call gamewindow
        }
    }
}
