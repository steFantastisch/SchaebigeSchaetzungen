using Microsoft.Win32;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
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
    /// Interaktionslogik für CreatePlayerView.xaml
    /// </summary>
    public partial class CreatePlayerView : UserControl
    {
      
        private Player _player = new Player();

        public CreatePlayerView()
        {
           
            InitializeComponent();
        }

       

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //TODO AVATAR
                Player temp = new Player(this.tbName.Text, this.pbPassword.Password, this.tbMail.Text);
                DBPlayer.Insert(temp);
                //TODO Messagebox schöner machen
                MessageBox.Show("Player created and saved in DB", "Success", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Not saved", MessageBoxButton.OK, MessageBoxImage.Error);
                //empty textboxes and delete last avatar if not null
            }

        }
    }
}
