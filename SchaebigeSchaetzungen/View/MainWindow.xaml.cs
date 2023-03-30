using SchaebigeSchaetzungen.Model;
using System.Windows;

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; set; }
        public IPointsCalculator pointsCalculator => Game.PointsCalculator;
        public MainWindow()
        {

            InitializeComponent();

        }

    }
}
