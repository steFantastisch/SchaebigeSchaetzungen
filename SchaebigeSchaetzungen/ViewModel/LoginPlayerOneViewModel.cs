﻿using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class LoginPlayerOneViewModel : ViewModelBase
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //private Game game;

        //public Game Game
        //{
        //    get { return game; }
        //    set { game = value; }
        //}


        public ICommand LoginCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand HelpCommand { get; }



        public LoginPlayerOneViewModel(NavigationStore navigationStore,Game game1, Func<CreateViewModel> createCreateViewModel, Func<GameModeSelectionViewModel> createGameModeSelectionViewModel)
        {
            //TODO DELETE FOLLOWING LINE
            this.Username = "Stefan";
            this.CreateCommand = new NavigateCommand(navigationStore, createCreateViewModel,game1);
            //this.LoginCommand = new NavigateCommand(navigationStore, createGameModeSelectionViewModel);
            this.LoginCommand = new CreateGameCommand(navigationStore, createGameModeSelectionViewModel,game1,this.username);
        }
    }
}
