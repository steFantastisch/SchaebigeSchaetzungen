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

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Avatar temp = new Avatar(4);

            InitializeComponent();
            testimage.Source = temp.imageSource();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                //Only png?
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg"
            };

            bool ? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                Avatar temp = new Avatar(openFileDialog);

                testimage.Source = temp.imageSource();
            }
        }

        
    }
}
