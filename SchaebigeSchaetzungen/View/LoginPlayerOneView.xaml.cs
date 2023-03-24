
using System.Windows;
using System.Windows.Controls;

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
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            //TODO ERklärung rein
            MessageBox.Show("SO funktioniert das Spiel", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
