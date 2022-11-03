using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Windows.Input;

namespace SchaebigeSchaetzungen
{
	public class MainWindowViewModel :ViewModelBase
	{

        public ICommand HighscoreCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand AccountCommand { get; }
     

    }
}