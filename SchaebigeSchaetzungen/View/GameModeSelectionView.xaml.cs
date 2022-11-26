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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaktionslogik für GameModeSelectionView.xaml
    /// </summary>
    public partial class GameModeSelectionView : UserControl
    {
        private Player playerOne;

        public GameModeSelectionView(Player player)
        {
            this.playerOne = player;
            InitializeComponent();
        }
    }
}
