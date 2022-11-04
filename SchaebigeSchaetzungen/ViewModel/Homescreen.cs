﻿using SchaebigeSchaetzungen.Commands;
using SchaebigeSchaetzungen.ViewModel;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
	public class Homescreen : ViewModelBase
	{
       
        public ICommand HighscoreCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand AccountCommand { get; }

        public Homescreen()
        {
            HighscoreCommand = new ToHighscoreView();
            PlayCommand = new ToGameView();
            AccountCommand = new ToRegistrationView();
        }
    }
}