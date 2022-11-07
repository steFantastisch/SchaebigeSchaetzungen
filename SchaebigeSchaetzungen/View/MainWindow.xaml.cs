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
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("C:\\Users\\grass\\source\\repos\\SchaebigeSchaetzungen\\SchaebigeSchaetzungen\\Resources\\schaebigeschaetzunge-fish.jpg", UriKind.Absolute));
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

            if(dlg.DialogResult == true)
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
