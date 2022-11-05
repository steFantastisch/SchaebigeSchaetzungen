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
using System.Windows.Shapes;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace SchaebigeSchaetzungen.View
{
    /// <summary>
    /// Interaktionslogik für PlayerDialog.xaml
    /// </summary>
    public partial class PlayerDialog : Window
    {
        private Avatar _avatar;

        public PlayerDialog()
        {
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
                Player temp = new Player()
                {
                    Name = this.tbName.Text,
                    Mail = this.tbMail.Text,
                    Password = this.pbPassword.Password,
                    Avatar = this._avatar
                };
                temp.Insert();
                this.DialogResult = true;
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //empty textboxes and delete last avatar if not null
            }
            
        }

    }
}
