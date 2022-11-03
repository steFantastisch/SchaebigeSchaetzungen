using SchaebigeSchaetzungen.Stores;
using SchaebigeSchaetzungen.View;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Homescreen = SchaebigeSchaetzungen.View.Homescreen;
using Registration = SchaebigeSchaetzungen.View.Registration;

namespace SchaebigeSchaetzungen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

       

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel =new RegistrationVM();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
