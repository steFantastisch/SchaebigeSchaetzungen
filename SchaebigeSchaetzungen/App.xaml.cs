using SchaebigeSchaetzungen.View;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //MainWindow = new View.MainWindow()
            //{
            //    DataContext = new ViewModel.MainViewModel()
            //};
            //MainWindow.Show();
            //brauchen wir nicht wegen STartupUri in APp.xaml

            //base.OnStartup(e);
        }
    }
}
