﻿using SchaebigeSchaetzungen.Command;
using SchaebigeSchaetzungen.Model;
using SchaebigeSchaetzungen.Store;
using System;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.ViewModel
{
    public class LoginPlayerTwoViewModel : ViewModelBase
    {
        public LoginPlayerTwoViewModel(NavigationStore navigationStore, Game game, Func<MultiplayerGameViewModel> createMultiplayerGameViewModel)
        {
           
            this.Game = game;
            if (this.Game.PlayerTwo == null)
            {
                this.Game.PlayerTwo = new Player();

                game.PlayerTwo.Mail = Username;
                game.PlayerTwo.Name = Password;
                //TODO DELETE FOLLOWING LINEs
                game.PlayerTwo.Mail = "testuuu";
                game.PlayerTwo.Password = "1234";

            }
            this.StartCommand = new LoginCheckCommand(navigationStore, Game, createMultiplayerGameViewModel, game.PlayerTwo);
        }
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

        
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }



        public ICommand StartCommand { get; }

        
    }
}
