using Microsoft.Win32;
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
    /// Interaktionslogik für CreatePlayerView.xaml
    /// </summary>
    public partial class CreatePlayerView : UserControl
    {
        private Avatar _avatar = new Avatar(1);
        private Player _player = new Player();

        public CreatePlayerView()
        {
            //this._player = new Player();
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                //Only png?
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg"
            };

            bool? response = openFileDialog.ShowDialog();

            if (response == true)
            {
                _avatar = new Avatar(openFileDialog);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //TODO AVATAR
                Player temp = new Player(this.tbName.Text, this.pbPassword.Password, this.tbMail.Text);
                MessageBox.Show("Sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //empty textboxes and delete last avatar if not null
            }

        }
    }
}
