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
            MainWindow = new View.Registration()
            {
                DataContext = new ViewModel.RegistrationVM()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
