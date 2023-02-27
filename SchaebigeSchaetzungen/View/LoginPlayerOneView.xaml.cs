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
    public partial class LoginPlayerOneView : UserControl
    {
        public LoginPlayerOneView()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            //myBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\grass\\source\\repos\\SchaebigeSchaetzungen\\SchaebigeSchaetzungen\\Resources\\schaebigeschaetzunge-fish.jpg", UriKind.Absolute));
            this.Background = myBrush;
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            //TODO ERklärung rein
            MessageBox.Show("SO funktioniert das Spiel", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
