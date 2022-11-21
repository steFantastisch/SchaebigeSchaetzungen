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
    /// Interaktionslogik für MainPlayerLoginView.xaml
    /// </summary>
    public partial class MainPlayerLoginView : UserControl
    {
        public MainPlayerLoginView()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            //myBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\grass\\source\\repos\\SchaebigeSchaetzungen\\SchaebigeSchaetzungen\\Resources\\schaebigeschaetzunge-fish.jpg", UriKind.Absolute));
            this.Background = myBrush;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Player temp = new Player();
            CreatePlayerDialog dlg = new CreatePlayerDialog(temp);
            dlg.Show();

            if (dlg.DialogResult == true)
            {
                StartGame();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            //TODO implement
            //change to window single oder multiplayer
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            //TODO implement
        }
    }
}
