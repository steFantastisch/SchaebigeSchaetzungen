using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Windows.Input;

namespace SchaebigeSchaetzungen
{
	public class Homescreen :ViewModelBase
	{

        public ICommand HighscoreCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand AccountCommand { get; }
     

    }
}