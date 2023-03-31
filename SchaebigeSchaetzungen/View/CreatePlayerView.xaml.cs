using Microsoft.Win32;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Persistence;
using System;
using System.Windows;
using System.Windows.Controls;

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
    }
}
