using SchaebigeSchaetzungen.ViewModel;
using System;


namespace SchaebigeSchaetzungen
{
	public class MainWindowViewModel :ViewModelBase
	{
		public MainWindowViewModel()
		{ Spielername=""; }
		public String Spielername { get; set; }

	}
}