using Microsoft.Win32;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Linq;
using SchaebigeSchaetzungen.View;

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Avatar temp = new Avatar(2);

            InitializeComponent();
            //testimage.Source = temp.imageSource();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //PlayerDialog dlg = new PlayerDialog();
            //dlg.ShowDialog();


            CreateVideoDialog createVideoDialog = new CreateVideoDialog(DBPlayer.ReadAll().Find(x=>x.PlayerID.Equals(0)));
            createVideoDialog.ShowDialog();
        }

        
    }
}
